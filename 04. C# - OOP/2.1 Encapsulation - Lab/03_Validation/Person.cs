using System.Net.WebSockets;

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
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public string FirstName
        {
            get => firstName;

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameIsLessThanThreeSymbols, "First"));
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameIsLessThanThreeSymbols, "Last"));
                }

                lastName = value;
            }
        }

        public int Age
        {
            get => age;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AgeIsLessThanZero);
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get => salary;

            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException(ExceptionMessages.SalaryIsLessThan650);
                }

                salary = value;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2.0m;
            }

            this.Salary += (this.Salary * percentage / 100);
        }
    }
}
