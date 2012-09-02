using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using VocabQuiz.Infrastructure.DialogServices;
using Vocab.Models;

namespace Vocab.ViewModels
{
    [Export(typeof(VocabViewModel))]
    public class VocabViewModel : NotificationObject
    {
        private IDialogService _dialogService;
        private string _textBoxWord;
        private Word _selectedWord;
        private Definition _selectedDefinition;

        public VocabViewModel()
        {
            
            _textBoxWord = string.Empty;
        }

        [Import(typeof(IDialogService))]
        public IDialogService DialogService
        {
            get
            {
                return _dialogService;
            }
            set
            {
                _dialogService = value;
            }
        }

        public string Header
        {
            get
            {
                return Localization.Resource.VocabHeader;
            }
        }

        public VocabDictionary Vocabulary
        {
            get
            {
                return VocabManager.GetInstance().Vocabulary;
            }
            set
            {
                VocabManager.GetInstance().Vocabulary = value;
                base.RaisePropertyChanged(() => this.Vocabulary);
            }
        }

        public string TextBoxWord
        {
            get
            {
                return _textBoxWord;
            }
            set
            {
                _textBoxWord = value;
                base.RaisePropertyChanged(() => this.TextBoxWord);
                this.NewWordCommand.RaiseCanExecuteChanged();
            }
        }

        public Word SelectedWord
        {
            get
            {
                return _selectedWord;
            }
            set
            {
                _selectedWord = value;
                base.RaisePropertyChanged(() => this.SelectedWord);
                this.DeleteWordCommand.RaiseCanExecuteChanged();
                this.AddDefinitionCommand.RaiseCanExecuteChanged();
            }
        }

        public Definition SelectedDefinition
        {
            get
            {
                return _selectedDefinition;
            }
            set
            {
                _selectedDefinition = value;
                base.RaisePropertyChanged(() => this.SelectedDefinition);
                this.RemoveDefinitionCommand.RaiseCanExecuteChanged();
            }
        }

        private DelegateCommand _newWordCommand;

        public DelegateCommand NewWordCommand
        {
            get
            {
                if (_newWordCommand == null)
                {
                    _newWordCommand = new DelegateCommand(
                        () =>
                        {
                            if (this.Vocabulary.AddWord(this.TextBoxWord))
                            {
                                this.NewWordCommand.RaiseCanExecuteChanged();
                                this.DeleteWordCommand.RaiseCanExecuteChanged();
                            }
                        },
                        () => _textBoxWord != null &&
                            !_textBoxWord.Equals(string.Empty) &&
                            !this.Vocabulary.ContainsWord(this.TextBoxWord)
                        );
                }
                return _newWordCommand;
            }
        }

        private DelegateCommand _deleteWordCommand;

        public DelegateCommand DeleteWordCommand
        {
            get
            {
                if (_deleteWordCommand == null)
                {
                    _deleteWordCommand = new DelegateCommand(
                        () =>
                        {
                            if (this.Vocabulary.RemoveWord(this.SelectedWord.Text))
                            {
                                this.NewWordCommand.RaiseCanExecuteChanged();
                                this.DeleteWordCommand.RaiseCanExecuteChanged();
                            }
                        },
                        () => this.SelectedWord != null && this.Vocabulary.ContainsWord(this.SelectedWord.Text)
                        );
                }
                return _deleteWordCommand;
            }
        }

        private DelegateCommand _saveVocabularyCommand;

        public DelegateCommand SaveVocabularyCommand
        {
            get
            {
                if (_saveVocabularyCommand == null)
                {
                    _saveVocabularyCommand = new DelegateCommand(
                        () =>
                        {
                            ISaveFileDialogService saveFileDialogService
                                = this.DialogService.CreateSaveFileDialogService();
                            saveFileDialogService.Filter = "Xml Documents|*.xml|All Files|*";
                            saveFileDialogService.OverwritePrompt = true;

                            if (saveFileDialogService.ShowDialog() == true)
                            {
                                VocabManager.Save(this.Vocabulary, saveFileDialogService.FileName);
                            }
                        }
                        );
                }
                return _saveVocabularyCommand;
            }
        }

        private DelegateCommand _loadVocabularyCommand;

        public DelegateCommand LoadVocabularyCommand
        {
            get
            {
                if (_loadVocabularyCommand == null)
                {
                    _loadVocabularyCommand = new DelegateCommand(
                        () =>
                        {
                            IOpenFileDialogService openFileDialogService
                                = this.DialogService.CreateOpenFileDialogService();

                            openFileDialogService.Filter = "Xml Documents|*.xml|All Files|*";
                            openFileDialogService.CheckFileExists = true;

                            if (openFileDialogService.ShowDialog() == true)
                            {
                                this.Vocabulary = VocabManager.Load(openFileDialogService.FileName);
                                this.SelectedWord = null;
                                this.SelectedDefinition = null;
                                this.NewWordCommand.RaiseCanExecuteChanged();
                                this.DeleteWordCommand.RaiseCanExecuteChanged();
                                this.AddDefinitionCommand.RaiseCanExecuteChanged();
                                this.RemoveDefinitionCommand.RaiseCanExecuteChanged();
                            }
                        }
                        );
                }
                return _loadVocabularyCommand;
            }
        }

        private DelegateCommand _addDefinitionCommand;

        public DelegateCommand AddDefinitionCommand
        {
            get
            {
                if (_addDefinitionCommand == null)
                {
                    _addDefinitionCommand = new DelegateCommand(
                        () =>
                        {
                            Definition definition = new Definition();
                            this.SelectedWord.Definitions.Add(definition);
                        },
                        () => this.SelectedWord != null
                        );
                }
                return _addDefinitionCommand;
            }
        }

        private DelegateCommand _removeDefinitionCommand;

        public DelegateCommand RemoveDefinitionCommand
        {
            get
            {
                if (_removeDefinitionCommand == null)
                {
                    _removeDefinitionCommand = new DelegateCommand(
                        () =>
                        {
                            Definition definition = this.SelectedDefinition;
                            this.SelectedWord.Definitions.Remove(definition);
                            this.RemoveDefinitionCommand.RaiseCanExecuteChanged();
                        },
                        () => this.SelectedDefinition != null
                        );
                }
                return _removeDefinitionCommand;
            }
        }
    }
}
