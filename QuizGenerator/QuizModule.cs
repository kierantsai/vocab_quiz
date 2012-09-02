using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace QuizGenerator
{
    [ModuleExport(typeof(QuizModule), DependsOnModuleNames = new string[] { "VocabModule" })]
    public class QuizModule : IModule
    {
        private IRegionManager _regionManager;

        [ImportingConstructor]
        public QuizModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(
                "MainRegion",
                typeof(QuizGenerator.Views.QuizView)
                );
        }
    }
}
