using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ToDoList
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}

// using System;
// using ToDoList.Models;
// using System.Collections.Generic;
// namespace ToDoList.Models
// {
//   public class Program
//   {

//     public static void Main()
//     {
//       List<Item> items = Item.GetAll();
//       Console.WriteLine("Welcome to the To-Do list press 'Y' to proceed");
//       string userInput = Console.ReadLine();
//       string lowerCase = userInput.ToLower();
//       if(lowerCase == "y")
//       {
//         addViewLoop();
//       }
//       else
//       {
//         Main();
//       }    
//     }
//       static void addViewLoop() 
//       {
//         List<Item> items = Item.GetAll();
//       Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View");
//       string userAnswer = Console.ReadLine();

//       if(userAnswer == "Add" || userAnswer == "add")
//       {
//         Console.WriteLine("Enter item you would like add: ");
//         string newUserItem = Console.ReadLine();
//         Item newItem = new Item(newUserItem);
//         Console.WriteLine(newItem.Description + " has been added to your list.");
//         addViewLoop();
//       }
//       else if(userAnswer == "View" || userAnswer == "view")
//       {
//         foreach (Item thisItem in items)
//         {
//           Console.WriteLine(thisItem.Description);
//         }
//         addViewLoop();
//       }
//       else
//       {
//         addViewLoop();
//       }
//     }   
//   }
// }