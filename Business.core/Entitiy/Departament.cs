using System;

using Business.core.Entity;
using Business.core.Intefaces;

namespace Business.core.Entitiy;



public class Departament : IEntity
{
	private static int Counter = 0;
	public string Name { get; set; }
	public int Employeelimit { get; set; }
	public int CompanyId { get; set; }
	public int ID { get; }
	public DepartamentType Type { get; set; }

	public Departament()
	{
		ID = Counter++;
	}
	public Departament(string name, int employeelimit, int companyId,DepartamentType type):this()
	{
		//if (Employeelimit <= 0)
		//{
		//	throw new ArgumentException("Employee limit cannot negativ and zero");
		//}
		
		Name = name;
		Employeelimit = employeelimit;
		CompanyId = companyId;
		Type = type;
	}
	public void AddEmployee(Entity.Employee employee)
	{
		Employeelimit--;
		if (Employeelimit < 0)
		{
			throw new CapacityLimitException("Max Employe limit exceeded");
		}
        employee.DepartamenId = ID;

    }

    public void UpdateDepartament(string newName, int employeelimit)
	{
		if (string.IsNullOrEmpty(newName) || employeelimit <= 0)
		{
			throw new ArgumentException("Invalid departamen information");
		}
		Name = newName;
		Employeelimit = employeelimit;
	}

	public override string ToString()
	{
		return $"ID={ID}|Name={Name}";
	}
	
}
public enum DepartamentType { Building=1,Tourism,Engineering}

public class CapacityLimitException : Exception
{

    public CapacityLimitException(String message) : base(message)
    {

    }
}
