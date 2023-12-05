public static class Day4
{
  public static void Run()
  {
    var lines = File.ReadAllLines("./aoc23/day4/input.txt");
    var totalTotal = 0; 
    for(var i = 0; i < lines.Length; i++)
    {
      var cardParts = lines[i].Split(":");
      var cardTitle = cardParts[0];

      var numbers = cardParts[1].Split("|");

      var winningNumbers = new HashSet<string>(numbers[0].Split(" ", StringSplitOptions.RemoveEmptyEntries));
      var scratchedNumbers = new HashSet<string>(numbers[1].Split(" ", StringSplitOptions.RemoveEmptyEntries));

      var matchingNumbers = new HashSet<string>(scratchedNumbers.Intersect(winningNumbers));
      
      
      var cardPointTotal = 0;
      if(matchingNumbers.Count > 0)
      {
        for(var j = 0; j < matchingNumbers.Count; j++)
        {
          if(j == 0)
          {
            cardPointTotal = 1;
          }
          else
          {
            cardPointTotal *= 2;
          }
        }
      }
      totalTotal += cardPointTotal;
      Console.WriteLine($"{cardTitle}: total:{cardPointTotal} | {string.Join(", ", matchingNumbers)}");
    }
    Console.WriteLine($"totalTotal:{totalTotal}");
  }
}
