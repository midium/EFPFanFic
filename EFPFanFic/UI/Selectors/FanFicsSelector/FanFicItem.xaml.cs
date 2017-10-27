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
using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;

namespace EFPFanFic.UI.Selectors.FanFicsSelector
{
    /// <summary>
    /// Interaction logic for FanFicItem.xaml
    /// </summary>
    public partial class FanFicItem : UserControl
    {
        private FanFicItemViewModel _fanFicItem;

        public FanFicItem()
        {
            InitializeComponent();
        }

        public FanFicItemViewModel GetFanFicItemData {
            get
            {
                if(_fanFicItem == null)
                    _fanFicItem = (FanFicItemViewModel)this.DataContext;

                if (_fanFicItem != null)
                    return _fanFicItem;

                return null;
            }
        }
    }
}
