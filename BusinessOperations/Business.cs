using DataAccess_Layer;
using Library;
using System.Text.RegularExpressions;

namespace Business_Layer
{
    public static class Business
    {
        public static string text;
        public static byte numTypes;
        public static Person[][] person;
        public static Student[] arrStudent;
        public static Teacher[] arrTeacher;
        public static TaxiDriver[] arrTaxiDriver;
        static Business()
        {
            text = DataAccess.Read();
            numTypes = 3;
            person = fillArray();
            arrStudent = new Student[Amount(0)];
            arrTeacher = new Teacher[Amount(1)];
            arrTaxiDriver = new TaxiDriver[Amount(2)];

            arrStudent = person[0] as Student[];
            arrTeacher = person[1] as Teacher[];
            arrTaxiDriver = person[2] as TaxiDriver[];
        }


        public static byte Amount(byte choice_result)
        {
            MatchCollection regexMatches;
            switch (choice_result)
            {
                case 0:
                    regexMatches = Regex.Matches(text, @"Student");
                    choice_result = (byte)regexMatches.Count;
                    break;
                case 1:
                    regexMatches = Regex.Matches(text, @"Teacher");
                    choice_result = (byte)regexMatches.Count;
                    break;
                case 2:
                    regexMatches = Regex.Matches(text, @"TaxiDriver");
                    choice_result = (byte)regexMatches.Count;
                    break;
            }

            return choice_result;
        }
        public static void SortByType()
        {
            string[] textByType = new string[numTypes];

            textByType[0] = getStudents(textByType[0]);
            textByType[1] = getTeachers(textByType[1]);
            textByType[2] = getTaxiDrivers(textByType[2]);

            string text2 = null;
            foreach (string str in textByType)
                text2 += str;

            DataAccess.Write(text2, false);
        }
        public static string getStudents(string students)
        {
            Regex regexStudent = new Regex
                ("Student [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"[\r\n]+" +
                "};");
            MatchCollection matches = regexStudent.Matches(text);

            foreach (Match match in matches)
                students += match.Value + "\r\n\r\n";

            return students;
        }
        public static string getTeachers(string teachers)
        {
            Regex regexTeacher = new Regex
                ("Teacher [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"[\r\n]+" +
                "};");
            MatchCollection matches = regexTeacher.Matches(text);

            foreach (Match match in matches)
                teachers += match.Value + "\r\n\r\n";

            return teachers;
        }
        public static string getTaxiDrivers(string taxidrivers)
        {
            Regex regexTaxiDriver = new Regex
                ("TaxiDriver [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"[\r\n]+" +
                "};");
            MatchCollection matches = regexTaxiDriver.Matches(text);

            foreach (Match match in matches)
                taxidrivers += match.Value + "\r\n\r\n";

            return taxidrivers;
        }
        public static Person[][] fillArray()
        {
            Person[][] person = new Person[numTypes][];
            Regex regexPerson = new Regex
                ("[A-Za-z]+ [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"");

            for (byte i = 0; i < numTypes; i++)
                person[i] = new Person[Amount(i)];

            Match matchPerson = regexPerson.Match(text);

            for (byte i = 0; i < numTypes; i++)
            {
                for (byte j = 0; j < person[i].Length; j++)
                {
                    if (i == 0)
                        person[i][j] = new Student();
                    else if (i == 1)
                        person[i][j] = new Teacher();
                    else if (i == 2)
                        person[i][j] = new TaxiDriver();

                    for (byte k = 1; k <= matchPerson.Groups.Count - 1; k += 2)
                    {
                        switch (matchPerson.Groups[k].Value)
                        {
                            case "firstName":
                                person[i][j].firstName = matchPerson.Groups[k + 1].Value;
                                break;
                            case "lastName":
                                person[i][j].lastName = matchPerson.Groups[k + 1].Value;
                                break;
                        }
                    }
                    matchPerson = matchPerson.NextMatch();
                }
            }


            person[0] = fillArray_Student(person[0]);
            person[1] = fillArray_Teacher(person[1]);
            person[2] = fillArray_TaxiDriver(person[2]);

            return person;
        }
        public static Student[] fillArray_Student(Person[] person)
        {
            Student[] arrStudent = new Student[Amount(0)];

            for (byte i = 0; i < person.Length; i++)
                arrStudent[i] = person[i] as Student;


            Regex regexStudent = new Regex
                ("Student [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"[\r\n]+" +
                "};");
            Match matchStudent = regexStudent.Match(text);

            for (byte i = 0; i < arrStudent.Length; i++)
            {
                for (byte j = 1; j <= matchStudent.Groups.Count - 1; j += 2)
                {
                    switch (matchStudent.Groups[j].Value)
                    {
                        case "studentID":
                            arrStudent[i].studentID = matchStudent.Groups[j + 1].Value;
                            break;
                        case "sex":
                            arrStudent[i].sex = matchStudent.Groups[j + 1].Value;
                            break;
                        case "residence":
                            arrStudent[i].residence = matchStudent.Groups[j + 1].Value;
                            break;
                        case "course":
                            arrStudent[i].course = matchStudent.Groups[j + 1].Value;
                            break;
                    }
                }
                arrStudent[i] = checkStudent(arrStudent[i]);
                matchStudent = matchStudent.NextMatch();
            }

            return arrStudent;
        }
        public static Teacher[] fillArray_Teacher(Person[] person)
        {
            Teacher[] arrTeacher = new Teacher[Amount(1)];
            for (byte i = 0; i < person.Length; i++)
                arrTeacher[i] = person[i] as Teacher;

            Regex regexTeacher = new Regex
                ("Teacher [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"[\r\n]+" +
                "};");
            Match matchTeacher = regexTeacher.Match(text);

            for (byte i = 0; i < arrTeacher.Length; i++)
            {
                for (byte j = 1; j <= matchTeacher.Groups.Count - 1; j += 2)
                {
                    if (matchTeacher.Groups[j].Value == "skill")
                        arrTeacher[i].skill = matchTeacher.Groups[j + 1].Value;
                }
                arrTeacher[i] = checkTeacher(arrTeacher[i]);
                matchTeacher = matchTeacher.NextMatch();
            }

            return arrTeacher;
        }
        public static TaxiDriver[] fillArray_TaxiDriver(Person[] person)
        {
            TaxiDriver[] arrTaxiDriver = new TaxiDriver[Amount(2)];
            for (byte i = 0; i < person.Length; i++)
                arrTaxiDriver[i] = person[i] as TaxiDriver;

            Regex regexTaxiDriver = new Regex
                ("Teacher [A-Za-z]+[\r\n]+" +
                "{[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\",[\r\n]+" +
                "\"(.*)\" = \"(.*)\"[\r\n]+" +
                "};");
            Match matchTaxiDriver = regexTaxiDriver.Match(text);

            for (byte i = 0; i < arrTaxiDriver.Length; i++)
            {
                for (byte j = 1; j <= matchTaxiDriver.Groups.Count - 1; j += 2)
                {
                    if (matchTaxiDriver.Groups[j].Value == "car")
                        arrTaxiDriver[i].car = matchTaxiDriver.Groups[j + 1].Value;
                }
                arrTaxiDriver[i] = checkTaxiDriver(arrTaxiDriver[i]);
                matchTaxiDriver = matchTaxiDriver.NextMatch();
            }

            return arrTaxiDriver;
        }
        public static Student checkStudent(Student student)
        {
            if (student.firstName == null || !Regex.IsMatch(student.firstName, "[A-Za-z]+"))
                student.firstName = "firstName";

            if (student.lastName == null || !Regex.IsMatch(student.lastName, "[A-Za-z]+"))
                student.lastName = "lastName";

            if (student.studentID == null || !Regex.IsMatch(student.studentID, "KB[0-9]{6}"))
                student.studentID = "KB000000";

            if (student.sex == null || !Regex.IsMatch(student.sex, "male|female"))
                student.sex = "null";

            if (student.residence == null || !(Regex.IsMatch(student.residence, "[0-9]+.[0-9]{3}") ||
                Regex.IsMatch(student.residence, "[A-Za-z]+.[Street|SideStreet|Island|Boulervard].[A-Za-z]+.[0-9]+")))
                student.residence = "City.Driveway.NameOfDriveway.HouseNumber";

            if (student.course == null || !Regex.IsMatch(student.course, "[0-9]+"))
                student.course = "0";

            return student;
        }
        public static Teacher checkTeacher(Teacher teacher)
        {
            if (teacher.firstName == null || !Regex.IsMatch(teacher.firstName, "[A-Za-z]+"))
                teacher.firstName = "firstName";

            if (teacher.lastName == null || !Regex.IsMatch(teacher.lastName, "[A-Za-z]+"))
                teacher.lastName = "lastName";

            if (teacher.skill == null || !Regex.IsMatch(teacher.skill, "[0-9]{1,2}"))
                teacher.skill = "0";

            return teacher;
        }
        public static TaxiDriver checkTaxiDriver(TaxiDriver taxidriver)
        {
            if (taxidriver.firstName == null || !Regex.IsMatch(taxidriver.firstName, "[A-Za-z]+"))
                taxidriver.firstName = "firstName";

            if (taxidriver.lastName == null || !Regex.IsMatch(taxidriver.lastName, "[A-Za-z]+"))
                taxidriver.lastName = "lastName";

            if (taxidriver.car == null || !Regex.IsMatch(taxidriver.car, "[A-Za-z]"))
                taxidriver.car = "None";

            return taxidriver;
        }
        public static void addStudent(string text2)
        {
            DataAccess.Write(text2);
            text = DataAccess.Read();
            SortByType();
            text = DataAccess.Read();
            person = fillArray();
            arrStudent = new Student[Amount(0)];
            arrStudent = person[0] as Student[];
        }
        public static Student[] Task(Student[] arrStudent)
        {
            byte num = 0;
            for (byte i = 0; i < arrStudent.Length; i++)
            {
                if (arrStudent[i].course == "1" && arrStudent[i].sex == "female" && Regex.IsMatch(arrStudent[i].residence, "[0-9]+.[0-9]{3}"))
                    num++;
            }

            if (num != 0)
            {
                Student[] TaskArr = new Student[num];

                byte j = 0;
                for (byte i = 0; i < arrStudent.Length; i++)
                {
                    if (arrStudent[i].course == "1" && arrStudent[i].sex == "female" && Regex.IsMatch(arrStudent[i].residence, "[0-9]+.[0-9]{3}"))
                        TaskArr[j++] = arrStudent[i];
                }

                return TaskArr;
            }

            return null;
        }
    }
}
