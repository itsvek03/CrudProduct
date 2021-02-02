using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
        inelk:
            Console.WriteLine("Press 1: Add Product \n" +
                              "Press 2:View Product \n"+
                              "Press 3:Update Product \n" +
                              "Press 4:Remove Product \n" +
                              "Press 5:Exit \n" 
                              );

            int choice;
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                //Write the data
                case 1:
                {
                        Console.Write("Enter the ID :");
                        product.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter the Product Name :");
                        product.Name = Console.ReadLine();

                        Console.Write("Enter the Price of the product :");
                        product.Price= Convert.ToInt32(Console.ReadLine());

                        StreamWriter sw = new StreamWriter(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt", true);
                        sw.WriteLine(product.Id+ new String(' ', 3)+ product.Name+ new String(' ',4)+product.Price);
                        sw.Close();
                        goto inelk;
                        
                 }
                    //read the data
                case 2:
                 {
                        StreamReader sm = new StreamReader(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt");
                        Console.WriteLine(sm.ReadToEnd());
                        Console.WriteLine("-----------------");
                        sm.Close();
                        goto inelk;
                       
                 }
                    //edit the data
                case 3:
                 {
                        Console.WriteLine("Update the record of the product");
                        Console.Write("Enter the Id of the Product: ");
                        int pid = Convert.ToInt32(Console.ReadLine());
                        var oldlines = System.IO.File.ReadAllLines(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt");
                        var newlines = oldlines.Where(line => !line.Contains(pid.ToString()));
                        if (oldlines.Length == newlines.Count())
                        {
                            Console.WriteLine("Invalid ID");
                            goto inelk;
                        }
                        System.IO.File.WriteAllLines(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt", newlines);
                        FileStream obj = new FileStream(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt", FileMode.Append);
                        obj.Close();
                        Console.Write("Enter the new ID :");
                        product.Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the new Product Name :");
                        product.Name = Console.ReadLine();
                        Console.Write("Enter the new Price of the product :");
                        product.Price = Convert.ToInt32(Console.ReadLine());
                        StreamWriter sw = new StreamWriter(@"C:\Data\product.txt", true);
                        sw.WriteLine(product.Id + new String(' ', 3) + product.Name + new String(' ', 4) + product.Price);
                        sw.Close();
                        goto inelk;
                        
                 }

                 //Delete the data
                case 4:
                  {
                        Console.WriteLine("Delete the record of the product");
                        Console.Write("Enter the Id of the Product: ");
                        int pid = Convert.ToInt32(Console.ReadLine());
                        
                        var oldlines = System.IO.File.ReadAllLines(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt");
                        //Console.WriteLine(oldlines.Length);
                        var newlines = oldlines.Where(line => !line.Contains(pid.ToString()));

                        //Console.WriteLine(newlines.Count());

                        if(oldlines.Length == newlines.Count())
                        {
                            Console.WriteLine("Invalid ID");
                            goto inelk;
                        }

                        System.IO.File.WriteAllLines(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt", newlines);
                        FileStream obj = new FileStream(@"C:\Users\HP\source\repos\CrudProduct\CrudProduct\Product.txt", FileMode.Append);
                        obj.Close();
                        goto inelk;     
                  }

                case 5:
                 {
                        Console.WriteLine("Closing the Application");
                        Environment.Exit(1);
                        break;
                 }
                default:
                    Console.WriteLine("Please Enter the number between 1 to 5");
                    goto inelk;
            }
            Console.ReadKey();
        }
    }
}
