using System;
using Business_Layer;
using Library;


namespace Presentation_Layer
{
    public static class Presentation
    {
        static string Choice()
        {
            Console.Write(" Your choice is: ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            return choice;
        }
        static void InvalidInput()
        {
            Console.WriteLine("---Invalid input---\n");
        }
        static void MenuMain()
        {
            Console.WriteLine(" 1. Student");
            Console.WriteLine(" 2. Teacher");
            Console.WriteLine(" 3. TaxiDriver");
            Console.WriteLine(" 4. Exit");

            switch (Choice())
            {
                case "1":
                    MenuStudent();
                    break;
                case "2":
                    MenuTeacher();
                    break;
                case "3":
                    MenuTaxiDriver();
                    break;
                case "4":
                    break;
                default:
                    InvalidInput();
                    MenuMain();
                    break;
            }
        }
        static void MenuStudent()
        {
            Console.WriteLine(" 1. To show the list of students");
            Console.WriteLine(" 2. To add a new student");
            Console.WriteLine(" 3. Task");
            Console.WriteLine(" 4. Study()");
            Console.WriteLine(" 5. Exit");

            switch (Choice())
            {
                case "1":
                    DisplayStudent();
                    break;
                case "2":
                    addStudent();
                    break;
                case "3":
                    Task();
                    break;
                case "4":
                    StudyStudent();
                    break;
                case "5":
                    break;
                default:
                    InvalidInput();
                    MenuStudent();
                    break;
            }
        }
        static void MenuTeacher()
        {
            Console.WriteLine(" 1. To show the list of the teachers");
            Console.WriteLine(" 2. Teach()");
            Console.WriteLine(" 3. Exit");

            switch (Choice())
            {
                case "1":
                    DisplayTeacher();
                    break;
                case "2":
                    TeachTeacher();
                    break;
                case "3":
                    break;
                default:
                    InvalidInput();
                    MenuTeacher();
                    break;
            }
        }
        static void MenuTaxiDriver()
        {
            Console.WriteLine(" 1. To show the list of the teachers");
            Console.WriteLine(" 2. Drive()");
            Console.WriteLine(" 3. Exit");

            switch (Choice())
            {
                case "1":
                    DisplayTaxiDriver();
                    break;
                case "2":
                    DriveTaxiDriver();
                    break;
                case "3":
                    break;
                default:
                    InvalidInput();
                    MenuTaxiDriver();
                    break;
            }
        }
        static void DisplayStudent()
        {
            string output = null;

            for (byte i = 0; i < Business.arrStudent.Length; i++)
                output += $" {i + 1}\t" + Business.arrStudent[i].Display() + "\n";

            Console.WriteLine(output);
        }
        static void DisplayStudent(Student[] arr)
        {
            string output = null;

            for (byte i = 0; i < arr.Length; i++)
                output += $" {i + 1}\t" + arr[i].Display() + "\n";

            Console.WriteLine(output);
        }
        static void DisplayTeacher()
        {
            string output = null;

            for (byte i = 0; i < Business.arrTeacher.Length; i++)
                output += $" {i + 1}\t" + Business.arrTeacher[i].Display() + "\n";

            Console.WriteLine(output);
        }
        static void DisplayTaxiDriver()
        {
            string output = null;

            for (byte i = 0; i < Business.arrTaxiDriver.Length; i++)
                output += $" {i + 1}\t" + Business.arrTaxiDriver[i].Display() + "\n";

            Console.WriteLine(output);
        }
        static void StudyStudent()
        {
            Console.WriteLine(Business.arrStudent[0].Study());
            Console.WriteLine();
        }
        static void TeachTeacher()
        {
            Console.WriteLine(Business.arrTeacher[0].Teach());
            Console.WriteLine();
        }
        static void DriveTaxiDriver()
        {
            Console.WriteLine(Business.arrTaxiDriver[0].Drive());
            Console.WriteLine();
        }
        static void addStudent()
        {
            string text;
            Student student = new Student();

            Console.WriteLine(" Fill in the attributes of new Student: ");
            Console.Write(" firstName = "); student.firstName = Console.ReadLine();
            Console.Write(" lastName = "); student.lastName = Console.ReadLine();
            Console.Write(" studentID = KB"); student.studentID = "KB" + Console.ReadLine();
            Console.Write(" sex = "); student.sex = Console.ReadLine();
            Console.WriteLine();
            student.residence = addStudent_residence();
            Console.Write(" course = "); student.course = Console.ReadLine();
            Console.WriteLine();

            student = Business.checkStudent(student);

            text = $"Student {student.firstName}{student.lastName}\r\n" +
                "{\r\n" +
                $"\"firstName\" = \"{student.firstName}\",\r\n" +
                $"\"lastName\" = \"{student.lastName}\",\r\n" +
                $"\"studentID\" = \"{student.studentID}\",\r\n" +
                $"\"sex\" = \"{student.sex}\",\r\n" +
                $"\"residence\" = \"{student.residence}\",\r\n" +
                $"\"course\" = \"{student.course}\"\r\n" +
                "};\r\n\r\n";

            Business.addStudent(text);
        }
        static string addStudent_residence()
        {
            string residence = null;

            bool flag = false;
            do
            {
                flag = false;
                Console.WriteLine(" 1. Dormitory");
                Console.WriteLine(" 2. House");

                switch (Choice())
                {
                    case "1":
                        Console.Write(" Number of the dormitory: "); residence = Console.ReadLine();
                        Console.Write(" Number of the room: "); residence += "." + Console.ReadLine();
                        break;
                    case "2":
                        Console.Write(" city = "); residence = Console.ReadLine();
                        Console.Write(" driveways(Island, Street, Boulevard, SideStreet) = "); residence += "." + Console.ReadLine();
                        Console.Write(" name of driveway = "); residence += "." + Console.ReadLine();
                        Console.Write(" number of house = "); residence += "." + Console.ReadLine();
                        break;
                    default:
                        InvalidInput();
                        flag = true;
                        break;
                }
            } while (flag == true);

            return residence;
        }
        static void Task()
        {
            Student[] TaskArr = Business.Task(Business.arrStudent);
            if (TaskArr == null)
            {
                Console.WriteLine("No mathces");
                Console.WriteLine();
            }
            else
                DisplayStudent(TaskArr);
        }
        public static void Start()
        {
            while (true)
            {
                MenuMain();
            }
        }
    }
}
