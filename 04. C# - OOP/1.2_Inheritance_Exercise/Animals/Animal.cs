using System;
using System.ComponentModel.DataAnnotations;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }

                name = value;
            }
        }
        public int Age
        {
            get => age;

            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Invalid input!");
                }

                age = value;
            }
        }
        public string Gender
        {
            get => gender;

            private set
            {
                if (string.IsNullOrEmpty(value) || value is not ("Male" or "Female"))
                {
                    throw new Exception("Invalid input!");
                }

                gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}
