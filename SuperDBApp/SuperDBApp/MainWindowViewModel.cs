using System;
using System.ComponentModel;
using System.Dynamic;
using System.Windows.Controls;

namespace SuperDBApp;

public class MainWindowViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public bool ReturnButtonVis { get; set; } = false;
    private bool[] _navButtonsChecked = {false, true};
    public bool[] NavButtonsChecked
    {
        get => _navButtonsChecked;
    }

    public void ChangeToView(string comboBoxSelected)
    {
        Console.WriteLine(comboBoxSelected);
        _navButtonsChecked = new[] {false, true};
        NotifyPropertyChanged("NavButtonsChecked");
        if (Constants.Frame.CanGoBack || Constants.Frame.CanGoForward)
        {
            Constants.Frame.RemoveBackEntry();
        }
        Constants.Frame.Navigate(new TableView(comboBoxSelected));
    }
    
    public void ChangeToAddTable()
    {
        _navButtonsChecked = new[] {true, false};
        NotifyPropertyChanged("NavButtonsChecked");
    }
}