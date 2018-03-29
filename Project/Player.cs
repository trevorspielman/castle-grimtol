using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public int Score { get; set; }
    public List<Item> Inventory { get; set; }
    public string ActiveItem { get; set; }
    public bool HasStraw { get; set; }

    public Player(string name, int score)
    {
      Name = name;
      Score = 0;
      ActiveItem = "";
      Inventory = new List<Item>();
      HasStraw = false;
    }


//functionality for displaying the inventory.
    public void InventoryCheck()
    {
      for (int i = 0; i < this.Inventory.Count; i++)
      {
        System.Console.WriteLine($"{i + 1}. {this.Inventory[i].Name}");
      }
    }

//checking to see if the straw is in the inventory. If it is, you don't drown in the fountain
    public void StrawCheck()
    {
      Inventory.ForEach(i =>
                {
                  if (i.Name == "Odd Bamboo Straw")
                  {
                    HasStraw = true;
                  }
                });
    }

    //Assigning item to active item. Basically converting from an Item to a string.
    public string AssignItem()
    {
      System.Console.WriteLine("Which Item?");
      for (int i = 0; i < Inventory.Count; i++)
      {
        System.Console.WriteLine($"{i + 1}. {Inventory[i].Name}");
      }
      int chosenItem;
      string cI = System.Console.ReadLine();
      int.TryParse(cI, out chosenItem);
      if (chosenItem > -1 && chosenItem <= Inventory.Count)
      {
        return Inventory[chosenItem - 1].Name;
      }
      else
      {
        System.Console.ForegroundColor = System.ConsoleColor.Red;
        System.Console.WriteLine(@"
            |+| Please make a valid selection |+|");
        System.Console.ResetColor();
        return null;
      }
    }


  }
}
