// See https://aka.ms/new-console-template for more information
for (;;)
{
  Console.WriteLine("Enter a date (YYYY-MM-DD or DD/MM/YYYY) or 'exit' to quit:");
  string userInput = Console.ReadLine();

  if (userInput.ToLower() == "exit")
  { 
    Console.WriteLine("Exiting program...");
    break;
  }

  DateTime userDate;
  if (DateTime.TryParse(userInput, out userDate))
  {
    CalculateDateDifference(userDate);
  }
  else if (DateTime.TryParse(userInput, out userDate)) {
    CalculateDateDifference(userDate);
  }
  else
  {
    Console.WriteLine("Invalid date format. Please enter YYYY-MM-DD.");
  }
}

static void CalculateDateDifference(DateTime userDate)
{
  DateTime currentDate = DateTime.Now.Date;
  TimeSpan difference = userDate - currentDate;

  if (difference.Days > 0)
  {
    Console.WriteLine($"The date you entered is {difference.Days} days in the future.");
  }
  else if (difference.Days < 0)
  {
    Console.WriteLine($"The date you entered has passed {Math.Abs(difference.Days)} days ago.");
  }
  else
  {
    Console.WriteLine("The date you entered is today!");
  }
}
