<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var dir = @"C:\PROJECTS\IctPro\Async\BigFiles\";

	Stopwatch w = new Stopwatch();
	w.Start();

	Parallel.ForEach(GetFiles(dir), (file) =>
	{
		var cnt = File.ReadAllLines(file).Count();
		Console.WriteLine($"{file}: {cnt}");
	});

	w.Stop();
	Console.WriteLine("elapsed ms: " + w.ElapsedMilliseconds);
}

public IEnumerable<string> GetFiles(string dir)
{
	return Directory.EnumerateFiles(dir);	
}


