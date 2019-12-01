

namespace Library
{
    public class TaxiDriver : Person
    {
        public string car;

        public TaxiDriver()
        {
            drive = new Drive_TaxiDriver();
        }
        public override string Display()
        {
            return (this.firstName + " " + this.lastName + " | car: " + this.car);
        }
        public string Drive()
        {
            return drive.Drive();
        }
    }
}
