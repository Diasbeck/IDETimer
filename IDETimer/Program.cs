using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using IDETimer;



TimeManager timer = new TimeManager();

Console.WriteLine("\n" +
                  "------------IDETimer by Dias B------------" +
                  "\n");

while (true)
{
    Console.WriteLine("Нажмите : " +
                      "\n" +
                      "\n1 : Если хотите включить таймер," +
                      "\n2 : Если хотите его остановить," +
                      "\n3 : Если хотите посмотреть отчет по времени" +
                      "\n4 : Если хотите очистить консоль" +
                      "\n5 : Если хотите выйти из программы.");
    string input = Console.ReadLine()!;
    switch (input)
    {
        case "1" :
            timer.Start();
            break;
        case "2" :
            timer.Stop();
            break;
        case "3" :
            timer.ShowTime();
            break;
        case "4":
            Console.Clear(); 
            Console.WriteLine("Консоль очищена");
            break;
        case "5" :
            Console.WriteLine("Выход из программы");
            timer.Stop();
            return;
        default:
            Console.WriteLine("Введите корректное число строчкой, от 1 до 3");
            break;
    }
}

