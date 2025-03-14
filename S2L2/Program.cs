using S2L2;

bool testing = true;
Sentence s = new Sentence();
while (testing)
{
    Console.Write($"Зараз речення таке: {s.sentence}\n" +
        $"1 - додати слово в кінець\n2 - видалити слово \n" +
        $"3 - вставити слово за індексом\n4 - отримати кількість літер\n" +
        $"5 - отримати кількість слів\n6 - отримамти найдовше слово\n" +
        $"7 - отримати найкоротше слово\n8 - перевірити чи є в реченні слово\n" +
        $"9 - отримати слово за індексом\n10 - порівняти з іншим реченням\n" +
        $"\"-\" - закінчити з даним реченням\n" +
        $"Введіть наступну дію: ");
    string answer = Console.ReadLine();
    int action=0;
    if (answer == "-")
    {
        testing = false;
        break;
    }
    else action = int.Parse(answer);
    switch (action)
    {
        case 1:
            Console.Write("Введіть слово: ");
            s.Add(Console.ReadLine());
            break;
        case 2:
            Console.Write("Введіть слово: ");
            s.Remove(Console.ReadLine());
            break;
        case 3:
            Console.Write("Введіть індекс:");
            int index1 = int.Parse(Console.ReadLine());
            Console.Write("Введіть слово: ");
            s.InsertWord(index1, Console.ReadLine());
            break;
        case 4:
            Console.WriteLine($"Кількість літер: {s.LetterCount}");
            break;
        case 5:
            Console.WriteLine($"Кількість слів: {s.WordCount}");
            break;
        case 6:
            Console.WriteLine($"Найдовше слово: {s.LongestWord}");
            break;
        case 7:
            Console.WriteLine($"Найкоротше слово: {s.ShortestWord}");
            break;
        case 8:
            Console.Write($"Введіть слово: ");
            if (s.IsContainWord(Console.ReadLine())) 
                Console.WriteLine("Речення містить дане слово");
            else
                Console.WriteLine("Речення не містить дане слово");
            break;
        case 9:
            Console.Write("Введіть індекс:");
            int index2 = int.Parse(Console.ReadLine());
            Console.WriteLine(s.WordByIndex(index2));
            break;
        case 10:
            Console.Write("Введіть речення: ");
            if (s.IsSentencesEqual(Console.ReadLine()))
                Console.WriteLine("Речення однакові");
            else
                Console.WriteLine("Речення різні");
            break;
        default:
            break;
    }
    Console.ReadKey();
    Console.Clear();
}