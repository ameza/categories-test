using System;
using BusinessLayer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ConsoleKeyInfo cki;

            do
            {
                DisplayMenu();
                cki = Console.ReadKey(false); // show the key as you read it
                Console.WriteLine();
                Console.WriteLine();
                switch (cki.KeyChar.ToString())
                {
                    case "1":

                        ListCategories();
                        break;
                    case "2":
                        FindCategoryKeywords();
                        break;
                    case "3":
                        GetCategoriesByLevel();
                        break;
                       
                }
            } while (cki.Key != ConsoleKey.Escape);
        }

        static public void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Categories Test by Andres Meza");
            Console.WriteLine();
            Console.WriteLine("1. List Categories");
            Console.WriteLine("2. Get category keywords");     
            Console.WriteLine("3. Get categories by level");       
            Console.WriteLine(" Press Esc to Exit");           
        }

        static public void ListCategories(){

            CategoryService categoryService = new CategoryService();

            var categories = categoryService.GetCategories();

            categories.ForEach(item => { Console.WriteLine(item.ToString()); });
        }

        static public void FindCategoryKeywords()
        {
            try
            {
                CategoryService categoryService = new CategoryService();

                Console.WriteLine("Enter Category Id");
                var cId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                var foundCategory = categoryService.FindCategoryKeywords(cId);

                Console.WriteLine();
                Console.WriteLine(foundCategory.ToString());
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

        static public void GetCategoriesByLevel()
        {
            try
            {
                CategoryService categoryService = new CategoryService();

                Console.WriteLine("Enter Level");
                var cId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                var foundCategories = categoryService.GetCategoriesByLevel(cId);

                Console.WriteLine();
                Console.WriteLine("Categories in level:");
                Console.WriteLine();
                foundCategories.ForEach(item => { Console.WriteLine(item.ToString()); });
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }


    }
}
