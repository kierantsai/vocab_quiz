using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocabQuiz.Infrastructure.DialogServices
{
    public interface IOpenFileDialogService : IFileDialogService
    {
        bool MultiSelect
        {
            get;
            set;
        }

        bool ReadOnlyChecked
        {
            get;
            set;
        }

        bool ShowReadOnly
        {
            get;
            set;
        }
    }
}
