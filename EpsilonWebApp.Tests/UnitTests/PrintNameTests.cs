using EpsilonWebApp.Application.Services;
using EpsilonWebApp.Domain.Entities;

namespace EpsilonWebApp.Tests.UnitTests;

public class PrintNameTests
{
    [Fact]
    public void PrintName_WithEmployee_PrintsEmployeeName()
    {
        var printer = new Printer();
        var employee = new Employee { Name = "Nikos" };

        using var output = new StringWriter();
        Console.SetOut(output);

        printer.PrintName(employee);

        Assert.Contains("Nikos", output.ToString());
    }

    [Fact]
    public void PrintName_WithManager_PrintsManagerName()
    {
        var printer = new Printer();
        var manager = new Manager { Name = "Maria" };

        using var output = new StringWriter();
        Console.SetOut(output);

        printer.PrintName(manager);

        Assert.Contains("Maria", output.ToString());
    }

    [Fact]
    public void PrintName_WithInvalidObject_ThrowsArgumentException()
    {
        var printer = new Printer();

        Assert.Throws<ArgumentException>(() => printer.PrintName(new object()));
    }
}