using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.BusinessLogic;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;


namespace LibraryApp.View
{
    public partial class AdminHome : Window
    {
        private readonly Client _client;
        private List<Book> _books;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private readonly SearchEngine searchEngine;
        private Filters filterButton;
        private readonly List<Branch> _branches;

        public AdminHome(Client client)
        {
            this._client = client;
            InitializeComponent();
            _books = _serviceClient.BooksList();
            _branches = _serviceClient.ViewBranches();
            BooksView.ItemsSource = _books;
            searchEngine = new SearchEngine(_books);
            BranchComboBox.ItemsSource = _branches;
        }


        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            var addBookPage = new AddBook();
            addBookPage.Closed += AddBook_Close;
            addBookPage.ShowDialog();
            BooksView.Items.Refresh();

        }

        private void AddBook_Close(object sender, EventArgs e)
        {
            if ((sender as Window)?.DialogResult == true)
            {
                _books = _serviceClient.BooksList();
                BooksView.ItemsSource = null;
                BooksView.ItemsSource = _books;

            }
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfilePage = new MyProfilePageAdmin(_client);
            myProfilePage.Show();
            this.Close();
        }

        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var viewUsers = new ViewUsers(_client);
            viewUsers.Show();
            this.Close();

        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var deleteBookPage = new DeleteBook(selectedBook);
            deleteBookPage.Show();

        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var updateBookPage = new UpdateBook(selectedBook);
            updateBookPage.Closed += UpdateBookPage_Closed;
            updateBookPage.ShowDialog();
            BooksView.Items.Refresh();

        }

        private void UpdateBookPage_Closed(object sender, EventArgs e)
        {
            if ((sender as Window)?.DialogResult == true)
            {
                BooksView.ItemsSource = _books;
            }

        }

        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var branchPage = new AddBranch();
            branchPage.Show();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem) sender;
            BooksView.SelectedItem = lvi.DataContext;
        }

        private void ViewBranchesBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewBranchesPage = new ViewBranches();
            viewBranchesPage.Show();
        }

        private void ButtonAddInBranch_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var selectBranchPage = new ChooseBranch(selectedBook);
            selectBranchPage.Show();
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
            {
                var filterButton = (Filters) ComboBoxFilter.SelectedIndex;
                if (filterButton < 0)
                {
                    MessageBox.Show("Please select a filter");
                }
                else if(filterButton < (Filters) 3)
                {
                    var filter = new SearchFilter {Name = (DataModel.Enums.Filters) filterButton, Term = SearchTextBox.Text};
                    var results = searchEngine.Search(filter);
                    BooksView.ItemsSource = results;
                    BooksView.Items.Refresh();
                }
                else if (BranchComboBox.SelectedIndex > 0)
                {
                    var result = _serviceClient.GetBooksFromBranch(_branches[BranchComboBox.SelectedIndex].Name);
                    BooksView.ItemsSource = result;
                    BooksView.Items.Refresh();
                }
            }



        private void ListViewItem2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ComboBoxItem)sender;
            BranchComboBox.SelectedItem = lvi.DataContext;
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
            {
                var messageBoxResult =
                    MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);

                if (messageBoxResult != MessageBoxResult.Yes) return;
                var main = new MainWindow();
                this.Close();
                main.Show();
            }

        private void Report_OnClick(object sender, RoutedEventArgs e)
        {
            var reportWindow = new ReportWindow(_client);
            reportWindow.Show();
            Close();
        }
    }
    }

