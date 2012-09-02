using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocabQuiz.Infrastructure.DialogServices
{
    public interface IFileDialogService : ICommonDialogueService
    {
        bool AddExtension
        {
            get;
            set;
        }

        bool CheckFileExists
        {
            get;
            set;
        }

        bool CheckPathExists
        {
            get;
            set;
        }

        string DefaultExt
        {
            get;
            set;
        }

        string InitialDirectory
        {
            get;
            set;
        }

        string FileName
        {
            get;
        }

        string[] FileNames
        {
            get;
        }

        string Filter
        {
            get;
            set;
        }

        string SafeFileName
        {
            get;
        }

        string[] SafeFileNames
        {
            get;
        }

        string Title
        {
            get;
            set;
        }

        bool ValidateNames
        {
            get;
            set;
        }
    }
}
