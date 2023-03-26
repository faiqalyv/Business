using System;
using Business.core.Entity;
using Business.core.Intefaces;

namespace Business.core.Entitiy;

public class Company : IEntity
{
    private static int counter = 0;
    public string Name { get; set; }
    public int ID { get; }

    public Company()
    {
        ID = counter++;
    }
    public Company(string name):this()
    { 
        Name = name;        
    }

    public override string ToString()
    {
        return $"Id: {ID}, Name: {Name}";
    }
    
}


