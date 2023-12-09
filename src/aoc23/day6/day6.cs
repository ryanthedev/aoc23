public static class Day6
{
  public static void Run()
  {
    var lines = File.ReadAllLines("./aoc23/day6/input");
    var times = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var distances = lines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

    var totalWaysToWin = new List<int>();
    for(var i = 0; i < times.Length; i++)
    {
      var time = int.Parse(times[i]);
      var distance = int.Parse(distances[i]);
      var wins = 0;
      for(var j = 0; j < time; j++)
      {
        var timeButtonIsHeld = time - j;
        var distanceTraveled = timeButtonIsHeld * j;
        Console.WriteLine($"Time:{time} tbh:{timeButtonIsHeld} j:{j} distanceTraveled:{distanceTraveled} record:{distance}");
        if(distance < distanceTraveled)
        {
          wins++;
        }
      }
      totalWaysToWin.Add(wins);
      Console.WriteLine("-----");
    }
    var magicNumber = 1;
    foreach(var winCombo in totalWaysToWin)
    {
      magicNumber *= winCombo;
    }
    Console.WriteLine($"magic:{magicNumber}");
  }
}

