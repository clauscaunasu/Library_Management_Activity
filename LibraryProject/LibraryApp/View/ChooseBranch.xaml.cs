﻿using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;
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
using System.Windows.Shapes;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ChooseBranch.xaml
    /// </summary>
    public partial class ChooseBranch : Window
    {
        private List<Branch> branches;
        private static int quantity = 0;
        private string quantityStr;
        private Book _book;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public ChooseBranch(Book book)
        {
            InitializeComponent();
            branches = _serviceClient.ViewBranches();
            SelectBranchComboBox.ItemsSource = branches;
            _book = book;
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)sender;
            SelectBranchComboBox.SelectedItem = lvi.DataContext;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            quantityStr = BooksQuantityTxt.Text;
            quantity += Int16.Parse(quantityStr);
            var selectedBranch = SelectBranchComboBox.SelectedItem as Branch;
            var isSuccessful = _serviceClient.AddBookInBranch(_book, selectedBranch.Name, quantity);
            if(isSuccessful)
            {
                MessageBox.Show("Book added successfully in branch!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again");
                this.Close();
            }
        }
    }
}
