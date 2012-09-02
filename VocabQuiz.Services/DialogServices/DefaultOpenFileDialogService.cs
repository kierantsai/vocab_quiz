using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using VocabQuiz.Infrastructure.DialogServices;

namespace VocabQuiz.Services.DialogServices
{
    class DefaultOpenFileDialogService : DefaultFileDialogService, IOpenFileDialogService
    {
        private OpenFileDialog _ofd;

        public DefaultOpenFileDialogService()
            : base(new OpenFileDialog())
        {
            _ofd = base._fd as OpenFileDialog;
        }

        public bool MultiSelect
        {
            get
            {
                return _ofd.Multiselect;
            }
            set
            {
                _ofd.Multiselect = value;
            }
        }

        public bool ReadOnlyChecked
        {
            get
            {
                return _ofd.ReadOnlyChecked;
            }
            set
            {
                _ofd.ReadOnlyChecked = value;
            }
        }

        public bool ShowReadOnly
        {
            get
            {
                return _ofd.ShowReadOnly;
            }
            set
            {
                _ofd.ShowReadOnly = value;
            }
        }
    }
}
