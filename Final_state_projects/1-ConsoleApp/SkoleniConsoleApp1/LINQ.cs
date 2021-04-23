using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleniConsoleApp1
{
    public class LINQEx
    {
        public static void PlayAggr()
        {
            ///
            /////// agregace - count, max, min,..

            #region agregace
            int[] numbers = { -2079, -498, 2920, -1856, 332, -2549, -674, -120, -992, 2782, 320, -524, 135, 952, 1868, 2509, -230, -138, -904, -480 };

            /// z "numebers" zjistěte:
            /// 1. počet prvků v poli
            Console.WriteLine($"1. počet prvků v poli {numbers.Count()}");

            /// 2. největší hodnotu
            Console.WriteLine($"2. největší hodnotu { numbers.Max()}");

            /// 3. nejmenší hodnotu
            Console.WriteLine($"3. nejmenší hodnotu { numbers.Min()}");

            /// 4. průměr
            Console.WriteLine($"4. průměr { numbers.Average()}");

            /// 5. kolik obsahuje pole kladných čísel
            Console.WriteLine($"5. kolik obsahuje pole kladných čísel {numbers.Count(x => x > 0)}");

            /// 6. kolik obsahuje pole záporných čísel
            Console.WriteLine($"6. kolik obsahuje pole záporných čísel {numbers.Count(x => x < 0)}");

            /// 7. sumu všech hodnot
            Console.WriteLine($" 7. sumu všech hodnot { numbers.Sum()}");

            /// 8. sumu kladných hodnot
            Console.WriteLine($"8. sumu kladných hodnot { numbers.Where(x => x > 0).Sum()}");


            ////// projection / restrikce / filtrovani - Where

            /// 9. všechna čísla větší než -500
            var over500 = numbers.Where(x => x > -500).ToArray();
            Console.WriteLine($"9. všechna čísla větší než -500" +
                $" {string.Join(", ", over500)}");


            /// 10. všechna kladná sudá čísla
            var result10 = numbers.Where(x => x % 2 == 0).Where(x => x > 0);
            Console.WriteLine($"10. všechna kladná sudá čísla" +
                $" {string.Join(", ", result10)}");

            /// 11. čísla v rozstahu -400 až 400
            var result11 = numbers.Where(x => x > -400 && x < 400);
            Console.WriteLine($" 11. čísla v rozstahu -400 až 400" +
                $" {string.Join(", ", result11)}");

            ///// řazení a omezení kolekce - OrderBy, OrderByDescending, Take, TakeWhile, Skip.. 

            /// 12. seřaďte pole od nejmenších po největší hodnoty, přeskočte první 3 prvky a sečtěte zbytek hodnot
            var result12 = numbers.OrderBy(x => x).Skip(3).Sum();
            Console.WriteLine("12. " + result12);

            var fruits = new[] { "aPPLE", "BlUeBeRrY", "cHeRry", "RaspbeRry" };
            /// 13. pomocí Sum zjistěte kolik obsahují všechna slova v poli "fruits" dohromady písmen

            var result13 = fruits.Select(slovo => { var c = slovo.Length; return c + 2; }).Sum();
            Console.WriteLine("13. " + result13);

            #endregion

            #region any/all
            ///// Quantifiers any / all
            string[] words2 = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words2.Any(w => w.Contains("ei"));
            Console.WriteLine($"There is a word that contains in the list that contains 'ei': {iAfterE}");

            /// zjistěte jestli všechna slova obsaují ei
            bool AllHaveIE = words2.All(w => w.Contains("ei"));
            Console.WriteLine("všechna slova obsaují ei " + AllHaveIE);


            /// zjistete jestli vsechny hodnoty v poli numbers2 jsou lichá čísla

            int[] numbers2 = { 1, 11, 3, 19, 41, 65, 19 };

            bool onlyOdd = numbers2.All(n => n % 2 == 1);
            Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
            #endregion


            numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            /// 1. vypište čísla v poli numbers jako slova

            var numbersAsWords = numbers.Select(x => strings[x]);
            Console.WriteLine("Number strings:");
            foreach (var s in numbersAsWords)
            {
                Console.WriteLine(s);
            }


            //// select-case-anonymous
            // { "aPPLE", "BlUeBeRrY", "cHeRry", "RaspbeRry" };

            /// 2. array fruits - pomocí Select vytvořte nové pole kde jsou všechna slova lowercase
            /// 
            string[] fuitsLower = fruits.Select(fruit => fruit).ToArray<string>();


            /// 3. array fruits - pomocí Select vytvořte nové pole obsahující dvojici lowercase i uppercase variantu
            /// anonymous type
            /// 
            var anonFuits = fruits.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            foreach (var ul in anonFuits)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }


            /// 4. array fruits - pomocí Select vytvořte nové pole obsahující dvojici lowercase i uppercase variantu
            /// touple
            var tupleFruits = fruits.Select(s => (Lower: s.ToLower(), Upper: s.ToUpper()));
            foreach (var ul in tupleFruits)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }

            //// select-with-index
            /// 5. pomocí Select vypište hodnoty z pole numbers a jejich index

            var numsInPlace = numbers.Select((num, i) => new { Num = num, InPlace = (num == i)});

            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine($"{n.Num}: {n.InPlace}");
            }

        }
    }
}
