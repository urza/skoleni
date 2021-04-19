<Query Kind="Program" />

void Main()
{
	/*
	   10 nejcastejsich slov v kazdem souboru
	*/
	
	var dir = @"C:\PROJECTS\IctPro\Async\BigFiles\";

	Stopwatch w = new Stopwatch();
	w.Start();

    Dictionary<string,int> global_stats = new Dictionary<string, int>();
	
	foreach (var file in GetFiles(dir))
	{
		GetStatsForFile(file, global_stats);
	}
	
	PrintStats(global_stats);

	w.Stop();
	Console.WriteLine("elapsed ms: " + w.ElapsedMilliseconds);
}

void PrintStats(Dictionary<string, int> stats)
{
	var top10 = stats.OrderByDescending(x => x.Value).Take(10);

	foreach (var w in top10)
	{
		Console.WriteLine($"{w.Key}: {w.Value}");
	}

}

public IEnumerable<string> GetFiles(string dir)
{
	return Directory.EnumerateFiles(dir);
}

public void GetStatsForFile(string file, Dictionary<string, int> stats)
{
	System.IO.StreamReader open = new System.IO.StreamReader(file);
	
	string word;  
	
	while ((word = open.ReadLine()) != null)
	{
		if (stats.ContainsKey(word))
			stats[word]++;
		else
			stats.Add(word,1);
	}
}