decimal squareMeters = decimal.Parse(Console.ReadLine());
decimal discount = (squareMeters * 7.61m) * 0.18m;
decimal price = (squareMeters * 7.61m) - discount;

Console.WriteLine($"The final price is: {price} lv.");
Console.WriteLine($"The discount is: {discount} lv.") ;