string name = Console.ReadLine();
byte numberOfProjects = byte.Parse(Console.ReadLine());
int numberOfHours = numberOfProjects * 3;
Console.WriteLine($"The architect {name} will need {numberOfHours} hours to complete {numberOfProjects} project/s.");

