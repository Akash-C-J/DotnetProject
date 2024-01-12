using System;
namespace  MVC1.Models
{
public class Repository{
    private static List<Employee> allEmployee = new List<Employee>();
    public static IEnumerable<Employee> AllEmployees
    {
        get{
            return allEmployee;
        }
    }
    public static void Create(Employee employee)
{
     allEmployee.Add(employee);
}
}

}