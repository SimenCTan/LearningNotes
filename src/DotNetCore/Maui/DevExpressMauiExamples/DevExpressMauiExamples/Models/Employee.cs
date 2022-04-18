using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressMauiExamples.Models;

public class Employee
{
    string name;
    string resourceName;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            if (Photo == null)
            {
                resourceName = "DataGridExample.Images." + value.Replace(" ", "_") + ".jpg";
                if (!String.IsNullOrEmpty(resourceName))
                    Photo = ImageSource.FromResource(resourceName);
            }
        }
    }

    public Employee(string name)
    {
        this.Name = name;
    }

    public ImageSource Photo { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public AccessLevel Access { get; set; }
    public bool OnVacation { get; set; }
}
public enum AccessLevel
{
    Admin,
    User
}

