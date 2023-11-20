using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace LoginTest.Views.Pages;

public partial class Paklijst : ContentPage
{
    public Paklijst()
    {
        InitializeComponent();

        // Sample data for the DataGrid
        var data = new ObservableCollection<Person>
            {
                new Person { Name = "John Doe", Age = 25 },
                new Person { Name = "Jane Smith", Age = 30 },
                // Add more data as needed
            };

        dataGrid.ItemsSource = data;
    }

    // Define a simple Person class for the sample data
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        // Add more properties as needed
    }

}