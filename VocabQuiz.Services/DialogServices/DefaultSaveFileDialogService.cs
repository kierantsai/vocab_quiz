using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using VocabQuiz.Infrastructure.DialogServices;

namespace VocabQuiz.Services.DialogServices
{
    class DefaultSaveFileDialogService : DefaultFileDialogService, ISaveFileDialogService
    {
        private SaveFileDialog _sfd;

        public DefaultSaveFileDialogService()
            : base(new SaveFileDialog())
        {
            _sfd = base._fd as SaveFileDialog;
        }

        public bool CreatePrompt
        {
            get
            {
                return _sfd.CreatePrompt;
            }
            set
            {
                _sfd.CreatePrompt = value;
            }
        }

        public bool OverwritePrompt
        {
            get
            {
                return _sfd.OverwritePrompt;
            }
            set
            {
                _sfd.OverwritePrompt = value;
            }
        }
    }
}
