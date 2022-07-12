using AccessDB.models;
using AccessDB.Repositories;

namespace AccessDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository product = new();
            
            string option;    

            do
            {
                Menu.MainMenu();

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Menu.ListProducts();
                        break;
                    case "2":
                        Menu.CreateProduct();
                        
                        break;
                    case "3":
                        Menu.UpdateMenu();
                        break;
                    case "4":
                        Menu.DeleteProduct();
                        
                        break;
                    default:
                        break;
                }

            } while (option !="0");

           


        }
    }
}