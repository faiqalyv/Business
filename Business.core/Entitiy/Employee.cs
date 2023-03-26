using System;
using Business.core.Intefaces;

namespace Business.core.Entity;

public class Employee : IEntity
{
    public decimal Salary { get; set; }
    public int ID { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int? DepartamenId { get; set; }
    private static int Counter = 0;

    public Employee()
    {
        ID = Counter++;
    }

    public Employee(string name,string surname,decimal salary,int? depertamentId):this()
    {
        Name = name;
        Surname = surname;
        Salary = salary;
        DepartamenId = depertamentId;
    }

    public override string ToString()
    {
        return $"ID={ID}|Name={Name}|Surname={Surname}|Salary={Salary}";
    }
}

