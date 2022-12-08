using System.Linq;
using System.Windows.Controls;
using DbContext;

namespace SuperDBApp;

public partial class QueryThree : Page
{
    public QueryThree()
    {
        InitializeComponent();
        Employee employee = Constants.DbDataContext.Employees.AsEnumerable().MaxBy(emp =>
            Constants.DbDataContext.Positions.First(position => position.Id == emp.PositionId).Salary)!;
        Position position = Constants.DbDataContext.Positions.First(position => position.Id == employee.PositionId);
        TextBlock.Text = $"Самая больщая зарплата у \"{employee.LastName} {employee.FirstName} {employee.SecondName}\" на должности \"{position.Name}\", c зарплатой {position.Salary} рублей";
    }
}