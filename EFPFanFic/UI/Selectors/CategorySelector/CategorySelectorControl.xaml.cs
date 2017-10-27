using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace EFPFanFic.UI.Selectors.CategorySelector
{
    /// <summary>
    /// Interaction logic for CategorySelectorControl.xaml
    /// </summary>
    public partial class CategorySelectorControl : UserControl
    {
        public event Action<CategoryItemDTO> CategorySelectionChanged;

        public CategorySelectorControl()
        {
            InitializeComponent();
        }

        private void CategoryItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(sender is CategoryItem)
            {
                CategoryItem ci = sender as CategoryItem;
                ci.IsSelected = true; // TODO: disable any previously selected category (maybe it will worth to style a radio button as a toggle with a custom design)

                if (CategorySelectionChanged != null)
                    CategorySelectionChanged(ci.GetCategoryItemData);
            }
        }
    }
}
