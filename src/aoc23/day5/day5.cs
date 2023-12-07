public static class Day5
{
  public static void Run()
  {
    var lines = File.ReadAllLines("./aoc23/day5/input.txt");
    var seeds = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(val => long.Parse(val)).ToList();

    var maps = new Dictionary<int, List<(long, long, long)>>();
    int mapCounter = 0;
    for(var i = 2; i < lines.Length; i++)
    {
      if(lines[i].Length == 0)
      {
      }
      else if(Char.IsAsciiLetter(lines[i][0]))
      {
        mapCounter++;
        maps[mapCounter] = new List<(long, long, long)>();
      }
      else
      {
        var nums = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(val => long.Parse(val)).ToList();
        maps[mapCounter].Add((nums[0], nums[1], nums[2]));
      }
    }

    var locations = new List<long>();
    foreach(var seed in seeds)
    {
      var translation = seed;
      foreach(var map in maps)
      {
        foreach(var mapping in map.Value)
        {
          var (dest, src, rng) = mapping;
          if ((translation > src) && (translation < src + rng))
          {
            translation = (translation - src) + dest;
            break;
          }
        }
      }
      locations.Add(translation);
    }
    Console.WriteLine($"min: {locations.Min()}");
  }
}
