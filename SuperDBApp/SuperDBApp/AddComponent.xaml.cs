using System;
using System.Windows;
using System.Windows.Controls;

namespace SuperDBApp;

public partial class AddComponent : Page
{
    private AddComponentViewModel _addComponentViewModel = new();

    
    public AddComponent()
    {
        InitializeComponent();
        DataContext = _addComponentViewModel;
    }

    private void TypeSelected(object sender, SelectionChangedEventArgs e)
    {
        _addComponentViewModel.SetType((string) ((ComboBox) sender).SelectedItem);
    }

    private void ManufactureSelected(object sender, SelectionChangedEventArgs e)
    {
        _addComponentViewModel.SetMan((string) ((ComboBox) sender).SelectedItem);
    }

    private void CountrySelected(object sender, SelectionChangedEventArgs e)
    {
        _addComponentViewModel.SetManCountry((string) ((ComboBox) sender).SelectedItem);
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        _addComponentViewModel.Add();
    }

    private void DateChanged(object? sender, SelectionChangedEventArgs e)
    {
        _addComponentViewModel.SetDate((sender as Calendar).SelectedDate);
    }
}