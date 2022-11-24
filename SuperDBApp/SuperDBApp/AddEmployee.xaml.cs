using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DbContext;

namespace SuperDBApp;

public partial class AddEmployee : Page
{
    private AddEmployeeViewModel _addEmployeeViewModel = new();
    public AddEmployee()
    {
        InitializeComponent();
        DataContext = _addEmployeeViewModel;
    }

    public AddEmployee(Employee employee): this()
    {
        _addEmployeeViewModel = new AddEmployeeViewModel(employee);
        DataContext = _addEmployeeViewModel;
        PositionComboBox.SelectedItem = Constants.DbDataContext.Positions.First(p => employee.PositionId == p.Id).Name;
        SexComboBox.SelectedItem = Constants.DbDataContext.Sexes.First(s => employee.Sex == s.Id).Name;
        SubmitButton.Content = "Сохранить";
    }

    private void Sex_Selected(object sender, SelectionChangedEventArgs e)
    {
        _addEmployeeViewModel.SetSex((String) ((ComboBox) sender).SelectedItem);
    }

    private void Position_Selected(object sender, SelectionChangedEventArgs e)
    {
        _addEmployeeViewModel.SetPosition((String) ((ComboBox) sender).SelectedItem);
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        _addEmployeeViewModel.Add();
    }
}