using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuizGenerator
{
    class QuizParameters : IDataErrorInfo
    {
        const int DEFAULT_NUMBER_OF_QUESTIONS = 20;
        const int DEFAULT_NUMBER_OF_CHOICES = 4;

        private QuizParameters()
        {
            Reset();
        }

        private static QuizParameters _instance;

        public static QuizParameters GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QuizParameters();
            }
            return _instance;
        }

        public void Reset()
        {
            NumberOfQuestions = DEFAULT_NUMBER_OF_QUESTIONS;
            NumberOfChoices = DEFAULT_NUMBER_OF_CHOICES;
        }

        private int _numberOfQuestions;

        public int NumberOfQuestions
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
                }
            }
        }

        private int _numberOfChoices;

        public int NumberOfChoices
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
                }
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
                        if (NumberOfQuestions <= 0)
                        {
                            errorMessage = "Number of Questions has to be greater than 0.";
                        }
                        break;
                    case "NumberOfChoices":
                        if (NumberOfChoices <= 1)
                        {
                            errorMessage = "Number of Choices has to be greater than 1.";
                        }
                        break;
                    default:
                        break;
                }

                return errorMessage;
            }
        }
    }
}
