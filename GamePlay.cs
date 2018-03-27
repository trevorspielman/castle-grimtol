using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class GamePlay
  {
    public void Start()
    {
      Room currentRoom = init();
      Player currentPlayer = create();
      Game currentGame = setUpGame();


      //Conditions for default commands: Help, reset, inventory
      switch (Console.ReadLine().ToLower())
      {
        case "help":
          Game.Help();
          break;
        case "restart":
          currentGame.Reset();
          Console.Clear();
          break;
        case "inventory":
          currentPlayer.InventoryCheck();
          break;
        case "look":
          currentRoom.Look();
          break;
        case "take <item>":
          //need to build this in
          break;
        case "use <item>":
          //need to build this in
          break;
        default:
          System.Console.WriteLine("Invalid insruction. Please try again");
          Console.ReadLine();
          break;
      }

      //Create Player
      Player create()
      {
        System.Console.WriteLine("Welcome Brave Warrier, what is your Name?");
        string playerName = Console.ReadLine();
        Player player1 = new Player(playerName, 0);
        return player1;
      }

      //Creating the Rooms
      Room init()
      {
        Room r1 = new Room("Castle Courtyard", "You step into the large castle courtyard there is a flowing fountain in the middle of the grounds and a few guards patrolling the area");
        Room r2 = new Room("Hallway", "You find yourself in a small hall there doesnt appear to be anything of interest here.");
        Room r3 = new Room("Barracks", "You see a room with several sleeping guards, The room smells of sweaty men. The bed closest to you is empty and there are several uniforms tossed about.");
        Room r4 = new Room("Throne Room", "As you unlock the door and swing it wide you see an enormous hall stretching out before you. At the opposite end of the hall sitting on his throne you see the dark lord. The Dark Lord shouts at you demanding why you dared to interrupt him during his Ritual of Evil Summoning... Dumbfounded you mutter an incoherent response. Becoming more enraged the Dark Lord complains that you just ruined his concentration and he will now have to start the ritual over... Quickly striding towards you he smirks at least I know have a sacrificial volunteer. Plunging his jewel encrusted dagger into your heart your world slowly fades away. You have died, the rebellion has failed.");

        r1.Directions.Add("next", r2);
        r2.Directions.Add("previous", r1);
        r2.Directions.Add("next", r3);
        r3.Directions.Add("previous", r2);
        r3.Directions.Add("next", r4);
        r4.Directions.Add("previous", r3);

        return r1;
      }
      Game setUpGame()
      {
        Game gameSetup = new Game(currentRoom, currentPlayer);
        return gameSetup;
      }

      System.Console.WriteLine(@"
          Brave Young Warrior our forces are failing and the enemy grows stronger everyday.
          I fear if we don't act now our people will be driven from their homes.
          These dark times have left us with one final course of action.
          We must cut the head off of the snake by assasinating the Dark Lord of Grimtol...
          Our sources have identified a small tunnel that leads into the rear of the castle.
        ");

      System.Console.WriteLine(currentRoom.Name);
      currentRoom = currentRoom.Directions["next"];
      System.Console.WriteLine(currentRoom.Name);
      currentRoom = currentRoom.Directions["next"];
      System.Console.WriteLine(currentRoom.Name);
      currentRoom = currentRoom.Directions["previous"];
      System.Console.WriteLine(currentRoom.Name);
    }

  }
}
