using DataLibrary;
using System;

namespace StudentData
{
    class Program
    {
        static void Main(string[] args)
        {

            var newSql = new StudentRepository();

            Console.WriteLine("     Employee Registory\n");
            Console.WriteLine("1. View all Employee Details");
            Console.WriteLine("2. View Particular Employee Details");
            Console.WriteLine("3. Insert a data into Employee Registory");
            Console.WriteLine("4. Update a data on Employee Registory");
            Console.WriteLine("5. Delete a data on Employee Registory\n");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("ID   Name   Designation   Age  Experience");
                    foreach (var item in newSql.GetDetails())
                    {
                        Console.WriteLine($"{item.StudentID}   {item.StudentName}     {item.StudentCourse}      {item.StudentAge}     {item.EmpExperience}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the ID of Employee to view: ");
                    int viewId = int.Parse(Console.ReadLine());
                    var addition = newSql.viewDetails(viewId);
                    Console.WriteLine("ID   Name   Designation   Age  Experience");
                    try
                    {
                        foreach (var item in addition)
                        {
                            Console.WriteLine($"{item.StudentID}   {item.StudentName}     {item.StudentCourse}      {item.StudentAge}     {item.EmpExperience}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    break;
                case 3:
                    Console.Write("Enter the name:");
                    string insertName = Console.ReadLine();
                    Console.Write("Enter the Age:");
                    int insertAge = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Designation:");
                    string insertDesig = Console.ReadLine();
                    Console.Write("Enter the Experience:");
                    int insertExperience = int.Parse(Console.ReadLine());

                    try
                    {
                        var insertData = newSql.InsertDetails(new StudentProperties()
                        {
                            StudentName = insertName,
                            StudentAge = insertAge,
                            StudentCourse = insertDesig,
                            EmpExperience = insertExperience,
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine("\nRecord Inserted sucessfully");
                    }
                    break;

                case 4:
                    Console.Write("Enter the Id to update:");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter the name:");
                    string UpdateName = Console.ReadLine();

                    try
                    {
                        var updateData = newSql.UpdateDetails(new StudentProperties()
                        {
                            StudentID = updateId,
                            StudentName = UpdateName,
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine("\nRecord Updated sucessfully");
                    }
                    break;

                case 5:
                    Console.Write("Enter the Id to delete an employee record: ");
                    int deleteId = int.Parse(Console.ReadLine());

                    var deleteData = newSql.DeleteDetails(deleteId);
                    Console.WriteLine("\nRecord deleted sucessfully");
                    break;

                default:
                    Console.WriteLine("Enter a valid number: ");
                    break;
            }
        }
    }
}
