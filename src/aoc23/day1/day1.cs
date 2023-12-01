public static class Day1
{
  public static void Run()
  {
    var lines = File.ReadAllLines("./aoc23/day1/input.txt");
    var total = 0;
    foreach(var line in lines)
    {
      var nums = new List<string>();
      for(var i = 0; i < line.Length; i++)
      {
        if(int.TryParse(line[i].ToString(), out _))
        {
          nums.Add(line[i].ToString());
        }
      }
      var val = int.Parse($"{nums.First()}{nums.Last()}"); 
      total += val;
    }
    Console.WriteLine($"total:{total}");
  }
}
