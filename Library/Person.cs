

namespace Library
{
    public abstract class Person
    {
        protected IStudy study;
        protected ITeach teach;
        protected IDrive drive;

        public string firstName;
        public string lastName;

        public abstract string Display();
    }
}
