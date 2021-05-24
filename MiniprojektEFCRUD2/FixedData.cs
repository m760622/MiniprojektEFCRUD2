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

            List<Laptop> LaptopL = new List<Laptop>()
            {
            new Laptop("2018-08-22", "MacBook", "MacOs", "Silver", 400),
            new Laptop("2018-11-22", "Asus", "Windows 10", "Blue", 500),
            new Laptop("2018-08-24", "Lenovo", "Linux", "Black", 700),
            new Laptop("2019-11-22", "Asus", "Windows 10", "Blue", 600)
            };

            List<Laptop> LaptopP = new List<Laptop>()
            {
            new Laptop("2019-08-08", "HP", "Windows 8", "Silver", 300),
            new Laptop("2020-12-12", "Toshiba", "Windows 10", "Red", 600)
            };

            List<Mobile> MobilesL = new List<Mobile>()
            {
             new Mobile("2018-06-22", "Nokia", "Yellow", 700),
             new Mobile("2019-09-09", "Samsung", "Green", 500),
             new Mobile("2018-10-01", "Iphone", "Blue", 900),
             new Mobile("2018-11-01", "Iphone", "Blue", 900),
             new Mobile("2019-12-01", "Sony", "Black", 300),
             new Mobile("2020-06-01", "LG", "Red", 400)
            };

            List<Mobile> MobilesP = new List<Mobile>()
            {
             new Mobile("2019-09-09", "Samsung", "Green", 550),
             new Mobile("2018-10-01", "Iphone", "Blue", 990),
             new Mobile("2020-09-01", "LG", "white", 500)
            };


            branchP.Laptops = new List<Laptop>();
            branchP.Laptops.AddRange(LaptopL);
            branchG.Laptops = new List<Laptop>();
            branchG.Laptops.AddRange(LaptopP);
            branchP.Mobiles = new List<Mobile>();
            branchP.Mobiles.AddRange(MobilesL);
            branchG.Mobiles = new List<Mobile>();
            branchG.Mobiles.AddRange(MobilesP);

            productDB.Branches.AddRange(branchP, branchG);
            productDB.SaveChanges();

            Console.Write("\n The fixed Data bas has been entered to Product_Extended ");
        }
    }
}


