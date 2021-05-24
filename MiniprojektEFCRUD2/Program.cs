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
                Console.WriteLine("\nEnter new Product, for Laptop Computers 'l' for Mobile Phones 'm', To Delete write 'd', To Exit write 'q' ");
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Q)
                {
                    break;
                }
                else if (input == ConsoleKey.L)
                {
                    CreateLaptops(productDB);
                }
                else if (input == ConsoleKey.M)
                {
                    CreateMobiles(productDB);
                }

                else if (input == ConsoleKey.D)
                {
                    DeleteFn(productDB);
                }
                productDB.SaveChanges();
            }
           // productDB.SaveChanges();
            ReadFn(productDB);
            Console.ReadLine();
        }
    }
}
