using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DbContext;
using Microsoft.EntityFrameworkCore;

namespace SuperDBApp;

public static class Constants
{
    public static DbDataContext DbDataContext = new();

    public static Dictionary<string, string> NameToTableName = new()
    {
        {"Сотрудники", "Employees"}, 
        {"Компоненты", "Components"},
        {"Должности", "Positions"},
        {"Заказы", "Order"},
        {"Сервисы", "Services"},
        {"Заказчики и их заказы", "CustomerOrders"},
        {"Производитель и компоненты", "Manufacture2Components"}
    };

    public static Frame Frame = new Frame();
    public static MainWindowViewModel MainWindowViewModel = new();
}