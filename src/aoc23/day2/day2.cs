public static class Day2
{
  private static Dictionary<string, int> _maxCubeColors = new Dictionary<string, int>()
  {
    {"red", 12},
    {"green", 13},
    {"blue", 14}
  };
  public static void Run()
  {
    var lines = File.ReadAllLines("./aoc23/day2/input.txt");
    var validGames = new List<string>();

    for(var i = 0; i < lines.Length; i++)
    {
      var line = lines[i];
      var gameParts = line.Split(":");
      var subGames = gameParts[1].Split(";");
      var validGame = true;
      Console.WriteLine($"checking game:{gameParts[0]}");
      foreach(var subGame in subGames)
      {
        Console.WriteLine($"--subGame:{subGame}");
        var selectedCubes = subGame.Split(",", StringSplitOptions.RemoveEmptyEntries);
        foreach(var cubeSet in selectedCubes)
        {
          Console.WriteLine($"----cubeSet:{cubeSet}");
          var cubeCountAndColor = cubeSet.Split(" ", StringSplitOptions.RemoveEmptyEntries);
          var count = int.Parse(cubeCountAndColor[0]);
          var color = cubeCountAndColor[1];
          
          var matchingColorLimit = _maxCubeColors[color];
          if(matchingColorLimit < count)
          {
            Console.WriteLine($"invalid game:{gameParts[0]} | Color:{color} | Count:{count}");
            validGame = false;
            break;
          }
        }
        if(!validGame)
          break;
      }
      if(validGame)
      {
        Console.WriteLine($"valid game:{gameParts[0]}");
        validGames.Add(gameParts[0]);
      }
    }
    //now we need to sum up the winning games
    var gameTotal = 0;
    foreach(var gameTitle in validGames)
    {
      var gameNumber = int.Parse(gameTitle.Split(" ")[1]);
      gameTotal += gameNumber;
    } 
    Console.WriteLine($"total: {gameTotal}");
  }
}
