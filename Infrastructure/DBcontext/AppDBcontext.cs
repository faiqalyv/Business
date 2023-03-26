using System;
using Business.core.Entitiy;
using Business.core.Entity;

namespace Infrastructure.DBcontext;

public static class AppDBcontext
{
    public static Employee[] employees { get; set; } = new Employee[1000];
    public static Departament[] departaments { get; set; } = new Departament[100];
    public static Company[] companies { get; set; } = new Company[10];
}

