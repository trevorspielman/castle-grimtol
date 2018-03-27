using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public Game(Room currentRoom, Player currentPlayer)
    {
        CurrentRoom = currentRoom;
        CurrentPlayer = currentPlayer;
    }

    public void Reset()
    {
      GamePlay newGame = new GamePlay();
      newGame.Start();
    }

    public void Setup()
    {

    }

    public void UseItem(string itemName)
    {
    }
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
  }
}