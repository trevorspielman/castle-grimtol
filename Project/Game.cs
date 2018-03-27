using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    // Constructor
    public Game()
    {
      CurrentRoom = SetupRooms();
      CurrentPlayer = SetupPlayer();
    }





    //Creating the Player
    public Player SetupPlayer()
    {
      System.Console.WriteLine("Welcome Brave Warrier, what is your Name?");
      string playerName = Console.ReadLine();
      Player player1 = new Player(playerName, 0);
      return player1;

    }

    //Creating all of the Rooms and selecting the Start Room
    public Room SetupRooms()
    {
      Room hallway = new Room("Hallway", "You find yourself in a small hall there doesnt appear to be anything of interest here. There are three doors. Go north, east, or south.");
      Room courtyard = new Room("Castle Courtyard", "You step into the large castle courtyard there is a flowing fountain in the middle of the grounds and a few guards patrolling the area");
      Room barracks = new Room("Barracks", "You see a room with several sleeping guards, The room smells of sweaty men. The bed closest to you is empty and there are several uniforms tossed about. There is a spare UNIFORM on a bed. Your only exit is back the way you came (west) or south to the courtyard");
      Room throneRoom = new Room("Throne Room", "As you unlock the door and swing it wide you see an enormous hall stretching out before you. At the opposite end of the hall sitting on his throne you see the dark lord. The Dark Lord shouts at you demanding why you dared to interrupt him during his Ritual of Evil Summoning... Dumbfounded you mutter an incoherent response. Becoming more enraged the Dark Lord complains that you just ruined his concentration and he will now have to start the ritual over... Quickly striding towards you he smirks at least I know have a sacrificial volunteer. Plunging his jewel encrusted dagger into your heart your world slowly fades away. You have died, the rebellion has failed.");

      //Hallway directions
      hallway.Directions.Add("north", throneRoom);
      hallway.Directions.Add("south", courtyard);
      hallway.Directions.Add("east", barracks);

      //cortyardwest directions
      courtyard.Directions.Add("north", hallway);

      //barracks directions
      barracks.Directions.Add("west", hallway);
      barracks.Directions.Add("south", courtyard);

      //throne room directions
      throneRoom.Directions.Add("south", hallway);

      //Item Creation
      Item uniform = new Item("Guard Uniform", "Uniform of the castle Guards");

      //barracks Items
      barracks.Items.Add(uniform);

      return hallway;
    }

    public void UseItem(string itemName)
    {
    }

    public void Look()
    {
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
        Console.WriteLine("Which Item?");
        for (int i = 0; i < CurrentRoom.Items.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {CurrentRoom.Items[i].Name} | {CurrentRoom.Items[i].Description}");
        }
        int takenItem;
        string tI = Console.ReadLine();
        int.TryParse(tI, out takenItem);
          CurrentPlayer.Inventory.Add(CurrentRoom.Items[takenItem - 1]);
          System.Console.WriteLine($"You've added the {CurrentRoom.Items[takenItem -1].Name} to your Inventory");
          break;
        case "use <item>":
        //need to build this in
        default:
        CurrentRoom = CurrentRoom.Directions[userComm];
          break;
      }
    }
  }
}