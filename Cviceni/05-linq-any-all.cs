////// Quantifiers any / all
string[] words2 = { "believe", "relief", "receipt", "field" };

bool iAfterE = words2.Any(w => w.Contains("ei"));

Console.WriteLine($"There is a word that contains in the list that contains 'ei': {iAfterE}");

/// zjistěte jestli všechna slova obsaují ei

bool AllHaveIE = ...

/// zjistete jestli vsechny hodnoty v poli numbers2 jsou lichá čísla

int[] numbers2 = { 1, 11, 3, 19, 41, 65, 19 };

bool onlyOdd = ...

Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");

