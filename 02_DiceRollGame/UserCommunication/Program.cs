using DiceRollGame.GuessingGame;

System.Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");


Random random = new Random();
var dice = new Dice(random);
GameResult gameResult = dice.Play();
