
namespace dotnet_lab1

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("problem plecakowy!");

            Console.WriteLine("Enter rng seed:");
            int seed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter capacity:");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of items to generate:");
            int numItems = int.Parse(Console.ReadLine());


            Problem thief = new Problem(seed, numItems);
            thief.Print(); //print all items

            Result rv = thief.Solve(capacity);
            rv.Print(); //print stolen items


            Console.WriteLine("(overloaded ToString) ids: " + rv.ToString());




        }
    }
}
