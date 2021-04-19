<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	//var lines = File.ReadAllLines(@"C:\PROJECTS\PassphraseGenCZCsharp\syn2010_word_abc_full.txt");
	var lines = File.ReadAllLines(@"C:\PROJECTS\PassphraseGenCZCsharp\syn2010_word_common_bezdia.txt");

	var saveAs = @"C:\PROJECTS\IctPro\Async\BigFiles\words11.txt";
	
	genBigFileOfLines(saveAs,1000000,lines);
	
}

private void genBigFileOfWords(string filePath, int numWords, string[] lines)
{
	for (int k = 0; k < 1000; k++)
	{
		List<string> words = new List<string>();

		for (int i = 0; i < numWords / 1000; i++)
		{
			var word = lines[rndInt(0, lines.Count())];
			words.Add(word);
		}

		File.AppendAllText(filePath, string.Join(" ", words));
	}
}

private void genBigFileOfLines(string filePath, int numWords, string[] lines)
{
	for (int k = 0; k < 10; k++)
	{
		List<string> words = new List<string>();

		for (int i = 0; i < numWords / 10; i++)
		{
			var word = lines[rndInt(0, lines.Count())];
			words.Add(word);
		}
		
		File.AppendAllLines(filePath,words);
	}
}

private void genSimle(int numWords, string[] lines)
{
	//simple - jen slova
	List<string> words = new List<string>();

	for (int i = 0; i < numWords; i++)
	{
		var word = lines[rndInt(0, lines.Count())];
		words.Add(word);
	}
	Console.WriteLine(string.Join($" ", words));
}

private void genRegular(string[] lines)
{
	//regular - nekolik slov spojenych nahodnym separatorem, obcas cisla, obcas neco uppercase
	var specials = @" +-*/";
	var special = specials[rndInt(0, specials.Count())];
	var uppercase1 = rndInt(0, 10);
	var uppercase2 = rndInt(0, 10);
	var numbers = rndInt(0, 10);
	var number = rndInt(1000, 99999);
	List<string> words = new List<string>();

	for (int i = 0; i < 5; i++)
	{
		var word = lines[rndInt(0, lines.Count())];
		if (i == uppercase1 || i == uppercase2)
			word = word.ToUpper();
		if (i == numbers)
			word = number.ToString();

		words.Add(word);
	}
	Console.WriteLine(string.Join($"{special}", words));
}

private void genStealth(string[] lines)
{

	//stealth - aby na prvni pohled vpadalo jako veta (obcas neco jako cislo popisne)
	var specials = @".?!";
	var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUWXYZ";
	var special = specials[rndInt(specials.Count())];
	var numbers = rndInt(10);
	var number1 = rndInt(1, 99);
	var number2 = rndInt(100, 999);
	List<string> words = new List<string>();

	for (int i = 0; i < 5; i++)
	{

		var word = lines[rndInt(0, lines.Count())];

		if (i == 0)
			word = word.First().ToString().ToUpper() + word.Substring(1);

		if (i == numbers)
		{
			int typ = rndInt(0, 3);
			switch (typ)
			{
				case 0:
					word = $"{number1}-{number2}";
					break;
				case 1:
					word = $"{number1}{letters[rndInt(letters.Count())]}";
					break;
				case 2:
				default:
					word = $"{number1}/{number2}";
					break;
			}
		}

		words.Add(word);
	}
	Console.WriteLine(string.Join(" ", words) + $"{special}");
}

private int rndInt(int max)
{
	return rndInt(0,max);
}

private int rndInt(int min, int max)
{
	//cryptographycally serucre random generator
	RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

	uint scale = uint.MaxValue;
	while (scale == uint.MaxValue)
	{
		// Get four random bytes.
		byte[] four_bytes = new byte[4];
		Rand.GetBytes(four_bytes);

		// Convert that into an uint.
		scale = BitConverter.ToUInt32(four_bytes, 0);
	}

	// Add min to the scaled difference between max and min.
	return (int)(min + (max - min) * (scale / (double)uint.MaxValue));

}

// Define other methods and classes here