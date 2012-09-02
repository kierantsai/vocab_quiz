using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vocab.Models;

namespace Vocab
{
    public class VocabManager
    {
        private VocabManager()
        {
            _vocabulary = new VocabDictionary();
        }

        private static VocabManager _instance;

        public static VocabManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new VocabManager();
            }
            return _instance;
        }

        private VocabDictionary _vocabulary;

        public VocabDictionary Vocabulary
        {
            get
            {
                return _vocabulary;
            }
            set
            {
                _vocabulary = value;
            }
        }

        public static void Save(VocabDictionary vocabulary, string fileName)
        {
            vocabulary.SynchronizeWords();
            using (XmlTextWriter xw = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                xw.Formatting = Formatting.Indented;

                XmlSerializer serializer = new XmlSerializer(typeof(VocabDictionary));
                serializer.Serialize(xw, vocabulary);
            }
        }

        public static VocabDictionary Load(string fileName)
        {
            VocabDictionary vocabulary;
            using (XmlReader xr = new XmlTextReader(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(VocabDictionary));
                vocabulary = serializer.Deserialize(xr) as VocabDictionary;
            }
            vocabulary.SynchronizeDictionary();
            return vocabulary;
        }
    }
}
