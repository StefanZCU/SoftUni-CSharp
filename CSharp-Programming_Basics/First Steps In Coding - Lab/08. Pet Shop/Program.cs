int dogFood = int.Parse(Console.ReadLine());
int catFood = int.Parse(Console.ReadLine());

double dogPrice = dogFood * 2.5;
int catPrice = catFood * 4;

double endPrice = catPrice + dogPrice;
Console.WriteLine($"{endPrice} lv.");

