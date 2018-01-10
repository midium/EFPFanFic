using EFPFanFic.Business.Scapers;
using EFPFanFic.UI.Dialogs;
using EFPFanFic.UI.Dialogs.ViewModel;
using EFPFanFic.UI.Pages;
using EFPFanFic.UI.Pages.ViewModels;
using EFPFanFic.UI.Selectors.CategorySelector.ViewModels;
using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
using Midium.Helpers.ApplicationHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFPFanFic.Business.Boot
{
    public class AppStartup
    {

        private const string _windowTitle = "EFP Fan Fiction {0}";
        private const string _windowTitleCategory = " - [{0}]";
        private ScrapersManager _scrapersManager;

        private PagesHelper _pagesHelper;
        private MainWindow _mainWindow;
        private MainPage _mainPage;

        private CategorySelectorViewModel _categorySelectorViewModel;
        private MainPageViewModel _mainPageViewModel;

        private SplashScreenViewModel _splashData;
        private SplashScreen _splash;

        internal void Initialize()
        {
            _splashData = new SplashScreenViewModel(AppInfo.GetApplicationVersion(), "Loading pages scrapers...");
            _splash = new SplashScreen(_splashData);
            _splash .Show();

            _scrapersManager = new ScrapersManager();

            _splashData.Message = "Initializing main window...";
            _mainWindow = new MainWindow();
            _pagesHelper = new PagesHelper();

        }

        private UserControl InitiateMainPage()
        {
            _categorySelectorViewModel = new CategorySelectorViewModel();
            _mainPageViewModel = new MainPageViewModel(_categorySelectorViewModel, _scrapersManager);
            _mainPage = new MainPage(_mainPageViewModel);
            _mainPage.CategorySelectionChanged += _mainPage_CategorySelectionChanged;

            return _mainPage;
        }

        private void _mainPage_CategorySelectionChanged(CategoryItemDTO category)
        {
            _pagesHelper.WindowTitle = string.Format(_windowTitle, string.Format(_windowTitleCategory, category.CategoryName));
            _mainPageViewModel.CurrentCategoryViewModel = _mainPageViewModel.GetCategoryPage();
        }

        internal void Boot()
        {
            _mainWindow.DataContext = _pagesHelper;

            _splashData.Message = "Preparing main window...";
            _pagesHelper.WindowTitle = string.Format(_windowTitle, string.Empty);
            _pagesHelper.CurrentPageViewModel = InitiateMainPage();

            _splashData.Message = "Reading categories from EPF website...";
            _mainPageViewModel.CategorySelector.Categories = _scrapersManager.GetFanFicCategories();

            _splashData.Message = "Initialization completed.";
            _splash.Close();

            _mainWindow.Show();
           
        }
    }
}
