using EFPFanFic.UI.Pages.ViewModels;
using EFPFanFic.UI.Selectors.CategorySelector;
using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
using System;
using System.Windows.Controls;

namespace EFPFanFic.UI.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {

        public event Action<CategoryItemDTO> CategorySelectionChanged;
        private MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            _mainPageViewModel = mainPageViewModel;
            this.DataContext = mainPageViewModel;

        }

        private void Categories_CategorySelectionChanged(CategoryItemDTO category)
        {
            _mainPageViewModel.CategoryPageViewModel.IsCategorySelected = true;
            _mainPageViewModel.CategoryPageViewModel.CategoryName = category.CategoryName;
            _mainPageViewModel.CategoryPageViewModel.SubCategorySelector.SubCategories = _mainPageViewModel.ScrapersManager.GetFanFicSubCategories(category.CategoryUri);
            if (CategorySelectionChanged != null)
                CategorySelectionChanged(category);
            
        }
    }
}
