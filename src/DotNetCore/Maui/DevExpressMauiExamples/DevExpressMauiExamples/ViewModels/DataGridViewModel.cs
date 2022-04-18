using DevExpressMauiExamples.ExampleData;
using DevExpressMauiExamples.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressMauiExamples.ViewModels;

public class DataGridViewModel : INotifyPropertyChanged
{
    readonly EmployeeData data;

    public event PropertyChangedEventHandler PropertyChanged;
    public IReadOnlyList<Employee> Employees { get => data.Employees; }

    public DataGridViewModel()
    {
        data = new EmployeeData();
    }

    protected void RaisePropertyChanged(string name)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}

