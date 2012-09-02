using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using VocabQuiz.Infrastructure.DialogServices;

namespace VocabQuiz.Services.DialogServices
{
    [Export(typeof(IMessageBoxService))]
    class DefaultMessageBoxService : IMessageBoxService
    {
        public DefaultMessageBoxService()
        {
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
