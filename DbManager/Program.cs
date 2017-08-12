using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Spots Database Manager***");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("{Reset} to clear and populate databases.");
            Console.WriteLine("{Clear *} to clear databases.");
            Console.WriteLine("{Populate} to populate databases.");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter command:");
                var command = Console.ReadLine().ToLower().Trim();

                switch (command)
                {
                    case ("clear *"):
                    {
                        DeleteAllCommand();
                        break;
                    }
                    case ("populate"):
                    {
                        PopulateCommand();
                        break;
                    }
                    case ("reset"):
                    {
                        Reset();
                        break;
                    }
                    default:
                        InvalidCommand();
                        break;
                }
            }
        }

        private static void InvalidCommand()
        {
            Console.WriteLine("Entered command is not valid.");
        }

        private static void Reset()
        {
            Console.WriteLine("Reseting databases...");
            DeleteAllCommand();
            PopulateCommand();
        }

        private static void DeleteAllCommand()
        {
            Console.WriteLine("Deleting all...");

            var controller = new CommandController();
            var result = controller.DeleteAll();

            Console.WriteLine(result ? "Data were deleted successfully." : "Unable to delete all.");
        }

        private static void PopulateCommand()
        {
            var controller = new CommandController();
            var result = controller.Populate();

            if (result == false)
            {
                Console.WriteLine("Error occured while populating databases.");
                DeleteAllCommand();
            }
            else
            {
                Console.WriteLine("Databases were populated successfully.");
            }
        }
    }
}
