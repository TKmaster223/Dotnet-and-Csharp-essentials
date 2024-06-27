using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter a date (mm/dd/yyyy) or 'exit' to quit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            string result = ReverseDateFormat(input);

            if (result != null)
            {
                Console.WriteLine($"Converted Date: {result}");
            }
            else
            {
                Console.WriteLine("Invalid date format, try again por favor 🙂");
            }
        }
    }

    static string ReverseDateFormat(string input)
    {
        string pattern = @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$";
        TimeSpan timeout = TimeSpan.FromMilliseconds(1000);

        try
        {
            // Use Regex with timeout
            Regex regex = new Regex(pattern, RegexOptions.None, timeout);
            Match match = regex.Match(input);

            if (match.Success)
            {
                string year = match.Groups["year"].Value;
                string month = match.Groups["mon"].Value.PadLeft(2, '0');
                string day = match.Groups["day"].Value.PadLeft(2, '0');

                // Ensure the year is in 4-digit format
                if (year.Length == 2)
                {
                    year = "19" + year; // Assuming dates are in the 20th century
                }

                return $"{year}-{month}-{day}";
            }
            else
            {
                return null;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            Console.WriteLine("The regex operation timed out.");
            return input; // Return the original input in case of a timeout
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            return null;
        }
    }
}
