using EpsilonWebApp.Domain.Entities;

namespace EpsilonWebApp.Application.Services;

public class Printer
{
    public void PrintName(object entity)
    {
        if (entity is Employee employee)
        {
            Console.WriteLine(employee.Name);
        }
        else if (entity is Manager manager)
        {
            Console.WriteLine(manager.Name);
        }
        else
        {
            throw new ArgumentException("Must be Employee or Manager.");
        }
    }
}