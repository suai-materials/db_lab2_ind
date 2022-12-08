using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Windows.Controls;

namespace SuperDBApp;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool ReturnButtonVis { get; set; } = false;
    private bool[] _navButtonsChecked = {false, true, false, false, false};
    public bool[] NavButtonsChecked => _navButtonsChecked;


    public void ChangeToView(string comboBoxSelected)
    {
        Console.WriteLine(comboBoxSelected);
        _navButtonsChecked = new[] {false, true, false, false, false};
        NotifyPropertyChanged("NavButtonsChecked");
        if (Constants.Frame.CanGoBack || Constants.Frame.CanGoForward) Constants.Frame.RemoveBackEntry();
        Constants.Frame.Navigate(new TableView(comboBoxSelected));
    }

    public void ChangeToAddTable(string comboBoxSelected)
    {
        _navButtonsChecked = new[] {true, false, false, false, false};
        NotifyPropertyChanged("NavButtonsChecked");
        if (Constants.Frame.CanGoBack || Constants.Frame.CanGoForward) Constants.Frame.RemoveBackEntry();

        switch (comboBoxSelected)
        {
            case "Сотрудники":
                Constants.Frame.Navigate(new AddEmployee());
                break;
            case "Компоненты":
                Constants.Frame.Navigate(new AddComponent());
                break;
            default:
                ChangeToView(comboBoxSelected);
                break;
        }
    }

    public void ChangeToQueryOne()
    {
        _navButtonsChecked = new[] {false, false, true, false, false};
        NotifyPropertyChanged("NavButtonsChecked");

        if (Constants.Frame.CanGoBack || Constants.Frame.CanGoForward) Constants.Frame.RemoveBackEntry();
        Constants.Frame.Navigate(new QueryOne());
    }

    public void ChangeToQueryTwo()
    {
        _navButtonsChecked = new[] {false, false, false, true, false};
        NotifyPropertyChanged("NavButtonsChecked");
        if (Constants.Frame.CanGoBack || Constants.Frame.CanGoForward) Constants.Frame.RemoveBackEntry();
        Constants.Frame.Navigate(new QueryTwo());
    }
    public void ChangeToQueryThree()
    {
        _navButtonsChecked = new[] {false, false, false, false, true};
        NotifyPropertyChanged("NavButtonsChecked");
        if (Constants.Frame.CanGoBack || Constants.Frame.CanGoForward) Constants.Frame.RemoveBackEntry();
        Constants.Frame.Navigate(new QueryThree());
    }
    
}