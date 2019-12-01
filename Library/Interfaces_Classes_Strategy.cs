

// Stategy Patttern
namespace Library
{
    // Interfaces
    public interface IStudy
    {
        public string Study();
    }
    public interface ITeach
    {
        public string Teach();
    }
    public interface IDrive
    {
        public string Drive();
    }

    // Classes, which implements above Interfaces
    class Study_Student : IStudy
    {
        public string Study()
        {
            return "Student.Study()";
        }
    }
    class Teach_Teacher : ITeach
    {
        public string Teach()
        {
            return "Teacher.Teach()";
        }
    }
    class Drive_TaxiDriver : IDrive
    {
        public string Drive()
        {
            return "TaxiDriver.Drive()";
        }
    }
}
