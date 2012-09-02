using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Vocab.ViewModels;

namespace Vocab.Views
{
    /// <summary>
    /// Interaction logic for VocabView.xaml
    /// </summary>
    [Export]
    [ViewSortHint("01")]
    public partial class VocabView : UserControl
    {
        public VocabView()
        {
            InitializeComponent();
        }

        [Import(typeof(VocabViewModel))]
        public VocabViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
