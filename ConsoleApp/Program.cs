using Business.core.Entitiy;
using Infrastructure.Services;
using Infrastructure.DBcontext;

using Infrastructure.Utilities.Exceptions;
using Business.core.Entity;

CompanyService companyService = new CompanyService();

DepartamentService departamentService = new DepartamentService();

EmployeeService employeeService = new EmployeeService();

Console.WriteLine("Welcome");

while (true)
{

    Console.WriteLine(
        """


        Create Company - 1 | List Companies - 2 | Get Company Departaments - 3
        Create Departament - 4 | Update Department-5| List Departaments - 6 |Add Employe- 7|Get Depertament Employees-8|
        Create Employee-9 | List Employe - 10
        Exit - 0


        """
    );
    int max_tries = 0;

    string? response = Console.ReadLine();

    int menu;

    bool trtToInt = int.TryParse(response, out menu);

    if (trtToInt)
    {
        switch (menu)
        { 
            case 0:
                Environment.Exit(0);
                break;
        
            case 1:

                Console.WriteLine("Enter Company name:");

                string?res_companyname = Console.ReadLine();

                try
                {
                    companyService.Create(res_companyname);

                    Console.WriteLine($"new company: {res_companyname}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 2:

                Console.WriteLine("Company Lists");

                companyService.GetAll();

                break;
            case 3:

                Console.WriteLine("Enter Company Name");
                string? comp_name = Console.ReadLine();

                if (comp_name is null)
                {
                    Console.WriteLine("Company name cannot be null");
                    goto case 3;
                }
                else
                {
       
                    try
                    {
                        companyService.GetAllDepartament(comp_name);
                    }

                    catch (NameNotFound ex)
                    {
                        Console.WriteLine(ex.Message);
                        max_tries++;
                        if (max_tries > 3)
                        {
                            break;
                        } else
                        {
                            goto case 3;
                        }
                   
                    }
                }
                break;
            case 4:

                Console.WriteLine("Enter Departament name");

                string? res_depertamentname = Console.ReadLine();

                Console.WriteLine("Enter MaxEmployee");

                string? MaxEmployee = Console.ReadLine();

                int employeelimit;

                bool trtToIntemployelimit = int.TryParse(MaxEmployee, out employeelimit);

                if (!trtToIntemployelimit)

                {
                    Console.WriteLine("Enter correct Format");

                    goto case 4;
                }

            select_company:

                Console.WriteLine("Enter Company (Id)");

                string? select_company = Console.ReadLine();

                int companyId;

                bool tryToIdcompany = int.TryParse(select_company,out  companyId);

                if (!tryToIdcompany)

                {
                    Console.WriteLine("Enter Correct Company Id");

                    goto select_company;
                }

            departament_type:

                Console.WriteLine("Enter Group type (number) : ");

                foreach (var departamenttype in Enum.GetValues(typeof(DepartamentType)))
                {
                    Console.WriteLine((int)departamenttype + "-" + departamenttype);
                }

                string? resType = Console.ReadLine();

                int MaxType;

                bool tryToIntType = int.TryParse(resType, out MaxType);

                if (!tryToIntType)

                {

                    Console.WriteLine("Enter correct format");

                    goto departament_type;
                }

                try
                {
                    departamentService.Create(res_depertamentname, employeelimit, companyId,MaxType);

                    Console.WriteLine("Succesfully created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 4;
                }
                break;
            case 5:
                Console.WriteLine("Enter Department name");
                string? deparname = Console.ReadLine();
                Console.WriteLine("Enter new Departament name");
                string? newdeparname = Console.ReadLine();
                Console.WriteLine("Enter new Departament Employee Limit");
                int newMaxLimit = Convert.ToInt16(Console.ReadLine());

                if (deparname is null || newdeparname is null)
                {
                    Console.WriteLine("Departament Name cannot be null");
                    goto case 5;
                }

                try
                {
                    Departament dep = departamentService.GetDepartament(deparname);

                    dep.UpdateDepartament(newdeparname, newMaxLimit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    max_tries++;
                    if (max_tries > 3)
                    {
                        break;
                    } else
                    {
                        goto case 5;
                    }
                }

                break;
            case 6:

                Console.WriteLine("Departaments lists:");

                departamentService.GetAll();

                    break;
            case 7:
                Console.WriteLine("Enter Department name");
                deparname = Console.ReadLine();
                Console.WriteLine("Enter Employee name");
                string? employeeName = Console.ReadLine();

                if (deparname is null || employeeName is null)
                {
                    Console.WriteLine("Departament or Employee Name cannot be null");
                    goto case 7;
                }

                try
                {
                    Departament dep = departamentService.GetDepartament(deparname);
                    Employee emp = employeeService.GetEmployee(employeeName);

                    dep.AddEmployee(emp);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    max_tries++;
                    if (max_tries > 3)
                    {
                        break;
                    }
                    else
                    {
                        goto case 7;
                    }
                }

                break;
            case 8:

                Console.WriteLine("Enter Depertament name");

                string? depname = Console.ReadLine();

                if (depname is null)
                {
                    Console.WriteLine("Depertament name is cannot be null");

                    goto case 8;
                }
                else
                {
                    try
                    {
                        departamentService.GetDepartmentEmployees(depname);
                    }

                    catch (NameNotFound ex)
                    {
                        Console.WriteLine(ex.Message);
                        max_tries++;

                        if (max_tries > 3)
                        {
                            break;
                        }
                        else
                        {
                            goto case 8;
                        }
                        
                    }

                }

                break;
            case 9:

                Console.WriteLine("Enter Employe Name");

                string? resempname = Console.ReadLine();

                Console.WriteLine("Enter Employe Surname");

                string? resempsurname = Console.ReadLine();

                select_salary:
                Console.WriteLine("Enter Employe Salary");

                string? resempsalary = Console.ReadLine();

                if (resempname is null || resempsurname is null || resempsalary is null)
                {
                    Console.WriteLine("Name, Surname or Salary cannot be null");
                    goto case 9;
                }

                int Salary;

                bool tryToSalary = int.TryParse(resempsalary, out Salary);

                if (!tryToSalary)
                {
                    Console.WriteLine("Enter correct to salary");

                    goto select_salary;
                }


                Console.WriteLine("Enter Depertament Id");

                string? select_depertament = Console.ReadLine();

                int depertamentId;
                int.TryParse(select_depertament, out depertamentId);

                try
                {
                    employeeService.Create(resempname, resempsurname, Salary, depertamentId);

                    Console.WriteLine("Succesfully Created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    goto case 9;
                }

                break;
            case 10:

                Console.WriteLine("Employe Lists");

                employeeService.GetAll();

                break;
            default:
                Console.WriteLine("Select correct ones from menu!");
                break;
        }
    }

    else
    {
        Console.WriteLine("Enter to correct menu");
    }

}
