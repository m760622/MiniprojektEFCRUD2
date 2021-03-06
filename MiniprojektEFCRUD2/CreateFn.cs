using System.Linq;
using System.Collections.Generic;
using System;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {

        private static void CreateFn(ProductContext productDB)
        {

            while (true)
            {
                Console.WriteLine("\nTo enter new Product for Laptop Computers 'L' for Mobile Phones 'M', Exit write 'Q' ");
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
                productDB.SaveChanges();
            }
        }

        private static void CreateLaptops(ProductContext productDB)
        {
            string branchName = StringCheck("Branch Name");
            string purchaseDate = DateCheck("Purchase Date");
            string modelName = StringCheck("Model Name");
            string systemOperation = StringCheck("System Operation");
            string color = StringCheck("Color");
            int price = IntCheck("Price");
            int branchId = 0;
            Branch foundBranch = productDB.Branches.Where(branch => branch.Name == branchName).FirstOrDefault();
            if (foundBranch != null)
            {
                foundBranch.Laptops = new List<Laptop>();
                branchId = foundBranch.Id;
                Laptop newProduct = new Laptop(purchaseDate, modelName, systemOperation, color, price, branchId);
                foundBranch.Laptops.Add(newProduct);
            }
            else
            {
                Branch newBranch = new Branch(branchName);
                newBranch.Laptops = new List<Laptop>();
                branchId = newBranch.Id;
                Laptop newProduct = new Laptop(purchaseDate, modelName, systemOperation, color, price, branchId);
                newBranch.Laptops.Add(newProduct);
                productDB.Branches.Add(newBranch);
            }
        }

        private static void CreateMobiles(ProductContext productDB)
        {
            string branchName = StringCheck("Branch Name");
            string purchaseDate = DateCheck("Purchase Date");
            string modelName = StringCheck("Model Name");
            string color = StringCheck("Color");
            int price = IntCheck("Price");
            int branchId = 0;
            Branch foundBranch = productDB.Branches.Where(branch => branch.Name == branchName).FirstOrDefault();
            if (foundBranch != null)
            {
                foundBranch.Mobiles = new List<Mobile>();
                branchId = foundBranch.Id;
                Mobile newProduct = new Mobile(purchaseDate, modelName, color, price, branchId);
                foundBranch.Mobiles.Add(newProduct);
            }
            else
            {
                Branch newBranch = new Branch(branchName);
                newBranch.Mobiles = new List<Mobile>();
                branchId = newBranch.Id;
                Mobile newProduct = new Mobile(purchaseDate, modelName, color, price, branchId);
                newBranch.Mobiles.Add(newProduct);
                productDB.Branches.Add(newBranch);
            }
        }
    }
}
