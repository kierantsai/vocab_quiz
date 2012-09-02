using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.ViewModel;

namespace VocabQuiz.ViewModel
{
    [Export(typeof(ShellViewModel))]
    class ShellViewModel : NotificationObject
    {
    }
}
