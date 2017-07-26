namespace _10703.OOPPrinciples_Part_1
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
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

        public double WorkHoursPerDay
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
            decimal result = this.WeekSalary / (decimal)(this.WorkHoursPerDay * 7);

            return result;
        }

        public override string ToString()
        {
            return string.Format($"{this.FirstName,-8} {this.LastName,-8} - ${this.WeekSalary,4}, {this.WorkHoursPerDay,2}h, {this.MoneyPerHour():f2}$/h");
        }
    }
}
