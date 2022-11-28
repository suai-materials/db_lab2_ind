using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DbContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SuperDBApp;

public class AddComponentViewModel
{
    public List<string> Types { get; set; } = Constants.DbDataContext.Types.Select(s => s.Name).ToList();
    public List<string> Manufactures { get; set; } = Constants.DbDataContext.Manufacturers.Select(s => s.Name).ToList();
    public List<string> Countries { get; set; } = Constants.DbDataContext.Countries.Select(s => s.Name).ToList();
    public DateTime Date { get; set; } = DateTime.Now;

    public Component NewComponent { get; set; } = new();

    public AddComponentViewModel()
    {
    }

    public AddComponentViewModel(Component newComponent)
    {
        NewComponent = newComponent;
    }

    public void SetType(string typeName)
    {
        NewComponent.TypeId = Constants.DbDataContext.Types.First(s => s.Name == typeName).Id;
    }

    public void SetMan(string manName)
    {
        NewComponent.ManufacturerId = Constants.DbDataContext.Manufacturers.First(p => p.Name == manName).Id;
    }

    public void SetManCountry(string countryName)
    {
        NewComponent.ManCountry = Constants.DbDataContext.Countries.First(p => p.Name == countryName).Id;
    }

    public void Add()
    {
        try
        {
            if (NewComponent.Id != 0)
                Constants.DbDataContext.Components.Update(NewComponent);
            else
                Constants.DbDataContext.Components.Add(NewComponent);
            Constants.DbDataContext.SaveChanges();
            Constants.MainWindowViewModel.ChangeToView("Компоненты");
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            switch ((e.InnerException! as SqliteException)!.SqliteErrorCode)
            {
                case 19:
                    MessageBox.Show(
                        $"Какое-то поле указано неверно.\nПодробная ошибка: {(e.InnerException as SqliteException)!.Message}");
                    break;
            }
        }
    }

    public void SetDate(DateTime? selectedDate)
    {
        if (selectedDate is null) return;
        NewComponent.ReleaseDate = selectedDate!.Value.ToShortDateString();
    }
}