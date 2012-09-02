using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace QuizGenerator.ViewModels
{
    class QuizParameterViewModel : NotificationObject, IDataErrorInfo
    {
        public QuizParameterViewModel()
            : base()
        {
            if (!string.IsNullOrEmpty(QuizParameters.GetInstance().Error))
            {
                QuizParameters.GetInstance().Reset();
            }
            _numberOfQuestions = QuizParameters.GetInstance().NumberOfQuestions.ToString();
            _numberOfChoices = QuizParameters.GetInstance().NumberOfChoices.ToString();
        }

        private string _numberOfQuestions;

        public string NumberOfQuestions
        {
            get
            {
                return _numberOfQuestions;
            }
            set
            {
                if (_numberOfQuestions != value)
                {
                    _numberOfQuestions = value;
                    if (IsValidInteger(_numberOfQuestions))
                    {
                        QuizParameters.GetInstance().NumberOfQuestions =
                            Convert.ToInt32(_numberOfQuestions);
                    }
                    base.RaisePropertyChanged(() => this.NumberOfQuestions);
                    base.RaisePropertyChanged(() => this.CanConfirm);
                }
            }
        }

        private string _numberOfChoices;

        public string NumberOfChoices
        {
            get
            {
                return _numberOfChoices;
            }
            set
            {
                if (_numberOfChoices != value)
                {
                    _numberOfChoices = value;
                    if (IsValidInteger(_numberOfChoices))
                    {
                        QuizParameters.GetInstance().NumberOfChoices =
                            Convert.ToInt32(_numberOfChoices);
                    }
                    base.RaisePropertyChanged(() => this.NumberOfChoices);
                    base.RaisePropertyChanged(() => this.CanConfirm);
                }
            }
        }

        public void ResetToDefault()
        {
            QuizParameters.GetInstance().Reset();
        }

        public bool CanConfirm
        {
            get
            {
                return string.IsNullOrEmpty(this.Error);
            }
        }

        public string Error
        {
            get
            {
                return this["NumberOfQuestions"] + this["NumberOfChoices"];
            }
        }

        public string this[string columnName]
        {
            get
            {
                string errorMessage = string.Empty;
                switch (columnName)
                {
                    case "NumberOfQuestions":
                        if (!IsValidInteger(this.NumberOfQuestions))
                        {
                            errorMessage = "Number of questions must be an integer";
                        }
                        else
                        {
                            return QuizParameters.GetInstance()[columnName];
                        }
                        break;
                    case "NumberOfChoices":
                        if (!IsValidInteger(this.NumberOfChoices))
                        {
                            errorMessage = "Number of choices must be an integer";
                        }
                        else
                        {
                            return QuizParameters.GetInstance()[columnName];
                        }
                        break;
                    default:
                        errorMessage = "Unexpected Property";
                        break;
                }
                return errorMessage;
            }
        }

        private bool IsValidInteger(string text)
        {
            int value;
            return int.TryParse(text, out value) && !string.IsNullOrEmpty(text);
        }
    }
}
