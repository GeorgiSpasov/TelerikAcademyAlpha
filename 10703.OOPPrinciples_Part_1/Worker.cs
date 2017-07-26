namespace _10703.OOPPrinciples_Part_1
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal result = this.WeekSalary / (this.WorkHoursPerDay * 7);

            return result;
        }
    }
}
