﻿

bool endApp = false;
int count = 0;
List<string> latest = new List<string>();
var mapping = new Dictionary<string, string>()
{
    { "a", "+" },
    { "m", "*" },
    { "d", "/" },
    { "s", "-" }
};

// Display title as the C# console calculator app.
Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

while (!endApp)
{
    // Declare variables and set to empty.
    string numInput1 = "";
    string numInput2 = "";
    double result = 0;

    // Ask the user to type the first number.
    Console.Write("Type a number, and then press Enter: ");
    numInput1 = Console.ReadLine();

    double cleanNum1 = 0;
    while (!double.TryParse(numInput1, out cleanNum1))
    {
        Console.Write("This is not valid input. Please enter an integer value: ");
        numInput1 = Console.ReadLine();
    }

    // Ask the user to type the second number.
    Console.Write("Type another number, and then press Enter: ");
    numInput2 = Console.ReadLine();

    double cleanNum2 = 0;
    while (!double.TryParse(numInput2, out cleanNum2))
    {
        Console.Write("This is not valid input. Please enter an integer value: ");
        numInput2 = Console.ReadLine();
    }

    // Ask the user to choose an operator.
    Console.WriteLine("Choose an operator from the following list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.Write("Your option? ");

    string op = Console.ReadLine();

    try
    {
        result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
        if (double.IsNaN(result))
        {
            Console.WriteLine("This operation will result in a mathematical error.\n");
        }
        else
        {
            Console.WriteLine("Your result: {0:0.##}\n", result);
            count++;
            Console.WriteLine("calculator used: " + count);
            latest.Add($"{cleanNum1} {mapping[op]} {cleanNum2} = {result}");
            foreach (var item in latest)
            {
                Console.WriteLine(item);
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
    }

    Console.WriteLine("------------------------\n");
    Console.Write("Delete latest list? press (y/n) ");
    string input = Console.ReadLine();
    if (input == "y")
    {
        latest.Clear();
        count = 0;
    }
    else Console.WriteLine("list not deleted.");
    // Wait for the user to respond before closing.
    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "n") endApp = true;

    Console.WriteLine("\n"); // Friendly linespacing.
}

