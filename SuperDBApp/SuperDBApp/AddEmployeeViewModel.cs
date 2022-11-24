using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DbContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SuperDBApp;

public class AddEmployeeViewModel
{
    public List<String> Sexes { get; set; } = Constants.DbDataContext.Sexes.Select(s => s.Name).ToList();
    public List<String> Positions { get; set; } = Constants.DbDataContext.Positions.Select(s => s.Name).ToList();
    public Employee NewEmployee  { get; set; } = new Employee();

    public AddEmployeeViewModel()
    {
    }
    
    public AddEmployeeViewModel(Employee newEmployee)
    {
        NewEmployee = newEmployee;
    }

    public void SetSex(string sexName)
    {
        NewEmployee.Sex = Constants.DbDataContext.Sexes.First(s => s.Name == sexName).Id;
    }

    public void SetPosition(string positionName)
    {
        NewEmployee.PositionId = Constants.DbDataContext.Positions.First(p => p.Name == positionName).Id;
    }

    public void Add()
    {
        try
        {
            if (NewEmployee.Id != 0)
            {
                Constants.DbDataContext.Employees.Update(NewEmployee);
            }
            else
            {
                Constants.DbDataContext.Employees.Add(NewEmployee);
            }
            Constants.DbDataContext.SaveChanges();
            Constants.MainWindowViewModel.ChangeToView("Сотрудники");
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            switch ((e.InnerException! as SqliteException )!.SqliteErrorCode)
            {
                case 19:
                    MessageBox.Show(
                        $"Какое-то поле указано неверно.\nПодробная ошибка: {(e.InnerException as SqliteException)!.Message}");
                    break;
            }
        }
    }
    
}