<Query Kind="Program" />

void Main()
{
	var dir = @"C:\PROJECTS\IctPro\Async\BigFiles\";
	
	Stopwatch w = new Stopwatch();
	w.Start();
	
	foreach(var file in GetFiles(dir))
	{
		var cnt = File.ReadAllLines(file).Count();
		Console.WriteLine($"{file}: {cnt}");
	}
	
	w.Stop();
	Console.WriteLine("elapsed ms: " + w.ElapsedMilliseconds);
}

public IEnumerable<string> GetFiles(string dir)
{
	return Directory.EnumerateFiles(dir);	
}