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
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;

namespace EFPFanFic.UI.Selectors.SubCategorySelector
{
    /// <summary>
    /// Interaction logic for SubCategoryItem.xaml
    /// </summary>
    public partial class SubCategoryItem : UserControl
    {
        private SubCategoryItemDTO _subCatItem;

        public SubCategoryItem()
        {
            InitializeComponent();
        }

        public SubCategoryItemDTO GetSubCategoryItemData {
            get
            {
                if(_subCatItem == null)
                    _subCatItem = (SubCategoryItemDTO)this.DataContext;

                if (_subCatItem != null)
                    return _subCatItem;

                return null;
            }
        }
        
        #region Control Dependency Properties
        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached(
            "IsSelected", typeof(bool), typeof(SubCategoryItem), new PropertyMetadata(false));
        #endregion
    }
}
