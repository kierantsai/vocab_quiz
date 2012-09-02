using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace QuizGenerator.ViewModels
{
    class MultipleChoiceViewModel : NotificationObject
    {
        private string _question;
        private IList<string> _choices;
        private string _selectedChoice;

        public MultipleChoiceViewModel(string question, IList<string> choices)
        {
            this.Question = question;
            this.Choices = choices;
        }

        public string Question
        {
            get
            {
                return _question;
            }
            private set
            {
                _question = value;
                base.RaisePropertyChanged(() => this.Question);
            }
        }

        public IList<string> Choices
        {
            get
            {
                return _choices;
            }
            private set
            {
                _choices = value;
                base.RaisePropertyChanged(() => this.Choices);
            }
        }

        public string SelectedChoice
        {
            get
            {
                return _selectedChoice;
            }
            set
            {
                _selectedChoice = value;
                base.RaisePropertyChanged(() => this.SelectedChoice);
            }
        }
    }
}
