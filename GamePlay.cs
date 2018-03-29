using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class GamePlay
  {
    //initialization of the current game
    Game currentGame = new Game();
    string userComm;
    public void Start()
    {
      //Conditions for default commands: Help, reset, inventory
      Console.Clear();
      System.Console.WriteLine(@"
          |+| Brave Young Warrior our forces are failing and the enemy grows stronger everyday.     |+| 
          |+| I fear if we don't act now there will be no hope for our people.                      |+| 
          |+| These dark times have left us with one final course of action.                        |+| 
          |+| We must rescue our princess and flee accross the sea...                               |+| 
          |+| Our sources have identified a small tunnel that leads into the rear of the castle.    |+| 
          |+| Your mission is to get in, save the princes and cause any damage you can while there. |+| 
        ");
      bool playing = true;
      while (playing)
      {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        //Starting room
        System.Console.WriteLine($"|+| {currentGame.CurrentPlayer.Name} | Score: {currentGame.CurrentPlayer.Score} |+| ");
        Console.ResetColor();
        System.Console.WriteLine($@"
You find yourself in a {currentGame.CurrentRoom.Name.ToUpper()}
************************************************************************************************************");
        System.Console.WriteLine(currentGame.CurrentRoom.Description);
        userComm = Console.ReadLine();
        //evaluating statement for proper action
        currentGame.CheckStatement(userComm);
        //Rescuing the Princess
        if (currentGame.CurrentRoom.Name == "Dungeon")
        {
          currentGame.CurrentPlayer.Inventory.ForEach(i =>
          {
            if (i.Name == "Heavy Key")
            {
              currentGame.PrincessFree = true;
              currentGame.CurrentPlayer.Score += 50;
            }
          });
          if (currentGame.PrincessFree)
          {
            Console.WriteLine(@"
            |+| You've unlocked the princess, now get out of the castle together.|+|");
          }
          else
          {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            Console.WriteLine(@"
            |+| You've found the princess, but you need a key to free her... Maybe look a little harder. |+|
            |+| Try looking in the room of someone of HIGH RANK.                                         |+|");
            Console.ResetColor();
          }
        }
        //Dying because you interrupted the sorcerer
        if (currentGame.CurrentRoom.Name == "Throne Room" || currentGame.CurrentRoom.Name == "Sewer")
        {
          System.Console.WriteLine(currentGame.CurrentRoom.Description);
          System.Console.WriteLine(@" 
          |+| You have died, the rescue has failed.Try again? (Y/N) |+| ");
          string died = Console.ReadLine();
          if (died[0] == 'n')
          {
            playing = false;
          }
          else
          {
            Console.Clear();
            currentGame.Reset();
          }
        }
        //Disguising yourself or dying in the fountain as you avoid the guards
        if (currentGame.CurrentRoom.Name == "Castle Courtyard")
        {
          if (currentGame.CurrentPlayer.ActiveItem.Equals("Guard Uniform") && !currentGame.PrincessFree)
          {
            currentGame.CheckStatement("guard");
            Console.WriteLine(@"
            |+| The guards take you as one of your own. They're heading back to the Barracks with you |+|");
          }
        }
        //Fountain Actions. Die or have straw to live
        if (currentGame.CurrentRoom.Name == "Fountain")
        {
          if (!currentGame.CurrentPlayer.HasStraw)
          {
            System.Console.WriteLine(@"
          |+| You forgot you can't swim. You die and the rescue Fails. Try again? (Y/N) |+|");
            string died = Console.ReadLine();
            if (died[0] == 'n')
            {
              playing = false;
            }
            else
            {
              Console.Clear();
              currentGame.Reset();
            }
          }
        }
        //Win scenario
        if (currentGame.CurrentRoom.Name == "Escape" && !currentGame.PrincessFree)
        {
          currentGame.CheckStatement("north");
          Console.WriteLine(@"
          |+| WHAT ARE YOU DOING? YOU HAVEN'T EVEN TRIED TO FIND THE PRINCESS |+|");
        }
        else if (currentGame.CurrentRoom.Name == "Escape" && currentGame.PrincessFree)
        {
          if (currentGame.CurrentPlayer.Score > 75)
          {
            Console.WriteLine(@"
          You've Escaped with the Princess, and better yet you've dealt a major blow to the enemy!!!
          Your people can flee across the sea. Now is the time to rebuild and plot your revenge. Play again? (Y/N)");
          }
          else if (currentGame.CurrentPlayer.Score < 75)
          {
            System.Console.WriteLine(@"
          You've Escaped, and better yet, you've done it with the princess!!
          You missed your chance to strike a bigger blow, but your people can flee across the sea.
          Now is the time to rebuild and plot your revenge. Play again? (Y/N)");
          }
          string again = Console.ReadLine();
          if (again[0] == 'n')
          {
            playing = false;
          }
          else
          {
            Console.Clear();
            currentGame.Reset();
          }
        }
      }
    }
  }
}
