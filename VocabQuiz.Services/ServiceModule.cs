using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace VocabQuiz.Services
{
    [ModuleExport(typeof(ServiceModule))]
    public class ServiceModule : IModule
    {
        public void Initialize()
        {
        }
    }
}
