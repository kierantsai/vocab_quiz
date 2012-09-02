using System.Xml.Serialization;
using Microsoft.Practices.Prism.ViewModel;

namespace Vocab.Models
{
    public class Definition : NotificationObject
    {
        private string _body;

        public Definition()
        {
            _body = "Edit Definition.";
        }

        [XmlElement("Body")]
        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
                base.RaisePropertyChanged("Body");
            }
        }

        public override string ToString()
        {
            return _body;
        }
    }
}
