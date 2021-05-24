using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MiniprojektEFCRUD2
{
    partial class Program
    {
        private static string DateCheck(string Name)
        {
            string StringInput;
            DateTime ValidDate = new DateTime();
            while (true)
            {
                Console.Write($"Enter the {Name}: as yyyy-mm-dd: ");
                StringInput = Console.ReadLine();
                bool stringInputIsInt = int.TryParse(StringInput, out int value);
                bool isValidDate = DateTime.TryParse(StringInput, out ValidDate);
                if (String.IsNullOrEmpty(StringInput))
                {
                    WriteLineColor($"The {Name} cant be Empty, please try again", ConsoleColor.Red);
                }
                else if (stringInputIsInt)
                {
                    WriteLineColor($"The {Name} can't be  a Number, please try again", ConsoleColor.Red);
                }
                else if (!isValidDate)
                {
                    WriteLineColor($"The {Name} is not a valide date, please try again", ConsoleColor.Red);
                }
                else
                {
                    break;
                }
            }
            return StringInput;
        }

        private static string StringCheck(string Name)
        {
            string StringInput;
            while (true)
            {
                Console.Write($"Enter the {Name}: ");
                StringInput = Console.ReadLine();
                bool stringInputIsInt = int.TryParse(StringInput, out int value);
                if (String.IsNullOrEmpty(StringInput))
                {
                    WriteLineColor($"The {Name} cant be Empty, please try again", ConsoleColor.Red);
                }
                else if (stringInputIsInt)
                {
                    WriteLineColor($"The {Name} cant be  a Number, please try again", ConsoleColor.Red);
                }
                else
                {
                    break;
                }
            }
            return StringInput;
        }

        private static int IntCheck(string Name)
        {
            int intCheckValue;
            while (true)
            {
                Console.Write($"Enter the {Name}: ");
                string intCheck = Console.ReadLine();
                if (int.TryParse(intCheck, out intCheckValue))
                {
                    break;
                }
                else
                {
                    WriteLineColor($"Wrong formate of the {Name}, please try again", ConsoleColor.Red);
                }
            }
            return intCheckValue;
        }

        private static void ProductsPrintOut(List<Product> products)
        {
            int indexL = 0, indexM = 0;
            List<Product> sortedproducts = products.
                OrderBy(product => product.GetType().Name).
                ThenBy(product => product.PurchaseDate).
                ToList();
            string msgTitle = "\n\nPurchaseDate".PadRight(20) + "Model Name".PadRight(20) + "SystemOperation".PadRight(25) + "Color".PadRight(20) + "Price";
            Console.WriteLine(msgTitle);
            File.WriteAllText("ResultFile.txt", msgTitle + Environment.NewLine);
            string msg = "";
            foreach (Product prod in sortedproducts)
            {
                if (prod is Laptop)
                {
                    if (indexL == 0)
                    {
                        msg = "\nLaptop Computers ";
                        Console.WriteLine(msg);
                        File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
                    }
                    indexL++;
                    msg = " - " + prod.PurchaseDate.PadRight(20) + prod.ModelName.PadRight(20) + (prod as Laptop).SystemOperation.PadRight(20) + prod.Color.PadRight(20) + (prod as Laptop).Price;
                    WriteLineColor(msg, DateValidation(prod.PurchaseDate));
                }
                else
                {
                    if (indexM == 0)
                    {
                        msg = "\nMobile Phones ";
                        Console.WriteLine(msg);
                        File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
                    }
                    indexM++;
                    msg = " - " + prod.PurchaseDate.PadRight(20) + prod.ModelName.PadRight(20) + prod.Color.PadRight(20) + (prod as Mobile).Price;
                    WriteLineColor(msg, DateValidation(prod.PurchaseDate));
                }
                File.AppendAllText("ResultFile.txt", msg + Environment.NewLine);
            }
        }

        static ConsoleColor DateValidation(string purchaseDate)
        {
            ConsoleColor colorW = ConsoleColor.White;
            DateTime nowDate = new DateTime();
            nowDate = DateTime.Now;
            DateTime ValidDate = new DateTime();
            TimeSpan diffDate = new TimeSpan();
            int difDays = 0;
            bool isValidDate = DateTime.TryParse(purchaseDate, out ValidDate);
            if (isValidDate)
            {
                diffDate = nowDate - ValidDate;
                difDays = Convert.ToInt32(diffDate.TotalDays);
                if (difDays < 1080)
                {
                    colorW = difDays < 900 ? ConsoleColor.White : difDays < 990 ? ConsoleColor.Yellow : ConsoleColor.Red;
                }
            }
            else
            {
                Console.WriteLine("The date is not valide, please try again");
            }
            return colorW;
        }

        public static void WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
