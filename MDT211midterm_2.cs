using System;
using System.Collections.Generic;
//ยอมแพ้ ยกธงขาว

namespace Mdt211midterm_2
{   enum RegisterMenu {
     Register = 1,
     Login
    }
    enum Type {
        Student =1,
        Employee
    }
    class Person {
        protected string name;
        protected string password;
        protected string type;
        

        public Person(string name, string password, string type)
        {
            this.name = name;
            this.password = password;
            this.type = type;
            
        }
    }
    class Student : Person
    {
        private string studentID;

        public Student(string name, string password, string type, string studemtID) : base(name, password, type)
        {
            this.studentID = studemtID;
        }
    }
    class Employee : Person
    {
        private string employeeID;

        public Employee(string name, string password, string type, string employeeID) : base(name, password, type)
        {
            this.employeeID = employeeID;
        }
    }
    class PersonList {
        private List<Person> personList;

        public PersonList() 
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }
    }
    class Program
    {
        static PersonList personList;
        static void Main(string[] args)
        {
            PrintHeaderMenu();

        }
        static void PreparePersonList() 
        {
            Program.personList = new PersonList();
        }
        static void PrintHeaderMenu()
        {
            Console.WriteLine("Welcom to Digital Library");
            Console.WriteLine("-------------------------");
            PrintMenu();
        }
        static void PrintMenu()
        {
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Login");
            InputMenu();
        }
        static void InputMenu() 
        {
            Console.WriteLine("Select Menu : ");
            RegisterMenu registerMenu = (RegisterMenu)(int.Parse(Console.ReadLine()));
            PresentMenu(registerMenu);
        }
        static void PresentMenu(RegisterMenu registerMenu)
        {
            if (registerMenu == RegisterMenu.Login)
            {
                Console.WriteLine("55555");
            }
            else if (registerMenu == RegisterMenu.Register)
            {
                PrintHeaderRegisterMenu();
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Incorrect menu. Please try again.");
                PrintHeaderMenu();
            }

        }
        static void PrintHeaderRegisterMenu() 
        {
            Console.WriteLine("Register new Person");
            Console.WriteLine("-------------------");
            PrintRegisterMenu();
        }
        static void PrintRegisterMenu() {
            Person person = CreateNewPerson();
            Program.personList.AddNewPerson(person);  

            Console.Clear();
            if (InputType() == "1") ;
        }
        static Person CreateNewPerson() {

            return new Student(InputName(), InputPassword(), InputType(),InputStudentID());
            return new Employee(InputName(), InputPassword(), InputType(), InputEmployeeID());

        }
        static string InputName() 
        {
            Console.Write("Input name : ");
            return Console.ReadLine();
        }
        static string InputPassword()
        {
            Console.Write("Input Password : ");
            return Console.ReadLine();
        }
        static string InputType()
        {
            Console.Write("Input Type 1 = Student, 2 = Employee : ");
            Type type = (Type)(int.Parse(Console.ReadLine()));
            return Convert.ToString(type);
            if (type == Type.Student)
            {
                InputStudentID();

            }
            else if (type == Type.Employee)
            {
                InputEmployeeID();

            }
            else 
            {
                Console.WriteLine("Incorrect type. Please try again.");
                InputType();
            }

            
        }
        static string InputStudentID() 
        {
            Console.Write("Input Student ID : ");
            return Console.ReadLine();
        }
        static string InputEmployeeID() 
        {
            Console.Write("Input Employee ID : ");
            return Console.ReadLine();
        }
    }
}
