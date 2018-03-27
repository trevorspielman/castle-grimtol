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
          Brave Young Warrior our forces are failing and the enemy grows stronger everyday.
          I fear if we don't act now our people will be driven from their homes.
          These dark times have left us with one final course of action.
          We must cut the head off of the snake by assasinating the Dark Lord of Grimtol...
          Our sources have identified a small tunnel that leads into the rear of the castle.
        ");
      bool playing = true;
      while (playing)
      {
        //Starting room
        System.Console.WriteLine("You find yourself in a " + currentGame.CurrentRoom.Name);
        System.Console.WriteLine(currentGame.CurrentRoom.Description);
        userComm = Console.ReadLine();
        //evaluating statement for proper action
        currentGame.CheckStatement(userComm);
        if (currentGame.CurrentRoom.Name == "Throne Room")
        {
          System.Console.WriteLine(currentGame.CurrentRoom.Description);
          System.Console.WriteLine("You have died, the rebellion has failed.Try again? (Y/N)");
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
        if (currentGame.CurrentRoom.Name == "Courtyard")
        {
          if (currentGame.CurrentPlayer.ActiveItem.Equals("Guard Uniform"))
          {
            Console.Write("The guards take you as one of your own. They're heading back to the Barracks with you");
            currentGame.CheckStatement("guard");
          }
        }
        if (currentGame.CurrentRoom.Name == "Fountain")
        {
          System.Console.WriteLine("You forgot you can't swim. You die and the rebellion Fails. Try again? (Y/N)");
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
    }
  }
}
