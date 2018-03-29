using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool PrincessFree { get; set; }
    public bool Poison { get; set; }
    public bool Equipment { get; set; }

    // Constructor
    public Game()
    {
      CurrentRoom = SetupRooms();
      CurrentPlayer = SetupPlayer();
      PrincessFree = false;
      Poison = false;
      Equipment = false;
    }

    //Creating the Player
    public Player SetupPlayer()
    {
      Console.Clear();
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
      A few guards patrolling the area and there are a few loose bricks with some repair tools laying around. 
      The guards see you! Think quick, should you hide yourself in the fountain or disguise yourself?
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
      Plunging his jewel encrusted dagger into your heart your world slowly fades away.
      ");

      Room fountain = new Room("Fountain", @"
      You dove into the fountain to escape the oncomming guards.
      Good thing you have your bamboo straw. You'd drown otherwise!!");

      Room capitansQuarters = new Room("Capitans Quarters", @"
      As you approach the captains Quarters you swallow hard and notice your lips are dry,
      Stepping into the room you see a few small tables and maps of the countryside sprawled out.
      There doesn't seem to be anything of use here, and yet, maybe you should LOOK a little closer.");

      Room dungeon = new Room("Dungeon", @"
      As you descend the stairs to the dungeon you notice a harsh chill to the air.
      Landing a the base of the stairs you see what the remains of a previous prisoner.
      A GRATE leads to the sewers, might make for a quick escape route...");

      Room escape = new Room("Escape", @"
      You've Escaped, and better yet, you've done it with the princess!!
      Your people can flee across the sea.
      Now is the time to rebuild and plot your revenge. Play again?");

      Room sewer = new Room("Sewer", "The sewer grate was actually a MIMIC... DOH!");

      Room guardHouse = new Room("Guard House", @"
      Pushing open the door of the guard room you look around and notice the room is empty.
      There are a few small tools in the corner and a chair propped against the west wall near a door that likely leads to the dungeon.");

      Room storeRoom = new Room("Store Room", @"
      Large store room with weapons, armor, horse tack and other various implements of war.
      It'd be a shame if all this nice equipment were broken...");

      Room kitchen = new Room("Kitchen", @"
      Large castle kitchen, the smells are amazing, but potentially you could 
      poison it if only you had some poison...");

      Room northHallway = new Room("North Hallway", "Just more of the same ol' hallway...");




      //Hallway directions
      hallway.Directions.Add("north", northHallway);
      hallway.Directions.Add("south", courtyard);
      hallway.Directions.Add("east", barracks);
      hallway.Directions.Add("west", guardHouse);

      //North Hallway directions
      northHallway.Directions.Add("north", throneRoom);
      northHallway.Directions.Add("west", kitchen);
      northHallway.Directions.Add("south", hallway);


      //cortyard directions
      courtyard.Directions.Add("north", hallway);
      courtyard.Directions.Add("fountain", fountain);
      courtyard.Directions.Add("guard", barracks);
      courtyard.Directions.Add("south", escape);


      //barracks directions
      barracks.Directions.Add("north", capitansQuarters);
      barracks.Directions.Add("south", courtyard);
      barracks.Directions.Add("east", storeRoom);
      barracks.Directions.Add("west", hallway);

      //Capitans Quarters directions
      capitansQuarters.Directions.Add("south", barracks);

      //Guard House directions
      guardHouse.Directions.Add("west", dungeon);
      guardHouse.Directions.Add("east", hallway);

      //Dungeon directions
      dungeon.Directions.Add("east", guardHouse);
      dungeon.Directions.Add("south", sewer);

      //throne room directions
      throneRoom.Directions.Add("south", hallway);

      //fountain directions
      fountain.Directions.Add("north", courtyard);

      //escape directions
      escape.Directions.Add("north", courtyard);

      //Kitchen Directions
      kitchen.Directions.Add("east", northHallway);

      //Store Room Directions
      storeRoom.Directions.Add("west", barracks);


      //Item Creation
      Item uniform = new Item("Guard Uniform", "Uniform of the castle Guards");
      Item brick = new Item("Brick", "It's a Brick");
      Item key = new Item("Heavy Key", "A black iron key, suspiciously heavy...");
      Item straw = new Item("Odd Bamboo Straw", "A bamboo straw that looks big enough to breath through...");
      Item hammer = new Item("Masonry Hammer", "Large heavy hammer");
      Item mushrooms = new Item("Scary Looking Mushrooms", "Long stems with small black spotted caps... Kind of look like the poisonous nighshadow mushrooms from the forest.");

      //barracks Items
      barracks.Items.Add(uniform);

      //courtyard items
      courtyard.Items.Add(brick);
      courtyard.Items.Add(hammer);

      //capitans quarters items
      capitansQuarters.Items.Add(key);

      //Guard House Items
      guardHouse.Items.Add(straw);

      //Dungeon Items
      dungeon.Items.Add(mushrooms);

      return hallway;
    }

    public void TakeItem()
    {
      if (CurrentRoom.Items.Count > 0)
      {
        Console.WriteLine("Which Item?");
        for (int i = 0; i < CurrentRoom.Items.Count; i++)
        {
          System.Console.WriteLine($"{i + 1}. {CurrentRoom.Items[i].Name} | {CurrentRoom.Items[i].Description}");
        }
        int takenItem;
        string tI = Console.ReadLine();
        int.TryParse(tI, out takenItem);
        if (takenItem > -1 && takenItem <= CurrentRoom.Items.Count)
        {
          CurrentPlayer.Inventory.Add(CurrentRoom.Items[takenItem - 1]);
          System.Console.WriteLine($@"
      |+| You've added the {CurrentRoom.Items[takenItem - 1].Name} to your Inventory |+|");
          CurrentRoom.Items.RemoveAt((takenItem - 1));
        }
        else
        {
          System.Console.WriteLine(@"
      |+| Please make a valid selection |+|");
        }
      }
      else
      {
        System.Console.WriteLine(@"
      |+| There are No Items in this room. |+|");
      }
    }

    public void UseItem(string itemName)
    {
      CurrentPlayer.ActiveItem = itemName;
      System.Console.WriteLine($@"
      |+| You've equipped the {CurrentPlayer.ActiveItem} |+|");
      CurrentPlayer.Inventory.ForEach(i =>
                {
                  if (i.Name == itemName)
                  {
                    CurrentRoom.UseItem(i);
                    if (itemName == "Scary Looking Mushrooms" && CurrentRoom.Name == "Kitchen" && !Poison)
                    {
                      Poison = true;
                      CurrentPlayer.Score += 25;
                    }
                    else if (itemName == "Masonry Hammer" && CurrentRoom.Name == "Store Room" && !Equipment)
                    {
                      Equipment = true;
                      CurrentPlayer.Score += 25;
                    }
                    else
                    {
                      System.Console.WriteLine(@"
    |+| This item has no effect here. |+|
        ");
                    }
                  }
                });
    }

    public void Look()
    {
      Console.Clear();
      if (CurrentRoom.Name == "Capitans Quarters")
      {
        Console.WriteLine(@"
        |+| You look a little harder and find a KEY in a bottom desk drawer. This could come in handy! |+|");
      }
      System.Console.WriteLine($"{CurrentRoom.Description}");
    }

    // Writing the Help Menu
    public static void Help()
    {
      Console.Clear();
      System.Console.WriteLine(@"
************************************************************************************************************
`direction`
	- Moves your player from room to room.
	- Directions: `north`, `south`, `east`, `west`
    - Additional directions may be available based on the situation.
************************************************************************************************************
- `take item`
	- If there is an item that can be picked up, this command will bring up a menu of takeable items.
************************************************************************************************************
- `use <item>`
	- This command will bring up a menu of usable items. You can only have one active item equipped.
************************************************************************************************************
- `look`
	- Displays the Description of the current room, sometimes gives you a better look.
************************************************************************************************************
- `inventory`
	- This command will list of the current items in your inventory
************************************************************************************************************
_ 'reset'
    - If the adventure becomes too hard, this command will take you back to the beginning.
************************************************************************************************************
- 'quit'
    - quit out of the application.
************************************************************************************************************
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
          UseItem(CurrentPlayer.AssignItem());
          break;
        case "quit":
          System.Environment.Exit(1);
          break;
        default:
          if (!CurrentRoom.Directions.ContainsKey(userComm))
          {
            Console.WriteLine(@"
            |+| Wrong Way Dingus. Try again |+|");
            break;
          }
          Console.Clear();
          CurrentRoom = CurrentRoom.Directions[userComm];
          break;
      }
    }
  }
}