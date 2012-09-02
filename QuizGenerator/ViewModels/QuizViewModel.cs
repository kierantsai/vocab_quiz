using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Vocab;

namespace QuizGenerator.ViewModels
{
    [Export(typeof(QuizViewModel))]
    public class QuizViewModel : NotificationObject
    {
        private InteractionRequest<Confirmation> _generateQuizInteractionRequest;

        public QuizViewModel()
        {
            _generateQuizInteractionRequest = new InteractionRequest<Confirmation>();
        }

        public string Header
        {
            get
            {
                return Localization.Resource.QuizGeneratorHeader;
            }
        }

        public InteractionRequest<Confirmation> GenerateQuizInteractionRequest
        {
            get
            {
                return _generateQuizInteractionRequest;
            }
        }

        #region Commands

        private DelegateCommand _generateQuizCommand;

        public DelegateCommand GenerateQuizCommand
        {
            get
            {
                if (_generateQuizCommand == null)
                {
                    _generateQuizCommand = new DelegateCommand(
                        () =>
                        {
                            _generateQuizInteractionRequest.Raise(
                                new Confirmation()
                                {
                                    Title = "Generate Quiz",
                                    Content = new QuizParameterViewModel()
                                },
                                (confirmation) =>
                                {
                                    Debug.WriteLine("Checking confirmation");
                                    if (confirmation.Confirmed)
                                    {
                                        GenerateQuiz();
                                    }
                                }
                                );
                        },
                        () => true
                        );
                }
                return _generateQuizCommand;
            }
        }

        #endregion

        private void GenerateQuiz()
        {
            
        }
    }
}
