using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DbContext;

namespace SuperDBApp;

public partial class AddComponent : Page
{
    private AddComponentViewModel _addComponentViewModel = new();

    
    public AddComponent()
    {
        InitializeComponent();
        DataContext = _addComponentViewModel;
    }

    public AddComponent(Component component): this()
    {
        _addComponentViewModel = new AddComponentViewModel(component);
        DataContext = _addComponentViewModel;
        TypeCombo.SelectedItem = Constants.DbDataContext.Types.First(p => component.TypeId == p.Id).Name;
        ManuCombo.SelectedItem = Constants.DbDataContext.Manufacturers.First(manufacturer  => component.ManufacturerId == manufacturer.Id).Name;
        CountryCombo.SelectedItem = Constants.DbDataContext.Countries.First(country => country.Id == component.ManCountry).Name;
        _addComponentViewModel.Date = DateTime.Parse(component.ReleaseDate);

        SubmitButton.Content = "Сохранить";
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