////// transformace / projekce - Select

numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

/// 1. vypište čísla v poli numbers jako slova

//// select-case-anonymous


/// 2. pomocí Select vytvořte nové pole kde jsou všechna slova lowercase


/// 3. pomocí Select vytvořte nové pole obsahující dvojici lowercase i uppercase variantu
/// anonymous type


/// 4. pomocí Select vytvořte nové pole obsahující dvojici lowercase i uppercase variantu
/// touple

//// select-with-index
/// 5. pomocí Select vypište hodnoty z pole numbers a jejich index

var numsInPlace = numbers.Select((num, index) => (Num: num, InPlace: (num == index)));

Console.WriteLine("Number: In-place?");
foreach (var n in numsInPlace)
{
	Console.WriteLine($"{n.Num}: {n.InPlace}");
}

