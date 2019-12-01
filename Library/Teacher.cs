

namespace Library
{
    public class Teacher : Person
    {
        public string skill;

        public Teacher()
        {
            teach = new Teach_Teacher();
        }
        public override string Display()
        {
            return (this.firstName + " " + this.lastName + " | skill: " + this.skill);
        }
        public string Teach()
        {
            return teach.Teach();
        }
    }
}
