namespace Person
{
    using System.Text;

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            age = age switch
            {
                > 15 => 15,
                < 0 => 0,
                _ => age
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString();
        }

    }
}
