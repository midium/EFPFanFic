using EFPFanFic.UI.Dialogs.Items.ViewModel;
using EFPFanFic.UI.Dialogs.ViewModel;
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
using System.Windows.Shapes;

namespace EFPFanFic.UI.Dialogs
{
    /// <summary>
    /// Interaction logic for RunningThreads.xaml
    /// </summary>
    public partial class RunningThreads : Window
    {
        public RunningThreads(RunningThreadsViewModel vm)
        {
            InitializeComponent();

            Header.DataContext = new ThreadEntryViewModel(0, "Fan Fiction", "Start At");
            this.DataContext = vm;
        }
    }
}
