using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocabQuiz.Infrastructure.InteractionRequest
{
    public interface IModalWindowFactory
    {
        ModalWindowBase CreateModalWindow();
    }
}
