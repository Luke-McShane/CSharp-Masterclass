public class CSharpFundementalExercises
{
  private static void Main(string[] args)
  {
    string? input, addTodo;
    bool validTodo, removed;
    string[] validInputs = ["s", "S", "a", "A", "r", "R", "e", "E"];
    List<string> myList = [];
    Console.WriteLine("Hello!");
    do
    {
      Console.WriteLine("What would you like to do?");
      Console.WriteLine("[S]ee all todos.");
      Console.WriteLine("[A]dd a todo.");
      Console.WriteLine("[R]emove a todo.");
      Console.WriteLine("[E]xit");

      input = Console.ReadLine();
      if (input is not null) input = input.ToUpper();

      // Here is the switch statement way of handling user input
      switch (input)
      {
        case "S":
          if (myList.Count > 0)
          {
            foreach (string item in myList) { Console.WriteLine($"{myList.IndexOf(item) + 1}. {item}"); }
          }
          else { Console.WriteLine("No TODOs have been added yet."); }
          break;
        case "A":
          validTodo = false;
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
              myList.Add(addTodo);
              validTodo = true;
              Console.WriteLine("TODO successfully added: " + addTodo);
            }
          } while (!validTodo);
          break;
        case "R":
          removed = false;
          if (myList.Count == 0)
          {
            Console.WriteLine("No TODOs have been added yet.");
            break;
          }
          do
          {
            Console.WriteLine("Select the index of the TODO you want to remove:");
            foreach (string item in myList) { Console.WriteLine($"{myList.IndexOf(item) + 1}. {item}"); }
            string? removeTodo = Console.ReadLine();
            Console.WriteLine("User Input: " + removeTodo);
            Console.WriteLine("List Length: " + myList.Count);
            if (removeTodo == "") { Console.WriteLine("Selected index cannot be empty."); }
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