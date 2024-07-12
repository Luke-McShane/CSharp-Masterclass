public class CSharpFundementalExercises
{
  public static void Entry()
  {
    Operators();
  }
  private static void Operators()
  {
    int a = 5, b = 10; // Declaring and initialising variables of the same type on one line
                       // var a = 5, b = 10; this is using implicit types, where the compiler determines the types based on the values declared.
                       // Declaration must happen on the same line as initialisation however, as otherwise the compiler won't know what type to assign the variable.

    Console.WriteLine("Addition: " + (a + b));
    Console.WriteLine("Subtraction: " + (a - b));
    Console.WriteLine("Division: " + b / a);
    Console.WriteLine("Multiplication: " + a * b);

    a++; //Increment the value by 1
    --b; //Decrement the value by 1

    if (a > b)
    {
      Console.WriteLine("a is larger than b");
    }
    else if (a < b)
    {
      Console.WriteLine("b is larger than a");
    }
    else Console.WriteLine("a is equal to b");

    while (a < b)
    {
      System.Console.WriteLine(a);
      ++a;
    }

    var myList = new List<int> { 1, 2, 3 };
    myList.AddRange([4, 5, 6]);
    myList.AddRange(new[] { 7, 8, 9 });
    /*
    Booleans:
    var isLargerOrEqualTo = a >= b;
    var isSmallerOrEqualTo = a <= b;
    var isLarger = a > b;
    var isSmaller = a < b;
    var isEven = 10 % 2 == 0;
    var isOdd = 10 % 3 == 1;
    */

    /*
    And/Or
    var isSmallerThan5AndEven = a < 5 && a % 2 = 0;
    var isSmallerThan5OrOdd = a < 5 || a % 2 = 1;
    */
  }
}
/*
NAMING CONVENTIONS & RESERVED KEYWORDS

We can use the '@' symbol preceding a reserved keyword to use it as a variable.
For example, @class, @string, @int may be used as variable names, whereas class, string, and into would not

We should always use lower camel case when naming variables, and never start a variable name with a number.

thisIsAGoodVariable, for example. Also this_variable works, but this-variable doesn't work.

Also, count != Count, as the capital letter differentiates these variables.

Use CTRL+R+R to rename all variables of the same name, if you have a poorly-named variable.


*/

/*
A for loop might look like this:
for(int i = 0; i < 5; i++) {
  print i;
}

A do-while loop might look like this:
do {
  print i;
  ++i;
} while (i < 10);
*/

/*
The break keyword can be used to break out of the loop.
The continue keyword can be used to continue to the next iteration of the loop.
One way we can check if all characters of a string are integers is using "myVar.All(char.IsDigit)"
*/

/*
Arrays

Arrays are classes, and therefore must be instantiated with the 'new' keyword.
int[] arr = new int[3];
Here first declare that we are creating an array of integers with 'int[]'.
Next we instatiate the array from the integer array class and define its size.
The size of the array must be defined when instantiated because arrays are immutable, meaning their sizes cannot be changed once initialised.
We can access elements of the array using arrp[0], where 0 points to the first element.

We can use the 'index from end' (^) operator to specify which digit from the end of the array we want to access.
var firstFromLast = arr[1]; // This will give the last element in the array.
var secondFromLast = arr[2]; // This will give the second to last element in the array.

We can define the elements of the array upon initialisation, and skip defining the length of the array for this will be inferred from the amount
of elements we specify within curly braces:

int[] myArr = new int[] {32, 53, 2, 9, 42};

This will instantiate an array of type int, with a length of 5, with each element defined.
We can go a step further and remove the type of the array, given this can also be inferred from the elements used in instantiation:

var myArr_2 = new [] {34, 12, 2, 5};
*/

/*
Multi-Dimensional Arrays

We declare a multidimensional array by using a comma. The more commas the more dimensions.

This array will have two rows, each row having 3 elements. All are initialised to 0.
This array looks like [[0, 0, 0], [0, 0, 0]]
int[,] arr = new int[2,3]; 

We can define the elements of our multi-dimensional array upon initialisation:
var myArr_2 = new int[,]
{
  {1, 2, 3},
  {4, 5, 6}
};

We can get the length of a dimension from an array using GetLength() and passing the index of the dimension as an argument.
For example, if we have this array:
int[] myArr = new int[2,3];

then myArr.GetLength(0) will return '2', whereas myArr.GetLength(1) will return '3'.

We access specific elements of a multidimensional array by specifying the location, for example 'myArr[0,2] = 3;'.
*/

/*
Foreach Loop

We can iterate through each member of an array using the foreach loop.

foreach(var item in arr){
  Console.WriteLine(item);
}
*/

/*
Lists

Lists are mutable, meaning their size can change. They are a generic type, meaning they are declared using angled brackets.
List<int> myList = new List<int>();

We can also instantiate the list with items using curly braces, similar to when we initialise an array:
List<int> myList = new List<int>
{
  1, 2, 3, 4, 5
};

We can remove an item by specifying the item we want to remove:
myList.Remove(4);

We can remove an item by specifying the index of the item we want to remove:
myList.RemoveAt(0);
This will remove the first item of the list.

We can get the length of the list using the .Count property. This is the equivalent to the .Length property for arrays.
in listLength = myList.Count;

We can add a collection (list/array) to an existing list using the 'AddRange' method:
var myList = new List<int> {1,2,3};
myList.AddRange([4,5,6]);
myList.AddRange(new[] {7,8,9});

We can check if a list contains an element using the 'Contains' method:
myList.Contains(5);
This returns a bool.

We can remove all elements in a list with the .Clear() method. This will reduce the number of elements in the list to 0.
myList.Clear();
*/

/*
Example method that checks if all letters in a list of strings are uppercase and contains only uppercase letters and builds a relevant list with
no duplicates:

public class Exercise
    { 
        public List<string> GetOnlyUpperCaseWords(List<string> words)
        {
            var result = new List<string>();
            foreach(string word in words){
                bool isUpper = true;
                int len = word.Length;
                for(int i = 0; i < len; ++i){
                    if (!char.IsUpper(word[i])){
                        isUpper = false;
                        break;
                    } ;
                    
                }
                if (!result.Contains(word) && isUpper) result.Add(word);
            }
            return result;
        }
    }
*/