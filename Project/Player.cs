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
      Score = score;
      ActiveItem = "";
      Inventory = new List<Item>();
      HasStraw = false;
    }

    public void InventoryCheck()
    {
      for (int i = 0; i < this.Inventory.Count; i++)
      {
        System.Console.WriteLine($"{i + 1}. {this.Inventory[i].Name}");
      }
    }

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
        System.Console.WriteLine(@"
            |+| Please make a valid selection |+|");
        return null;
      }
    }


  }
}
