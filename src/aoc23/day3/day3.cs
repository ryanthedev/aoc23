public static class Day3
{
  public static void Run()
  {
    var lines = File.ReadAllLines("./aoc23/day3/input.txt");
    IList<string> validNums = [];

    for(var i = 0; i < lines.Length; i++)
    {
      for(var j = 0; j < lines[i].Length; j++)
      {
        if(int.TryParse(lines[i][j].ToString(), out var num))
        {
          var lastNumIndex = FindLastNumberIndex(lines[i], j);
          var number = lines[i].Substring(j, lastNumIndex - j + 1);
          Console.WriteLine($"Found: {number}");

          if((i != 0) && ContainsSymbol(lines[i - 1], j - 1, lastNumIndex + 1))
          {
            Console.WriteLine($"has symbol: {number} above");
            validNums.Add(number);
          }
          else if(ContainsSymbol(lines[i], j - 1, lastNumIndex + 1))
          {
            Console.WriteLine($"has symbol: {number} next to");
            validNums.Add(number);
          }
          else if((i + 1) < lines.Length && ContainsSymbol(lines[i + 1], j - 1, lastNumIndex + 1))
          {
            Console.WriteLine($"has symbol: {number} below");
            validNums.Add(number);
          }

          j = lastNumIndex + 1;
        }
      }
    }
    
    var total = 0;
    foreach(var validNum in validNums)
    {
      total += int.Parse(validNum);
    }
    Console.WriteLine($"total: {total}");

  }

  private static bool ContainsSymbol(string line, int start, int end)
  {
    if (start < 0)
    {
      start = 0;
    }

    if (line.Length <= end)
    {
      end = line.Length - 1;
    }

    Console.WriteLine($"Checking: {line.Substring(start, end - start + 1)}");

    for(var i = start; i <= end; i++)
    {
      if(line[i].Equals('.'))
      {
        continue;
      }
      else if(int.TryParse(line[i].ToString(), out var _))
      {
        continue;
      }
      else
      {
        return true;
      }
    }
    return false;
  } 

  private static int FindLastNumberIndex(string line, int i)
  {
    i++;
    while(i < line.Length)
    {
      if(int.TryParse(line[i].ToString(), out var _))
      {
        i++;
      }
      else
      {
        break;
      }
    }
    return i - 1;
  }
}
