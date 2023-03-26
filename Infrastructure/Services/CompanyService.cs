using System;
using Business.core.Entitiy;
using Infrastructure.DBcontext;
using Infrastructure.Utilities.Exceptions;

namespace Infrastructure.Services;

public class CompanyService
{
	public static int indexcounter = 0;
	
	public void Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentNullException();
		}
		bool isExist = false;

		for (int i = 0; i < indexcounter; i++)
		{
			if (AppDBcontext.companies[i].Name.ToUpper() == name.ToUpper())
			{
				isExist = true;
				break;
			}
		}
		if (isExist)
		    {
				throw new Dublicatenameexception("This Company name already exits");
			}
			Company new_company = new(name);

			AppDBcontext.companies[indexcounter++] = new_company;	
		
	}
	public void GetAll()
	{
		Console.WriteLine("Companies list");
		for (int i = 0; i < indexcounter; i++)
		{
			Console.WriteLine(AppDBcontext.companies[i].ID+"-"+ AppDBcontext.companies[i].Name);
		}
	}

	public void GetAllDepartament(string comp_name)
	{
		bool isFound = false;

        for (int i = 0; i < indexcounter; i++)
        {
			if (AppDBcontext.companies[i].Name == comp_name)
			{
				Console.WriteLine("Departaments: ");
				foreach (var dep in AppDBcontext.departaments)
				{
					if (dep is null)
					{
						continue;
					}
					if (dep.CompanyId == AppDBcontext.companies[i].ID)
					{
						Console.WriteLine(dep.Name);
					}
				}
				isFound = true;
            }
        }

		if (!isFound)
		{
            throw new NameNotFound("Company with this name does not exit");
        }
        
	}
}

