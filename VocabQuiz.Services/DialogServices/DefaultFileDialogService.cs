using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using VocabQuiz.Infrastructure.DialogServices;

namespace VocabQuiz.Services.DialogServices
{
    class DefaultFileDialogService : IFileDialogService
    {
        protected FileDialog _fd;

        protected DefaultFileDialogService(FileDialog fd)
        {
            _fd = fd;
        }

        public bool AddExtension
        {
            get
            {
                return _fd.AddExtension;
            }
            set
            {
                _fd.AddExtension = value;
            }
        }

        public bool CheckFileExists
        {
            get
            {
                return _fd.CheckFileExists;
            }
            set
            {
                _fd.CheckFileExists = value;
            }
        }

        public bool CheckPathExists
        {
            get
            {
                return _fd.CheckPathExists;
            }
            set
            {
                _fd.CheckPathExists = value;
            }
        }

        public string DefaultExt
        {
            get
            {
                return _fd.DefaultExt;
            }
            set
            {
                _fd.DefaultExt = value;
            }
        }

        public string InitialDirectory
        {
            get
            {
                return _fd.InitialDirectory;
            }
            set
            {
                _fd.InitialDirectory = value;
            }
        }

        public string FileName
        {
            get { return _fd.FileName; }
        }

        public string[] FileNames
        {
            get { return _fd.FileNames; }
        }

        public string Filter
        {
            get
            {
                return _fd.Filter;
            }
            set
            {
                _fd.Filter = value;
            }
        }

        public string SafeFileName
        {
            get { return _fd.SafeFileName; }
        }

        public string[] SafeFileNames
        {
            get { return _fd.SafeFileNames; }
        }

        public string Title
        {
            get
            {
                return _fd.Title;
            }
            set
            {
                _fd.Title = value;
            }
        }

        public bool ValidateNames
        {
            get
            {
                return _fd.ValidateNames;
            }
            set
            {
                _fd.ValidateNames = value;
            }
        }

        public bool? ShowDialog()
        {
            return _fd.ShowDialog();
        }

        public void Reset()
        {
            _fd.Reset();
        }
    }
}
