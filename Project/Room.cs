using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, Room> Directions { get; set; }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Directions = new Dictionary<string, Room>();
    }



    public void UseItem(Item item)
    {
      string itemName = item.Name;
      switch (itemName)
      {
        case "Masonry Hammer":
          if (Name == "Store Room")
          {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            Description = @"
            |+| You have broken all of the war equipment, smashed the armor and torn the horse tack apart. |+| 
            |+| This will cripple the army for months as they strive to replace and repair the equipment.  |+| 
            ";
            System.Console.ResetColor();
          }
          break;
        case "Scary Looking Mushrooms":
          if (Name == "Kitchen")
          {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            Description = @"
            |+| You place the mushrooms in the large cookpots over the fire, they float on top for a moment, then dissolve into green goo. |+| 
            |+| Wheather or not this kills the men eating doesn't matter, they will be in extreme discomfort for quite some time. |+| 
            ";
            System.Console.ResetColor();
          }
          break;
        default:
          break;
      }
    }
    public void AdvancedLook(string roomName)
    {
      switch (roomName)
      {
        case "Capitans Quarters":
          System.Console.ForegroundColor = System.ConsoleColor.Green;
          System.Console.WriteLine(@"
        |+| You look a little harder and find a KEY in a bottom desk drawer. This could come in handy! |+|");
          System.Console.ResetColor();
          break;
        default:
          break;
      }
    }

  }
}