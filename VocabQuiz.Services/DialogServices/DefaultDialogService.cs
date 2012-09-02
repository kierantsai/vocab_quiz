using System.Windows;
using System.ComponentModel.Composition;
using VocabQuiz.Infrastructure.DialogServices;

namespace VocabQuiz.Services.DialogServices
{
    [Export(typeof(IDialogService))]
    public class DefaultDialogService : IDialogService
    {
        public DefaultDialogService()
        {
        }

        public IOpenFileDialogService CreateOpenFileDialogService()
        {
            return new DefaultOpenFileDialogService();
        }

        public ISaveFileDialogService CreateSaveFileDialogService()
        {
            return new DefaultSaveFileDialogService();
        }

        public IMessageBoxService CreateMessageBoxService()
        {
            return new DefaultMessageBoxService();
        }
    }
}
