using System.Linq;
using System.Collections.Generic;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {

        private static void CreateLaptops(ProductContext productDB)
        {
            string branchName = StringCheck("Branch Name");
            string purchaseDate = DateCheck("Purchase Date");
            string modelName = StringCheck("Model Name");
            string systemOperation = StringCheck("System Operation");
            string color = StringCheck("Color");
            int price = IntCheck("Price");
            Branch foundBranch = productDB.Branches.Where(branch => branch.Name == branchName).FirstOrDefault();
            if (foundBranch != null)
            {
                foundBranch.Laptops = new List<Laptop>();
                Laptop newProduct = new Laptop(purchaseDate, modelName, systemOperation, color, price);
                foundBranch.Laptops.Add(newProduct);
            }
            else
            {
                Branch newBranch = new Branch(branchName);
                newBranch.Laptops = new List<Laptop>();
                Laptop newProduct = new Laptop(purchaseDate, modelName, systemOperation, color, price);
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
            Branch foundBranch = productDB.Branches.Where(branch => branch.Name == branchName).FirstOrDefault();
            if (foundBranch != null)
            {
                foundBranch.Mobiles = new List<Mobile>();
                Mobile newProduct = new Mobile(purchaseDate, modelName, color, price);
                foundBranch.Mobiles.Add(newProduct);
            }
            else
            {
                Branch newBranch = new Branch(branchName);
                newBranch.Mobiles = new List<Mobile>();
                Mobile newProduct = new Mobile(purchaseDate, modelName, color, price);
                newBranch.Mobiles.Add(newProduct);
                productDB.Branches.Add(newBranch);
            }
        }
    }
}
