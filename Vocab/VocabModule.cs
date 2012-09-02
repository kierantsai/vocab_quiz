using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Vocab
{
    [ModuleExport(typeof(VocabModule), DependsOnModuleNames = new string[] { "ServiceModule" })]
    public class VocabModule : IModule
    {
        private IRegionManager _regionManager;
        private IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public VocabModule(IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            _regionManager = regionManager;
            _serviceLocator = serviceLocator;
        }

        public void Initialize()
        {
            this._regionManager.RegisterViewWithRegion(
                "MainRegion",
                typeof(Vocab.Views.VocabView)
                );
        }
    }
}
