using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {
        private static void ReadFn(ProductContext productDB)
        {
            List<Laptop> sortedLaptops = productDB.Laptops.
             OrderBy(product => product.PurchaseDate).ToList();

            List<Mobile> sortedMobiles = productDB.Mobiles.
            OrderBy(product => product.PurchaseDate).ToList();
            int indexL = 0, indexM = 0;

            Branch branchFound = productDB.Branches.Where(branchIn => branchIn.Id == 1).FirstOrDefault();
            string msgTitle = "\n\n ID".PadRight(20) + "Branch Name".PadRight(20) + "PurchaseDate".PadRight(20) + "Model Name".PadRight(20) + "SystemOperation".PadRight(25) + "Color".PadRight(20) + "Price";
            Console.WriteLine(msgTitle);
            File.WriteAllText("ResultFile.txt", msgTitle + Environment.NewLine);

            int totalPriceL = 0;
            int totalPriceM = 0;
            string msg = "";
            foreach (Product laptop in sortedLaptops)
            {
                if (indexL == 0)
                {
                    msg = "\nLaptop Computers ";
                    Console.WriteLine(msg);
                    File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
                }
                indexL++;
                totalPriceL = totalPriceL + laptop.Price;
                var branchName = productDB.Branches.Find(laptop.BranchId).Name;
                msg = " - " + $"{laptop.Id}".PadRight(15) + $"{branchName}".PadRight(20) + laptop.PurchaseDate.PadRight(20) + laptop.ModelName.PadRight(20) + (laptop as Laptop).SystemOperation.PadRight(25) + laptop.Color.PadRight(20) + (laptop as Laptop).Price;
                WriteLineColor(msg, DateValidation(laptop.PurchaseDate));
                File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
            }
            WriteLineColor("totalPrice is: " + totalPriceL, ConsoleColor.Green);

            foreach (Product mobile in sortedMobiles)
            {
                if (indexM == 0)
                {
                    msg = "\nMobile Phones ";
                    Console.WriteLine(msg);
                    File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
                }
                indexM++;
                totalPriceM = totalPriceM + mobile.Price;

                var branchName = productDB.Branches.Find(mobile.BranchId).Name;
                msg = " - "  + $"{mobile.Id}".PadRight(15) + $"{branchName}".PadRight(20) + mobile.PurchaseDate.PadRight(20) + mobile.ModelName.PadRight(20) + "-".PadRight(25) + mobile.Color.PadRight(20)  + (mobile as Mobile).Price;
                WriteLineColor(msg, DateValidation(mobile.PurchaseDate));
                File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
            }
            WriteLineColor("totalPrice is: " + totalPriceM, ConsoleColor.Green);
        }
    }
 }

