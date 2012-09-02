using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;

namespace VocabQuiz
{
    public class VocabQuizBootStrapper : MefBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = this.Shell as Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            
            this.AggregateCatalog.Catalogs.Add(
                new AssemblyCatalog(typeof(VocabQuizBootStrapper).Assembly)
                );
            
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog()
            {
                ModulePath = @".\Modules\"
            };
        }
    }
}
