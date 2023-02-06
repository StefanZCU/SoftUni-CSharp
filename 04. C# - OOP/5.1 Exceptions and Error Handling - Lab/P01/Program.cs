namespace P01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 0)
                {
                    throw new Exception("Invalid number.");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(num));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}