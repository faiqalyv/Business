using System;
namespace Infrastructure.Services;

using System.Xml.Linq;
using Business.core.Entitiy;
using Business.core.Entity;
using Business.core.Intefaces;
using Infrastructure.DBcontext;
using Infrastructure.Utilities.Exceptions;

public class DepartamentService
{
	private static int indexcounter = 0;

	public void Create(string?name,int employeelimit,int companyId,int type)
	{
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;

        for (int i = 0; i < indexcounter; i++)
        {
            if (AppDBcontext.departaments[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true;
                break;
            }
        }
        if (isExist)
        {
            throw new Dublicatenameexception("This Departament name already exits");
        }
        DepartamentType departamentType;

        if (Enum.IsDefined(typeof(DepartamentType), type))
        {
            departamentType = (DepartamentType)type;
        }
        else
        {
            throw new NotExistException("Select correct Departament type");
        }

        bool companyExist = false;
        foreach (var company in AppDBcontext.companies)
        {
            if (company.ID == companyId)
            {
                companyExist = true;
                break;
            }
        }

        if (!companyExist)
        {
            throw new NameNotFound("Company with this ID does not exist!");
        }

        Departament new_departament = new(name,employeelimit,companyId,departamentType);
        AppDBcontext.departaments[indexcounter++] = new_departament;

    }

    public void GetAll()
    {
        for (int i = 0; i < indexcounter; i++)
        {

        
        var tem_company = string.Empty;

        foreach (var company in AppDBcontext.companies)
        {
                if (company is null) break; 
                if (AppDBcontext.departaments[i].CompanyId == company.ID)
                {
                    tem_company = company.Name;

                    break;
                }

        }
           Console.WriteLine($"Id:{ AppDBcontext.departaments[i].ID}"  + 
                $" Name:{ AppDBcontext.departaments[i].Name}" +  
                 $" Limit:{ AppDBcontext.departaments[i].Employeelimit}" + 
                 $" CompanyId:{ tem_company}");
        }
    }

    public Departament GetDepartament(string name)
    {
        for (int i = 0; i < indexcounter; i++)
        {

            if (AppDBcontext.departaments[i].Name == name)
            {
                return AppDBcontext.departaments[i];
            }
        }

        throw new NameNotFound("Depertament with this name not found");
        
    }

    public void GetDepartmentEmployees(string departmentName)
    {
        bool isFound = false;

        for (int i = 0; i < indexcounter; i++)
        {
            if (AppDBcontext.departaments[i].Name == departmentName)
            {
                Console.WriteLine("Employees: ");
                foreach (var emp in AppDBcontext.employees)
                {
                    if (emp is null)
                    {
                        continue;
                    }
                    if (emp.DepartamenId == AppDBcontext.departaments[i].ID)
                    {
                        Console.WriteLine(emp.Name);
                    }
                }
                isFound = true;
            }
        }

        if (!isFound)
        {
            throw new NameNotFound("Departament with this name does not exit");
        }

    }
}


