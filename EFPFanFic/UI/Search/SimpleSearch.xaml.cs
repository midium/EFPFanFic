using EFPFanFic.UI.Search.Commands;
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

namespace EFPFanFic.UI.Search
{
    /// <summary>
    /// Interaction logic for SimpleSearch.xaml
    /// </summary>
    public partial class SimpleSearch : UserControl
    {
        public event Action<string> SearchItem;
        public event Action ClearSearch;

        private SearchCommand _searchCommand;

        public SimpleSearch()
        {
            InitializeComponent();
            _searchCommand = new SearchCommand();
            _searchCommand.RunCommand += _RunCommand;
        }

        private void _RunCommand()
        {
            OnSearchRequest();
        }

        private void OnSearchRequest()
        {
            if (SearchValue.Text.Trim() != string.Empty && SearchItem != null)
                SearchItem(SearchValue.Text.Trim());
        }

        public SearchCommand SearchCommand
        {
            get { return _searchCommand; }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            OnSearchRequest();
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            SearchValue.Text = string.Empty;
            if (ClearSearch != null)
                ClearSearch();
        }
    }
}
