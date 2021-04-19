<Query Kind="Program" />

void Main()
{
	/*
	   10 nejcastejsich slov v kazdem souboru
	*/
	
	var dir = @"C:\PROJECTS\IctPro\Async\BigFiles\";

	Stopwatch w = new Stopwatch();
	w.Start();

	foreach (var file in GetFiles(dir))
	{
		PrintStatsForFile(file);
	}

	w.Stop();
	Console.WriteLine("elapsed ms: " + w.ElapsedMilliseconds);
}

public IEnumerable<string> GetFiles(string dir)
{
	return Directory.EnumerateFiles(dir);
}

public void PrintStatsForFile(string file)
{
	Dictionary<string,int> stats = new Dictionary<string, int>();
	System.IO.StreamReader open = new System.IO.StreamReader(file);
	
	string word;  
	
	while ((word = open.ReadLine()) != null)
	{
		if (stats.ContainsKey(word))
			stats[word]++;
		else
			stats.Add(word,1);
	}
	
	var top10 = stats.OrderByDescending(x => x.Value).Take(10);
	
	Console.WriteLine(file);
	foreach(var w in top10)
	{
		Console.WriteLine($"{w.Key}: {w.Value}");
	}
	Console.WriteLine();
	
}