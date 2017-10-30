using EFPFanFic.UI.Pages.ViewModels;
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
                MainPageViewModel viewModel = this.DataContext as MainPageViewModel;
                if (viewModel != null && ci != null)
                    foreach (CategoryItemDTO category in viewModel.CategorySelector.Categories)
                        category.IsSelectedCategory = (category.CategoryName == ci.GetCategoryItemData?.CategoryName);

                if (CategorySelectionChanged != null && ci != null)
                    CategorySelectionChanged(ci.GetCategoryItemData);
            }
        }
    }
}
