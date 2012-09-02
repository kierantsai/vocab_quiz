using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Microsoft.Practices.Prism.ViewModel;

namespace Vocab.Models
{
    public class Word : NotificationObject, IComparable<Word>, IComparable
    {
        
        private string _text;
        private ObservableCollection<Definition> _definitions;

        private Word()
            : this(string.Empty)
        {
        }

        public Word(string text)
        {
            _text = text;
            _definitions = new ObservableCollection<Definition>();
        }
        
        [XmlAttribute("Text")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                base.RaisePropertyChanged("Text");
            }
        }

        [XmlElement("Definition")]
        public ObservableCollection<Definition> Definitions
        {
            get
            {
                return _definitions;
            }
            set
            {
                _definitions = value;
                base.RaisePropertyChanged("Definitions");
            }
        }

        public override string ToString()
        {
            return this.Text;
        }

        public int CompareTo(Word other)
        {
            return this.Text.CompareTo(other.Text);
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
