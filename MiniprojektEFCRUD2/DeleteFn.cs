using System;
using System.Linq;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {
        private static void DeleteFn(ProductContext productDB)
        {
            while (true)
            {
                Console.WriteLine("\n To delete Laptop Computers 'l' for Mobile Phones 'm', To Exit write 'q' ");
                ConsoleKey input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.Q)
                {
                    break;
                }
                else if (input == ConsoleKey.L)
                {
                    DeleteLaptop(productDB);
                }
                else if (input == ConsoleKey.M)
                {
                    DeleteMobile(productDB);
                }
                ReadFn(productDB);
            }
        }


        private static void DeleteBranch(ProductContext productDB)
        {
            int id = IntCheck("Id to delete");
            Branch deleteBranch = productDB.Branches.Where(branch => branch.Id == id).FirstOrDefault();
            if (deleteBranch != null)
            {
                productDB.Branches.Remove(deleteBranch);
                productDB.SaveChanges();
            }
        }
        private static void DeleteLaptop(ProductContext productDB)
        {
            int id = IntCheck("Id to delete");
            Laptop deleteLaptop = productDB.Laptops.Where(laptop => laptop.Id == id).FirstOrDefault();
            if (deleteLaptop != null)
            {
                productDB.Laptops.Remove(deleteLaptop);
                productDB.SaveChanges();
            }
        }
        private static void DeleteMobile(ProductContext productDB)
        {
            int id = IntCheck("Id to delete");
            Mobile deleteMobile = productDB.Mobiles.Where(mobile => mobile.Id == id).FirstOrDefault();
            if (deleteMobile != null)
            {
                productDB.Mobiles.Remove(deleteMobile);
                productDB.SaveChanges();
            }
        }
    }
}
