using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool PrincessFree { get; set; }

    // Constructor
    public Game()
    {
      CurrentRoom = SetupRooms();
      CurrentPlayer = SetupPlayer();
      PrincessFree = false;
    }





    //Creating the Player
    public Player SetupPlayer()
    {
      System.Console.WriteLine("Welcome Brave Warrior, what is your Name?");
      string playerName = Console.ReadLine();
      Player player1 = new Player(playerName, 0);
      return player1;

    }

    //Creating all of the Rooms and selecting the Start Room
    public Room SetupRooms()
    {
      Room hallway = new Room("Hallway", "You find yourself in a small hall there doesnt appear to be anything of interest here. There are three doors. Go north, east, or south.");
      Room courtyard = new Room("Castle Courtyard", @"
      You step into the large castle courtyard there is a flowing fountain in the middle of the grounds.
      A few guards patrolling the area. Think quick, should you hide yourself in the fountain or disguise yourself?
      As your eyes dart around in a panic, do notice to the south a likely ESCAPE route");
      Room barracks = new Room("Barracks", @"
      You see a room with several sleeping guards, The room smells of sweaty men. The bed closest to you is empty and there are several uniforms tossed about. 
      There is a spare UNIFORM on a bed. Your only exit is back the way you came (west) or south to the courtyard");
      Room throneRoom = new Room("Throne Room", @"
      As you unlock the door and swing it wide you see an enormous hall stretching out before you.
      At the opposite end of the hall sitting on his throne you see the dark lord.
      The Dark Lord shouts at you demanding why you dared to interrupt him during his Ritual of Evil Summoning...
      Dumbfounded you mutter an incoherent response. Becoming more enraged the Dark Lord complains that you
      just ruined his concentration and he will now have to start the ritual over...
      Quickly striding towards you he smirks at least I know have a sacrificial volunteer.
      Plunging his jewel encrusted dagger into your heart your world slowly fades away.");
      Room fountain = new Room("Fountain", "You dove into the fountain to escape the oncomming guards. However, there's one issue...");
      Room capitansQuarters = new Room("Capitans Quarters", @"
      As you approach the captains Quarters you swallow hard and notice your lips are dry,
      Stepping into the room you see a few small tables and maps of the countryside sprawled out.
      There doesn't seem to be anything of use here, and yet, maybe you should LOOK a little closer.");
      Room dungeon = new Room("Dungeon", @"
      As you descend the stairs to the dungeon you notice a harsh chill to the air.
      Landing a the base of the stairs you see what the remains of a previous prisoner.");
      Room escape = new Room("Escape", @"
      You've Escaped, and better yet, you've done it with the princess!!
      Your people can flee across the sea.
      Now is the time to rebuild and plot your revenge. Play again?");


      //Hallway directions
      hallway.Directions.Add("north", throneRoom);
      hallway.Directions.Add("south", courtyard);
      hallway.Directions.Add("east", barracks);
      hallway.Directions.Add("west", dungeon);

      //cortyard directions
      courtyard.Directions.Add("north", hallway);
      courtyard.Directions.Add("fountain", fountain);
      courtyard.Directions.Add("guard", barracks);
      courtyard.Directions.Add("south", escape);


      //barracks directions
      barracks.Directions.Add("west", hallway);
      barracks.Directions.Add("south", courtyard);
      barracks.Directions.Add("north", capitansQuarters);

      //Capitans Quarters directions
      capitansQuarters.Directions.Add("south", barracks);

      //Dungeon directions
      dungeon.Directions.Add("east", hallway);

      //throne room directions
      throneRoom.Directions.Add("south", hallway);

      //fountain directions
      fountain.Directions.Add("out", courtyard);

      //escape directions
      escape.Directions.Add("north", courtyard);


      //Item Creation
      Item uniform = new Item("Guard Uniform", "Uniform of the castle Guards");
      Item brick = new Item("Brick", "It's a Brick");
      Item key = new Item("Heavy Key", "A black iron key, suspiciously heavy...");

      //barracks Items
      barracks.Items.Add(uniform);

      //courtyard items
      courtyard.Items.Add(brick);

      //capitans quarters items
      capitansQuarters.Items.Add(key);

      return hallway;
    }

    public void TakeItem()
    {
      Console.WriteLine("Which Item?");
      for (int i = 0; i < CurrentRoom.Items.Count; i++)
      {
        System.Console.WriteLine($"{i + 1}. {CurrentRoom.Items[i].Name} | {CurrentRoom.Items[i].Description}");
      }
      int takenItem;
      string tI = Console.ReadLine();
      int.TryParse(tI, out takenItem);
      CurrentPlayer.Inventory.Add(CurrentRoom.Items[takenItem - 1]);
      System.Console.WriteLine($"You've added the {CurrentRoom.Items[takenItem - 1].Name} to your Inventory");
    }

    public void UseItem(string itemName)
    {
      CurrentPlayer.ActiveItem = itemName;
    }

    public void Look()
    {
      if (CurrentRoom.Name == "Capitans Quarters")
      {
        Console.WriteLine("You look a little harder and find a KEY in a bottom desk drawer. This could come in handy!");
      }
      System.Console.WriteLine($"{CurrentRoom.Description}");
    }

    // Writing the Help Menu
    public static void Help()
    {
      System.Console.WriteLine(@"
-	`go <direction>`
	- Moves your player from room to room.
	- Directions: `north`, `south`, `east`, `west`
- `take <item>`
	- If an item can be picked up this command will put the item in your inventory
- `use <item>`
	- Uses an item from your inventory or in the room
- `look`
	- Displays the Description of the current room
- `inventory`
	- This command will list of the current items in your inventory
_ 'reset'
    - If the adventure becomes too hard, this command will take you back to the beginning.
- 'quit'
    - quit out of the application.
        ");
    }

    //Reset Method
    public void Reset()
    {
      GamePlay newGame = new GamePlay();
      newGame.Start();
    }

    public void CheckStatement(string userComm)
    {
      switch (userComm)
      {
        case "help":
          Help();
          break;
        case "reset":
          Console.Clear();
          Reset();
          break;
        case "inventory":
          CurrentPlayer.InventoryCheck();
          break;
        case "look":
          Look();
          break;
        case "take item":
          TakeItem();
          break;
        case "use item":
          System.Console.WriteLine("Which Item?");
          for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
          {
            System.Console.WriteLine($"{i + 1}. {CurrentPlayer.Inventory[i].Name}");
          }
          int chosenItem;
          string cI = Console.ReadLine();
          int.TryParse(cI, out chosenItem);
          UseItem(CurrentPlayer.Inventory[chosenItem - 1].Name);
          break;
        case "quit":
          System.Environment.Exit(1);
          break;
        default:
          if (!CurrentRoom.Directions.ContainsKey(userComm))
          {
            Console.WriteLine("Wrong Way Dingus. Try again");
            break;
          }
          Console.Clear();
          CurrentRoom = CurrentRoom.Directions[userComm];
          break;
      }
    }
  }
}