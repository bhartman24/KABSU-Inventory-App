﻿using System;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private string owner = "*";
        private string breed = "*";
        private string animalName = "*";
        private string code = "*";
        private string canNum = "*";
        private string town = "*";
        private string state = "*";
        private SearchResults searchResults;
        private SearchTerm searchTerm;

        InventoryPage inventoryPage;

        SearchWindowResults windowResults;
        public SearchWindow()
        {
            InitializeComponent();
        }
         
        
        private void UxSearchTerm1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Upon clicking "Search," opens a search results window and closes this window
        private void UxSearch_Click(object sender, RoutedEventArgs e)
        {
            windowResults = new SearchWindowResults(CalculateResultList());
            windowResults.ShowDialog();
            this.Close();
        }

        private void UxUnitSum_Click(object sender, RoutedEventArgs e)
        {
            List<SearchResult> results = CalculateResultList();
            int unitSum = 0;
            foreach (SearchResult sr in results)
            {
                unitSum += Convert.ToInt32(sr.Units);
            }
            MessageBox.Show("Sum of Units: " + unitSum);
        }
        private void UxInventoryList_Click(object sender, RoutedEventArgs e)
        {
            inventoryPage = new InventoryPage(CalculateInventoryList());
            inventoryPage.ShowDialog();
            this.Close();
        }

        void SetTerm(string term, string contents)
        {
            switch (term)
            {
                case "Owner":
                    owner = "%" + contents + "%";
                    break;
                case "Breed":
                    breed = "%" + contents + "%";
                    break;
                case "Animal Name":
                    animalName = "%" + contents + "%";
                    break;
                case "Code":
                    code = "%" + contents + "%";
                    break;
                case "Can #":
                    canNum = "%" + contents + "%";
                    break;
                case "Town":
                    town = "%" + contents + "%";
                    break;
                case "State":
                    state = "%" + contents + "%";
                    break;
            }
        }

        public List<SearchResult> CalculateResultList()
        {
            SetTerm(uxSearchTerm1.Text, uxSearchContents1.Text);
            SetTerm(uxSearchTerm2.Text, uxSearchContents2.Text);
            SetTerm(uxSearchTerm3.Text, uxSearchContents3.Text);
            SetTerm(uxSearchTerm4.Text, uxSearchContents4.Text);

            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchResults = new SearchResults();
            List<SearchResult> results = searchResults.retrieveData(searchTerm);
            return results;
        }

        public List<string> CalculateInventoryList()
        {
            SetTerm(uxSearchTerm1.Text, uxSearchContents1.Text);
            SetTerm(uxSearchTerm2.Text, uxSearchContents2.Text);
            SetTerm(uxSearchTerm3.Text, uxSearchContents3.Text);
            SetTerm(uxSearchTerm4.Text, uxSearchContents4.Text);

            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchResults = new SearchResults();
            List<SearchResult> results = searchResults.retrieveData(searchTerm);
            List<string> description = new List<string>();
            //description.Add("");
            foreach (SearchResult s in results)
            {
                description.Add(s.ToString());
            }
            //description.Add("");
            //description.Add("");
            //description.Add("");
            
            return description;
        }
    }
}
