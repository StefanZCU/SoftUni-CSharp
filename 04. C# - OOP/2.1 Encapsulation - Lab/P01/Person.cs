namespace PersonsInfo
{
    public class Person
    {
		private string firstName;
		private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get => firstName;
			set => firstName = value;
		}

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public decimal Salary
        {
            get => salary;
            set => salary = value;
        }

        public void IncreaseSalary(decimal percentage)
        {
            Salary = Age switch
            {
                >= 30 => Salary + (Salary * percentage / 100),
                _ => Salary + (Salary * percentage / 200)
            };
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
