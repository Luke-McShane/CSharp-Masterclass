public class CSharpFundementalExercises
{
  private static void Main(string[] args)
  {
    //Declare and initialise variables
    string? input, addTodo;
    bool validTodo, removed;
    string[] validInputs = ["s", "S", "a", "A", "r", "R", "e", "E"];
    List<string> myList = [];
    Console.WriteLine("Hello!");

    //Begind do-while loop which will run until the user selects the Exit option
    do
    {
      Console.WriteLine("What would you like to do?");
      Console.WriteLine("[S]ee all todos.");
      Console.WriteLine("[A]dd a todo.");
      Console.WriteLine("[R]emove a todo.");
      Console.WriteLine("[E]xit");

      //Convert the users' input to uppercase to save code in the case statements.
      input = Console.ReadLine();
      if (input is not null) input = input.ToUpper();

      // Here is the switch statement way of handling user input
      switch (input)
      {
        case "S":
          //Print all items in the list of items, given the list of items contains at least one value
          if (myList.Count > 0)
          {
            foreach (string item in myList) { Console.WriteLine($"{myList.IndexOf(item) + 1}. {item}"); }
          }
          else { Console.WriteLine("No TODOs have been added yet."); }
          break;
        case "A":
          validTodo = false;
          //Prompt the user to add a TODO item until they enter a TODO that isn't already in the list of TODOs and isn't empty
          do
          {
            Console.WriteLine("Enter the TODO description:");
            addTodo = Console.ReadLine();
            if (addTodo is null || addTodo.Trim() == "")
            {
              Console.WriteLine("The description cannot be empty.");
              continue;
            }
            else if (myList.Contains(addTodo))
            {
              Console.WriteLine("The description must be unique.");
              continue;
            }
            else
            {
              //Add to TODO to the list of TODOs and set the validTodo bool to true so we can leave the do-while loop
              myList.Add(addTodo);
              validTodo = true;
              Console.WriteLine("TODO successfully added: " + addTodo);
            }
          } while (!validTodo);
          break;
        case "R":
          removed = false;
          //If the list of TODOs is empty, move to the next iteration of the outer loop
          if (myList.Count == 0)
          {
            Console.WriteLine("No TODOs have been added yet.");
            break;
          }
          do
          {
            //Print each element of the TODO list
            Console.WriteLine("Select the index of the TODO you want to remove:");
            foreach (string item in myList) { Console.WriteLine($"{myList.IndexOf(item) + 1}. {item}"); }
            string? removeTodo = Console.ReadLine();
            if (removeTodo == "") { Console.WriteLine("Selected index cannot be empty."); }
            //Initialise and declare the removeIndex var, which is set to the index of the item the user wants to delete.
            //Also we check if the user input is a number and that it is within the range of the list length.
            if ((int.TryParse(removeTodo, out int removeIndex)) && (removeIndex <= myList.Count) && (removeIndex > 0))
            {
              myList.RemoveAt(removeIndex - 1);
              removed = true;
            }
            else { Console.WriteLine("The given index is not valid.\n"); }
          } while (!removed);
          break;
        case "E":
          Console.WriteLine("Exit");
          break;
        default:
          Console.WriteLine("Incorrect input");
          break;
      }
      Console.WriteLine();
    } while (input != "E");
  }
}