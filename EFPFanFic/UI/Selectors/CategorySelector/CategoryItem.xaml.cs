using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
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

namespace EFPFanFic.UI.Selectors.CategorySelector
{
    /// <summary>
    /// Interaction logic for CategoryItem.xaml
    /// </summary>
    public partial class CategoryItem : UserControl
    {

        private CategoryItemDTO _catItem;

        public CategoryItem()
        {
            InitializeComponent();
        }

        #region Control Dependency Properties
        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached(
            "IsSelected", typeof(bool), typeof(CategoryItem), new PropertyMetadata(false));
        #endregion

        public CategoryItemDTO GetCategoryItemData
        {
            get
            {
                if(_catItem == null)
                    _catItem = (CategoryItemDTO)this.DataContext;

                if (_catItem != null)
                    return _catItem;

                return null;
            }
        }
    }
}
