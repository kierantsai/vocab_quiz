using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VocabQuiz.Infrastructure.InteractionRequest;


namespace VocabQuiz.UserControls.InteractionRequest
{
    public class NotificationDialogFactory : IModalWindowFactory
    {
        public ModalWindowBase CreateModalWindow()
        {
            return new NotificationDialog();
        }
    }
}
