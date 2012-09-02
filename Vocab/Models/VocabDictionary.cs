using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace Vocab.Models
{
    [Export(typeof(VocabDictionary))]
    public class VocabDictionary
    {
        private IDictionary<string, Word> _dictionary;
        private ObservableCollection<Word> _words;
        
        public VocabDictionary()
        {
            _dictionary = new Dictionary<string, Word>();
        }

        [XmlElement("Word")]
        public ObservableCollection<Word> Words
        {
            get
            {
                if (_words == null)
                {
                    _words = new ObservableCollection<Word>();
                }
                return _words;
            }
            set
            {
                _words = value;
                this.SynchronizeDictionary();
            }
        }

        public bool AddWord(string word)
        {
            if (!_dictionary.ContainsKey(word))
            {
                _dictionary.Add(word, new Word(word));
                this.SynchronizeWords();
                return true;
            }
            
            return false;
        }

        public bool RemoveWord(string word)
        {
            if (_dictionary.ContainsKey(word))
            {
                _dictionary.Remove(word);
                this.SynchronizeWords();
                return true;
            }
            return false;
        }

        public bool ContainsWord(string word)
        {
            return _dictionary.ContainsKey(word);
        }

        public Word GetWord(string word)
        {
            if (_dictionary.ContainsKey(word))
            {
                return _dictionary[word];
            }
            return null;
        }

        

        public void SynchronizeWords()
        {
            if (_words.Count != _dictionary.Keys.Count)
            {
                foreach (Word word in _dictionary.Values)
                {
                    if (!_words.Contains(word))
                    {
                        _words.Add(word);
                    }
                }

                IList<Word> words = new List<Word>();
                foreach (Word word in _words)
                {
                    if (!_dictionary.ContainsKey(word.Text))
                    {
                        words.Add(word);
                    }
                }
                foreach (Word word in words)
                {
                    _words.Remove(word);
                }
            }
        }

        public void SynchronizeDictionary()
        {
            if (_words.Count != _dictionary.Keys.Count)
            {
                foreach (Word word in _words)
                {
                    if (!_dictionary.ContainsKey(word.Text))
                    {
                        _dictionary[word.Text] = word;
                    }
                }

                IList<string> words = new List<string>();
                foreach(Word word in _dictionary.Values)
                {
                    if (!_words.Contains(word))
                    {
                        words.Add(word.Text);
                    }
                }
                foreach (string word in words)
                {
                    _dictionary.Remove(word);
                }
            }
        }
    }
}
