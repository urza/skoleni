<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var dir = @"C:\PROJECTS\IctPro\Async\BigFiles\";
	
	Parallel.ForEach(GetFiles(dir), (file) =>
	{
		var cnt = File.ReadAllLines(file).Count();
		Console.WriteLine($"{file}: {cnt}");
	});
}

public IEnumerable<string> GetFiles(string dir)
{
	return Directory.EnumerateFiles(dir);	
}


