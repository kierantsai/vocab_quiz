using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocabQuiz.Infrastructure.DialogServices
{
    public interface ICommonDialogueService
    {
        Nullable<bool> ShowDialog();
        void Reset();
    }
}
