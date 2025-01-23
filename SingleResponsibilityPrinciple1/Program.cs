// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



//SINGLE RESPONSIBILITY PRINCIPLE
//States that a class should have a single responsibility
//or only one reason to change

//When a class follow the SRP, it becomes easier to change and test.
//If a class has multiple responsibilities, changing one of them may impact others
//and more testing efforts will be required


//Example of class violating SRP
namespace ViolatingSRP
{
    public class Employee
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string FullName { get { return Name + Surname; } }
        public int Level { get; set; }
        public int CalculateSalary()
        {
            if (Level < 3)
                return 20000;
            else if (Level < 7)
                return 60000;
            else return 90000;
        }
        public string GetEmployeeCode()
        {
            return Id + FullName;
        }

        //This is an extra responsability
        //as a result this class is violating SRP
        public void Save()
        {
            //Code for saving employee to the database
        }
    }
}

//Example of class following SRP
//each class has a single kind of responsibilities
namespace FollowingSRP
{
    public class Employee
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string FullName { get { return Name + Surname; } }
        public int Level { get; set; }
        public int CalculateSalary()
        {
            if (Level < 3)
                return 20000;
            else if (Level < 7)
                return 60000;
            else return 90000;
        }
        public string GetEmployeeCode()
        {
            return Id + FullName;
        }

        public class EmployeeRepository
        {
            public void Save()
            {
                //Code for saving employee to the database
            }

            public Task Read(int id)
            {
                //Code for getting employee from the database
                return Task.CompletedTask;
            }
        }

    }
}

