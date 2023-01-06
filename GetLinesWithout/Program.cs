using System;
using System.Collections.Generic;
using System.IO;

namespace GetLinesWithout
{
  internal class Program
  {
    static void Main(string[] arguments)
    {
      if (arguments.Length == 0)
      {
        ShowUsage();
        return;
      }

      Action<string> Display = Console.WriteLine;
      Display("Application console to get lines from a file without a pattern string");
      var fileName = arguments[0];
      var newFileName = $"{fileName}-excluded-lines.txt";
      var pattern = arguments[1];
      var fileLines = new List<string>();
      var fileLinesResult = new List<string>();
      using (StreamReader sr = new StreamReader(fileName))
      {
        while (sr.Read() != -1)
        {
          fileLines.Add(sr.ReadLine());
        }
      }

      foreach (string line in fileLines)
      {
        if (!line.Contains(pattern))
        {
          fileLinesResult.Add(line);
        }
      }

      if (fileLinesResult.Count != 0)
      {
        using (StreamWriter sw = new StreamWriter(newFileName))
        {
          foreach (string line in fileLinesResult)
          {
            sw.WriteLine(line);
          }
        }

        Display($"The result search has been written into the file {newFileName}");
      }
      else
      {
        Display($"There is no pattern: {pattern} found in the file: {fileName}");
      }


      Display("Press any key to exit:");
      Console.ReadKey();
    }

    private static void ShowUsage()
    {
      Action<string> Display = Console.WriteLine;
      Display("Usage of the application console to get lines from a file with or without a pattern string");

      Display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
