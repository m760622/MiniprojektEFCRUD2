using System;
using System.Collections.Generic;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {
        private static void FixedData(ProductContext productDB)
        {
            Console.Write("\n The fixed Data bas for Product_Extended ");

            Branch branchP = new Branch("Palestine");
            Branch branchG = new Branch("Gaza");

            List<Laptop> LaptopP = new List<Laptop>()
            {
            new Laptop("2018-08-22", "MacBook", "MacOs", "Silver", 400, branchP.Id),
            new Laptop("2018-11-22", "Asus", "Windows 10", "Blue", 500, branchP.Id),
            new Laptop("2018-08-24", "Lenovo", "Linux", "Black", 700, branchP.Id),
            new Laptop("2019-11-22", "Asus", "Windows 10", "Blue", 600, branchP.Id)
            };

            List<Laptop> LaptopG = new List<Laptop>()
            {
            new Laptop("2019-08-08", "HP", "Windows 8", "Silver", 300, branchG.Id),
            new Laptop("2020-12-12", "Toshiba", "Windows 10", "Red", 600, branchG.Id)
            };

            List<Mobile> MobilesP = new List<Mobile>()
            {
             new Mobile("2018-06-22", "Nokia", "Yellow", 700, branchP.Id),
             new Mobile("2019-09-09", "Samsung", "Green", 500, branchP.Id),
             new Mobile("2018-10-01", "Iphone", "Blue", 900, branchP.Id),
             new Mobile("2018-11-01", "Iphone", "Blue", 900, branchP.Id),
             new Mobile("2019-12-01", "Sony", "Black", 300, branchP.Id),
             new Mobile("2020-06-01", "LG", "Red", 400, branchP.Id)
            };

            List<Mobile> MobilesG = new List<Mobile>()
            {
             new Mobile("2019-09-09", "Samsung", "Green", 550, branchG.Id),
             new Mobile("2018-10-01", "Iphone", "Blue", 990, branchG.Id),
             new Mobile("2020-09-01", "LG", "white", 500, branchG.Id)
            };


            branchP.Laptops = new List<Laptop>();
            branchP.Laptops.AddRange(LaptopP);
            branchG.Laptops = new List<Laptop>();
            branchG.Laptops.AddRange(LaptopG);
            branchP.Mobiles = new List<Mobile>();
            branchP.Mobiles.AddRange(MobilesP);
            branchG.Mobiles = new List<Mobile>();
            branchG.Mobiles.AddRange(MobilesG);

            productDB.Branches.AddRange(branchP, branchG);
            productDB.SaveChanges();

            Console.Write("\n The fixed Data bas has been entered to Product_Extended ");
        }
    }
}


