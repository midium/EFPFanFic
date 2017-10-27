using EFPFanFic.UI.Pages.ViewModels;
using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
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

namespace EFPFanFic.UI.Pages
{
    /// <summary>
    /// Interaction logic for FanFicsPage.xaml
    /// </summary>
    public partial class FanFicsPage : UserControl
    {

        private FanFicPageViewModel _fanFicPageViewModel;

        public FanFicsPage(FanFicPageViewModel fanFicPageViewModel)
        {
            InitializeComponent();
            _fanFicPageViewModel = fanFicPageViewModel;
            this.DataContext = _fanFicPageViewModel;
        }

    }
}
