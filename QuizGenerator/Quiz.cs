using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace QuizGenerator
{
    public class Quiz
    {
        private ObservableCollection<string> _question;
        private IDictionary<string, ObservableCollection<string>> _choices;

        public Quiz()
        {
        }
    }
}
