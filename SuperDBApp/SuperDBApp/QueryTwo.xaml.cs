using System.Linq;
using System.Windows.Controls;

namespace SuperDBApp;

public partial class QueryTwo : Page
{
    public QueryTwo()
    {
        InitializeComponent();
        ManufactureCombo.ItemsSource = Constants.DbDataContext.Manufacturers
            .Select(manufacturer => $"{manufacturer.Id} {manufacturer.Name}").ToList();
    }

    private void ManufactureChanged(object sender, SelectionChangedEventArgs e)
    {
        var id = int.Parse((sender as ComboBox).SelectedItem.ToString()!.Split(' ')[0]);
        DataGrid.ItemsSource = Constants.DbDataContext.Components.Where(component =>  component.ManufacturerId == id).ToList();
    }
}