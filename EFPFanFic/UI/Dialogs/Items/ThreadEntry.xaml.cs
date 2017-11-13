using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFPFanFic.UI.Dialogs.Items
{
    /// <summary>
    /// Interaction logic for ThreadEntry.xaml
    /// </summary>
    public partial class ThreadEntry : UserControl
    {
        public ThreadEntry()
        {
            InitializeComponent();
        }

        public Visibility ActionButtonVisibility
        {
            get { return (Visibility)this.GetValue(ActionButtonVisibilityProperty); }
            set { this.SetValue(ActionButtonVisibilityProperty, value); }
        }
        public static readonly DependencyProperty ActionButtonVisibilityProperty = DependencyProperty.RegisterAttached(
            nameof(ActionButtonVisibility), typeof(Visibility), typeof(ThreadEntry), new PropertyMetadata(Visibility.Visible));

    }
}
