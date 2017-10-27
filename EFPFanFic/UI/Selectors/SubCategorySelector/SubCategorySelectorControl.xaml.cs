using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
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

namespace EFPFanFic.UI.Selectors.SubCategorySelector
{
    /// <summary>
    /// Interaction logic for SubCategorySelectorControl.xaml
    /// </summary>
    public partial class SubCategorySelectorControl : UserControl
    {
        public event Action<string> SearchItem;
        public event Action ClearSearch;
        public event Action<SubCategoryItemDTO> SubCategorySelectionChanged;

        public SubCategorySelectorControl()
        {
            InitializeComponent();
        }

        private void SearchPanel_ClearSearch()
        {
            if (ClearSearch != null)
                ClearSearch();
        }

        private void SearchPanel_SearchItem(string itemName)
        {
            if (SearchItem != null)
                SearchItem(itemName);
        }

        private void SubCategoryItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is SubCategoryItem)
            {
                SubCategoryItem ci = sender as SubCategoryItem;
                ci.IsSelected = true; // TODO: disable any previously selected category (maybe it will worth to style a radio button as a toggle with a custom design)

                if (SubCategorySelectionChanged != null)
                    SubCategorySelectionChanged(ci.GetSubCategoryItemData);
            }

        }
    }
}
