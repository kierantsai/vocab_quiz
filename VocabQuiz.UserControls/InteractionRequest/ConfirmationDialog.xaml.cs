using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VocabQuiz.Infrastructure.InteractionRequest;

namespace VocabQuiz.UserControls.InteractionRequest
{
    /// <summary>
    /// Interaction logic for ConfirmationDialog.xaml
    /// </summary>
    public partial class ConfirmationDialog : ModalWindowBase
    {
        public ConfirmationDialog()
            : base()
        {
            InitializeComponent();
        }
    }
}
