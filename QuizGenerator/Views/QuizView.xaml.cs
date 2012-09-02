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
using Microsoft.Practices.Prism.Regions;
using QuizGenerator.ViewModels;

namespace QuizGenerator.Views
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    [Export]
    [ViewSortHint("02")]
    public partial class QuizView : UserControl
    {
        public QuizView()
        {
            InitializeComponent();
        }

        [Import(typeof(QuizViewModel))]
        public QuizViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
