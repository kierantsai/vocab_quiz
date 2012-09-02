using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace VocabQuiz.Infrastructure.InteractionRequest
{
    public abstract class ModalWindowBase : Window
    {
        protected ModalWindowBase()
            : base()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.MinWidth = 320;
            this.MinHeight = 120;
        }

        public static readonly DependencyProperty MessageTemplateProperty = DependencyProperty.Register(
            "MessageTemplate",
            typeof(DataTemplate),
            typeof(ModalWindowBase),
            new PropertyMetadata(null)
            );

        public DataTemplate MessageTemplate
        {
            get
            {
                return GetValue(MessageTemplateProperty) as DataTemplate;
            }
            set
            {
                SetValue(MessageTemplateProperty, value);
            }
        }
    }
}
