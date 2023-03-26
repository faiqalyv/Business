using System;
using Business.core.Entity;
using Infrastructure.DBcontext;
using Infrastructure.Utilities.Exceptions;

namespace Infrastructure.Services;

public class EmployeeService
{
	private static int index_counter = 0;

	public void Create(string name, string surname, decimal salary, int? depertamentId)
	{
		if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
		{
			throw new ArgumentException();
		}

		if (salary <= 0)
		{
			throw new ArgumentException("Salary cannot be zero an negative");
		}

		bool isExist = false;

		for (int i = 0; i < index_counter; i++)
		{
			if (AppDBcontext.employees[i].Name.ToUpper() == name.ToUpper() && AppDBcontext.employees[i].Surname.ToUpper() == surname.ToUpper())
			{
				isExist = true;

				break;
			}
		}
		if (isExist)
		{
			throw new Dublicatenameexception("this employe name and surname already exits");
		}

		Employee new_employe = new(name, surname, salary, depertamentId);

		AppDBcontext.employees[index_counter++] = new_employe;
	}

	public Employee GetEmployee(string name)
	{
		for (int i = 0; i < index_counter; i++)
		{
			if (AppDBcontext.employees[i].Name == name)
			{
				return AppDBcontext.employees[i];
			}
		}


		throw new NameNotFound("Employe with this name not found");
	}

	public void GetAll()
	{
		for (int i = 0; i < index_counter; i++)
		{
			var temp_departament = string.Empty;

			foreach (var departament in AppDBcontext.departaments)
			{
				if (departament is null) break;

				if (AppDBcontext.employees[i].ID == departament.ID)
				{
					temp_departament = departament.Name;
				}

                Console.WriteLine($"Id:{AppDBcontext.employees[i].ID}" +
                $" Name:{AppDBcontext.employees[i].Name}" +
                 $" Surname:{AppDBcontext.employees[i]}" +
                 $" Salary: {AppDBcontext.employees[i].Salary}" +
                 $" DepertamentID:{temp_departament}");
            }
        }
	}
}
