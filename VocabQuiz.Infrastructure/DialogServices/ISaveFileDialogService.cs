using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocabQuiz.Infrastructure.DialogServices
{
    public interface ISaveFileDialogService : IFileDialogService
    {
        bool CreatePrompt
        {
            get;
            set;
        }

        bool OverwritePrompt
        {
            get;
            set;
        }
    }
}
