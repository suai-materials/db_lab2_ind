using System.Linq;
using System.Security.Cryptography;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace SuperDBApp;

public partial class QueryOne : Page
{
    /**
     *  Отобразить заказы отдельных заказчиков;
     */
    public QueryOne()
    {
        InitializeComponent();
        CustomerCombo.ItemsSource = Constants.DbDataContext.Customers.Select(customer =>
            $"{customer.Id}, {customer.LastName} {customer.FirstName} {customer.SecondName}").ToList();
        DataGrid.ItemsSource = Constants.DbDataContext.Customers.Join(Constants.DbDataContext.Orders, customer => customer.Id,
            order => order.CustomerId, (customer, order) => new
            {
                CustomerName = $"{customer.Id}, {customer.LastName} {customer.FirstName} {customer.SecondName}",
                OrderDate = order.OrderDate,
                DueDate = order.DueDate,
                Warranty = order.GeneralWarranty

            }).ToList();
    }

    private void Customer_Changed(object sender, SelectionChangedEventArgs e)
    {
        var id = int.Parse((sender as ComboBox).SelectedItem.ToString()!.Split(',')[0]);
        DataGrid.ItemsSource = Constants.DbDataContext.Orders.Where(order => order.CustomerId == id).ToList();
    }
}