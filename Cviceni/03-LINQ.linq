<Query Kind="Statements" />

///
/////// agregace - count, max, min,..

int[] numbers = { -2079, -498, 2920, -1856, 332, -2549, -674, -120, -992, 2782, 320, -524, 135, 952, 1868, 2509, -230, -138, -904, -480 };

/// z "numebers" zjistěte:
/// 1. počet prvků v poli
/// 2. největší hodnotu
/// 3. nejmenší hodnotu
/// 4. průměr
/// 5. kolik obsahuje pole kladných čísel
/// 6. kolik obsahuje pole záporných čísel
/// 7. sumu všech hodnot
/// 8. sumu kladných hodnot

int max = numbers.Max().Dump();
int min = numbers.Min().Dump();
int count = numbers.Count().Dump();
int oddNumbers = numbers.Count(n => n % 2 == 1);
Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);

////// projection / restrikce / filtrovani - Where

/// 9. všechna čísla větší než -500
/// 10. všechna kladná sudá čísla
/// 11. čísla v rozstahu -400 až 400

///// řazení a omezení kolekce - OrderBy, OrderByDescending, Take, TakeWhile, Skip.. 

/// 12. seřaďte pole od nejmenších po největší hodnoty, přeskočte první 3 prvky a sečtěte zbytek hodnot
var s12 = numbers.OrderBy(x => x).Skip(3).Sum().Dump();


var fruits = new[] { "aPPLE", "BlUeBeRrY", "cHeRry", "RaspbeRry" };
/// pomocí Sum zjistěte kolik obsahují všechna slova v poli "fruits" dohromady písmen

var totalChars = fruits.Sum(w => w.Length);
Console.WriteLine($"There are a total of {totalChars} characters in these words.");





////// transformace / projekce - Select

numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

/// vypište čísla v poli numbers jako slova
var textNums = numbers.Select(n => strings[n])

Console.WriteLine("Number strings:");
foreach (var s in textNums)
{
	Console.WriteLine(s);
}


//// select-case-anonymous


/// pomocí Select vytvořte nové pole kde jsou všechna slova lowercase
var lowerWords = fruits.Select(x => x.ToLower());

/// pomocí Select vytvořte nové pole obsahující dvojici lowercase i uppercase variantu
/// anonymous type
var upperLowerWords = fruits.Select(x => new { Lower = x.ToLower(), Upper = x.ToUpper() });

foreach (var ul in upperLowerWords)
{
	Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
}

/// pomocí Select vytvořte nové pole obsahující dvojici lowercase i uppercase variantu
/// touple
var upperLowerWordsTuples = fruits.Select(x => (Upper: x.ToUpper(), Lower: x.ToLower()));

foreach (var ul in upperLowerWordsTuples)
{
	Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
}

//// select-with-index
/// pomocí Select vypište hodnoty z pole numbers a jejich index

var numsInPlace = numbers.Select((num, index) => (Num: num, InPlace: (num == index)));

Console.WriteLine("Number: In-place?");
foreach (var n in numsInPlace)
{
	Console.WriteLine($"{n.Num}: {n.InPlace}");
}






////// Quantifiers any / all
string[] words2 = { "believe", "relief", "receipt", "field" };

bool iAfterE = words2.Any(w => w.Contains("ei"));

Console.WriteLine($"There is a word that contains in the list that contains 'ei': {iAfterE}");

/// zjistěte jestli všechna slova obsaují ei

/// zjistete jestli vsechny hodnoty v poli numbers2 jsou lichá čísla

int[] numbers2 = { 1, 11, 3, 19, 41, 65, 19 };

bool onlyOdd = numbers.All(n => n % 2 == 1);

Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");




/// equal-sequence
var wordsA = new string[] { "cherry", "apple", "blueberry" };
var wordsB = new string[] { "cherry", "apple", "blueberry" };

bool match = wordsA.SequenceEqual(wordsB);

Console.WriteLine($"The sequences match: {match}");



/// zip
int[] vectorA = { 0, 2, 4, 5, 6 };
int[] vectorB = { 1, 3, 5, 7, 8 };

int dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();

Console.WriteLine($"Dot product: {dotProduct}");



/// intersect-syntax
int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };

var commonNumbers = numbersA.Intersect(numbersB);

Console.WriteLine("Common numbers shared by both arrays:");
foreach (var n in commonNumbers)
{
	Console.WriteLine(n);
}



/// convert-to-dictionary
var scoreRecords = new[] { new {Name = "Alice", Score = 50},
								new {Name = "Bob"  , Score = 40},
								new {Name = "Cathy", Score = 45}
							};

var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);



/// convert-to-type
object[] objects = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

var doubles = objects.OfType<double>();

Console.WriteLine("Numbers stored as doubles:");
foreach (var d in doubles)
{
	Console.WriteLine(d);
}
