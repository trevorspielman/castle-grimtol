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
        userComm = Console.ReadLine();
        //evaluating statement for proper action
        currentGame.CheckStatement(userComm);
      }
    }
  }
}
