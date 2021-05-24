using System;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ProductContext productDB = new ProductContext();

            //To insert a fixed Data 
            //  FixedData(productDB);

            ReadFn(productDB);

            while (true)
            {
                Console.WriteLine("\n To Create new Product 'C', Delete 'D', Update 'U', Exit 'Q' ");
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Q)
                {
                    break;
                }
                else if (input == ConsoleKey.C)
                {
                    CreateFn(productDB);
                }
                else if (input == ConsoleKey.U)
                {
                    UpdateFn(productDB);
                }

                else if (input == ConsoleKey.D)
                {
                    DeleteFn(productDB);
                }
                productDB.SaveChanges();
            }
            ReadFn(productDB);
            Console.ReadLine();
        }
    }
}