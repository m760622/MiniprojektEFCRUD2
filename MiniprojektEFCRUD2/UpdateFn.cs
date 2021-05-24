using System;
using System.Linq;

namespace MiniprojektEFCRUD2
{
    partial class Program
        {
            private static void UpdateFn(ProductContext productDB)
            {
                while (true)
                {
                    Console.WriteLine("\n To update Branch 'B', Laptop Computers 'L',  Mobile Phones 'M', Exit write 'Q' ");
                    ConsoleKey input = Console.ReadKey(true).Key;

                    if (input == ConsoleKey.Q)
                    {
                        break;
                    }
                    else if (input == ConsoleKey.L)
                    {
                    UpdateLaptop(productDB);
                    }
                    else if (input == ConsoleKey.M)
                    {
                        UpdateMobile(productDB);
                    }
                    ReadFn(productDB);
                }
            }

            private static void UpdateBranch(ProductContext productDB)
            {
                int id = IntCheck("Id to update");
                Branch updateBranch = productDB.Branches.Where(branch => branch.Id == id).FirstOrDefault();
                if (updateBranch != null)
                {
                string branchName = StringCheck("Branch Name");
                updateBranch.Name = branchName;
                productDB.Branches.Update(updateBranch);
                    productDB.SaveChanges();
                }
            }

            private static void UpdateLaptop(ProductContext productDB)
            {
                int id = IntCheck("Id to update");
                Laptop updateLaptop = productDB.Laptops.Where(laptop => laptop.Id == id).FirstOrDefault();
                if (updateLaptop != null)
                {
                string modelName = StringCheck("Model Name");
                updateLaptop.ModelName = modelName;
                productDB.Laptops.Update(updateLaptop);
                    productDB.SaveChanges();
                }
            }

            private static void UpdateMobile(ProductContext productDB)
            {
                int id = IntCheck("Id to update");
                Mobile updateMobile = productDB.Mobiles.Where(mobile => mobile.Id == id).FirstOrDefault();
                if (updateMobile != null)
                {
                string modelName = StringCheck("Model Name");
                updateMobile.ModelName = modelName;
                productDB.Mobiles.Update(updateMobile);
                    productDB.SaveChanges();
                }
            }
        }
    }
