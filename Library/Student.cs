

namespace Library
{
    public class Student : Person
    {
        public string studentID;
        public string sex;
        public string residence;
        public string course;

        public Student()
        {
            study = new Study_Student();
        }
        public override string Display()
        {
            return (this.firstName + " " + this.lastName + " | " + this.studentID + " | " + this.sex + " | " +
                        this.residence + " | " + this.course + " course");
        }
        public string Study()
        {
            return study.Study();
        }
    }
}
