using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace VocabQuiz.Infrastructure.InteractionRequest
{
    public class ModalWindowAction : TriggerAction<System.Windows.DependencyObject>
    {
        public ModalWindowAction()
            : base()
        {
        }

        public static readonly DependencyProperty ModalWindowFactoryProperty = DependencyProperty.Register(
            "ModalWindowFactory",
            typeof(IModalWindowFactory),
            typeof(ModalWindowAction),
            new PropertyMetadata(null)
            );

        public IModalWindowFactory ModalWindowFactory
        {
            get
            {
                return GetValue(ModalWindowFactoryProperty) as IModalWindowFactory;
            }
            set
            {
                SetValue(ModalWindowFactoryProperty, value);
            }
        }

        public static readonly DependencyProperty ContentTemplateProperty = DependencyProperty.Register(
            "ContentTemplate",
            typeof(DataTemplate),
            typeof(ModalWindowAction),
            new PropertyMetadata(null)
            );

        public DataTemplate ContentTemplate
        {
            get
            {
                return GetValue(ContentTemplateProperty) as DataTemplate;
            }
            set
            {
                SetValue(ContentTemplateProperty, value);
            }

        }

        protected override void Invoke(object parameter)
        {
            var args = parameter as InteractionRequestedEventArgs;
            
            if (args == null || this.ModalWindowFactory == null)
            {
                return;
            }

            ModalWindowBase modalWindow = this.ModalWindowFactory.CreateModalWindow();
            modalWindow.MessageTemplate = this.ContentTemplate;
            modalWindow.DataContext = args.Context;

            if (modalWindow.ShowDialog() == true)
            {
                Debug.WriteLine("Invoking Callback");

                args.Callback.Invoke();
            }
        }
    }
}
