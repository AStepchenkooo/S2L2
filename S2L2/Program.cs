using Newtonsoft.Json;
using S2L2;
using System.Text;

void objSerialize(object s)
{
    string path = @"D:\Навчання\1 курс\ОП\Text.json";
    File.WriteAllText(path, JsonConvert.SerializeObject(s));

}
Sentence objDeserialize(string path)
{
    return JsonConvert.DeserializeObject<Sentence>(File.ReadAllText(path));
}

Console.OutputEncoding = UTF8Encoding.UTF8;
Console.InputEncoding = UTF8Encoding.UTF8;
bool isProgramRun = true;
do
{
    try
    {
        Sentence s = new Sentence();
        bool load = true;
        while (load)
        {
            Console.WriteLine("Завантажити об'єкт?");
            Console.WriteLine("Використовуйте '+/-'");
            string loadAnswer = Console.ReadLine();
            if (loadAnswer == "+")
            {
                load = false;
                Console.WriteLine("Введіть шлях: ");
                string path = Console.ReadLine();
                s = objDeserialize(path);
            }
            else if (loadAnswer == "-")
            {
                load = false;

            }
            else
            {
                Console.WriteLine("Введене некоректне значення");
            }
        }
        bool testing = true;
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
            int action = 0;
            if (answer == "-")
            {
                testing = false;
                bool save = true;
                while (save)
                {
                    Console.WriteLine("Зберегти об'єкт?");
                    Console.WriteLine("Використовуйте '+/-'");
                    string saveAnswer = Console.ReadLine();
                    if (saveAnswer == "+")
                    {
                        save = false;
                        objSerialize(s);
                    }
                    else if (saveAnswer == "-")
                    {
                        save = false;
                    }
                    else
                    {
                        Console.WriteLine("Введене некоректне значення");
                    }
                }
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
                    Console.WriteLine($"Кількість літер: {s.LetterCount()}");
                    break;
                case 5:
                    Console.WriteLine($"Кількість слів: {s.WordCount()}");
                    break;
                case 6:
                    Console.WriteLine($"Найдовше слово: {s.LongestWord()}");
                    break;
                case 7:
                    Console.WriteLine($"Найкоротше слово: {s.ShortestWord()}");
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
            Console.WriteLine("Натисніть будь-яку клавішу щоб продовжити");
            Console.ReadKey();
            Console.Clear();
        }
    }
    catch (FormatException) { Console.WriteLine("Введіть коректне значення"); }
    catch (JsonSerializationException) { Console.WriteLine("Помилка серіалізації"); }
    catch (FileNotFoundException) { Console.WriteLine("Файл не знайдено"); }
    catch (OverflowException) { Console.WriteLine("Занадто велике число"); }
    finally
    {
        bool Exit = true;
        while (Exit)
        {
            Console.WriteLine("Вийти з програми?");
            Console.WriteLine("Використовуйте 'так/нi' або '+/-'");
            string answer = Console.ReadLine();
            if (answer == "так" || answer == "+")
            {
                Exit = false;
                isProgramRun = false;
            }
            else if (answer == "нi" || answer == "-")
            {
                Console.Clear();
                Exit = false;
            }
            else
            {
                Console.WriteLine("Введене некоректне значення");
            }
        }
    }
}
while (isProgramRun);

//D:\Навчання\1 курс\ОП\Text.json