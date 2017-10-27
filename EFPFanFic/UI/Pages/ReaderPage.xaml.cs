using EFPFanFic.UI.Pages.ViewModels;
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
    /// Interaction logic for ReaderPage.xaml
    /// </summary>
    public partial class ReaderPage : UserControl
    {
        private ReaderPageViewModel _pageReader;

        public ReaderPage(ReaderPageViewModel pageReader)
        {
            InitializeComponent();
            _pageReader = pageReader;
            DataContext = _pageReader;
        }

        private void FontSizeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FanFicText.FontSize = (int)FontSizeSelector.SelectedValue;
        }
    }
}
