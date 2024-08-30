using System;

namespace _05_GenericTypesAndAdvancesUseOfMethods;

/*
This class's function is to create a list of employees in various departments, each having a specific salary, and work out the
average salary per department.

The method which works out the average salaries takes a list of employees and returns a dictionary, where each key is the department and
each value is the average salary for that department.
*/
public static class DictionaryExample
{
  public static void Main()
  {
    var employees = new List<Employee>
    {
      new Employee("Tony Stark", "Space Navigation", 34000),
      new Employee("Ann Patel", "Mechanics", 24500),
      new Employee("Robert Tyrell", "Xenobiology", 27600),
      new Employee("Margaret Stoneson", "Mechanics", 28900),
      new Employee("Adam Smiste", "Xenobiology", 37500),
      new Employee("Diana Hill", "Space Navigation", 45750)
    };

    Dictionary<string, decimal> averageSalaries = CalculateAverageSalaryPerDepartment(employees);
    foreach (var keyValuePair in averageSalaries)
    {
      System.Console.WriteLine($"Department: {keyValuePair.Key}, Average Salary: {keyValuePair.Value}");
    }
  }

  public static Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(IEnumerable<Employee> employees)
  {
    var resultDictionary = new Dictionary<string, decimal>();
    var referenceDictionary = new Dictionary<string, List<Employee>>();
    string key;

    // Loop through each employee and, if their department doesnt exist in the reference dictionary, add that department as the key and create a new employee list
    // with this employee as the first element of this list.
    foreach (var employee in employees)
    {
      key = employee.Department;
      if (!referenceDictionary.ContainsKey(key))
      {
        referenceDictionary.Add(employee.Department, new List<Employee> { employee });
      }
      // If the current employee's department already exists, then add the employee to the value (which is a List<Employee>) to the relevant department (the department being the key)
      else
      {
        referenceDictionary[employee.Department].Add(employee);
      }
    }

    decimal sumSalaries;
    // Loop through the reference dictionary (the departments) in order to calculate the average salaries per department
    foreach (var dept in referenceDictionary)
    {
      sumSalaries = 0;
      // Loop through each employee within each department, and store the sum of the salaries for that deparment and the amount of employees for the department
      foreach (var person in dept.Value)
      {
        sumSalaries += person.MonthlySalary;
      }
      // Calculate the average salary of the current department by dividing the sum of salaries by the amount of employees in that department, then store the department and average salar
      // in the resultDictionary which will be returned to the user.
      sumSalaries /= dept.Value.Count;
      resultDictionary[dept.Key] = sumSalaries;
    }
    return resultDictionary;
  }

}

public class Employee(string name, string department, decimal monthlySalary)
{
  public string Name { get; init; } = name;
  public string Department { get; init; } = department;
  public decimal MonthlySalary { get; init; } = monthlySalary;
}
