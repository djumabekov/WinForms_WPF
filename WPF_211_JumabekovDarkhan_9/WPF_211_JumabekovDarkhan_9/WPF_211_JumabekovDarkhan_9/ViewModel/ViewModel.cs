using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_211_JumabekovDarkhan_9.Model;

namespace WPF_211_JumabekovDarkhan_9.ViewModel
{
  public class ViewModel
  {
    public static List<Item1> Items1 { get; set; }
    public static List<Item2> Items2 { get; set; }

    public ViewModel()
    {
      Items1 = new List<Item1>()
      {
        new Item1()
        {
          Item1First = "Item1_1",
          Item1Second = "Item1_2"
        },
         new Item1()
        {
          Item1First = "Item1_3",
          Item1Second = "Item1_4"
        },
           new Item1()
        {
          Item1First = "Item1_5",
          Item1Second = "Item1_6"
        }
      };
      Items2 = new List<Item2>()
      {
        new Item2()
        {
          Item2First = "Item2_1",
          Item2Second = "Item2_2"
        },
         new Item2()
        {
          Item2First = "Item2_3",
          Item2Second = "Item2_4"
        },
           new Item2()
        {
          Item2First = "Item2_5",
          Item2Second = "Item2_6"
        }
      };

    }
  }
}
