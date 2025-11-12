namespace IDETimer;


public class TimeManager
{
    private readonly TimeData _timeData = new TimeData();
    private bool _isRunning;
    private Thread? _worker;

    public void Start()
    {
        if (_isRunning)
        {
            Console.WriteLine("Таймер уже запущен");
            return;
        }

        _isRunning = true;
        _worker = new Thread(Run);
        _worker.Start();
        Console.WriteLine("Таймер запущен");
    }

    public void Stop()
    {
        _isRunning = false;
        _worker?.Join();
        Console.WriteLine("Таймер остановлен");
    }

    public void ShowTime()
    {
        Console.WriteLine("\n--- Отчёт ---");
        Console.WriteLine($"Работа в IDE: {_timeData.WorkingTime:hh\\:mm\\:ss}");
        Console.WriteLine($"Безделье: {_timeData.WasteOfTime:hh\\:mm\\:ss}");
        Console.WriteLine("--------------\n");
    }

    private void Run()
    {
        int secondsPassed = 0;
        int checksPerSecond = 10;
        int sleepTime = 1000 / checksPerSecond;
        int ideChecks = 0;
        int totalChecks = 0;

        while (_isRunning)
        {
            bool isIDEOpen = IDEChecker.IsIDEActive();
            if (isIDEOpen)
            {
                ideChecks++;
            }

            totalChecks++;

            if (totalChecks >= checksPerSecond)
            {
                secondsPassed++;
                
                if (ideChecks > checksPerSecond / 2)
                {
                    _timeData.WorkingTime += TimeSpan.FromSeconds(1);
                }
                else
                {
                    _timeData.WasteOfTime += TimeSpan.FromSeconds(1);
                }
                
                ideChecks = 0;
                totalChecks = 0;

                if (secondsPassed % 600 == 0)
                {
                    Console.WriteLine("\n--- Отчёт ---");
                    Console.WriteLine($"Работа в IDE: {_timeData.WorkingTime:hh\\:mm\\:ss}");
                    Console.WriteLine($"Безделье: {_timeData.WasteOfTime:hh\\:mm\\:ss}");
                    Console.WriteLine("--------------\n");
                }
            }
            
            Thread.Sleep(sleepTime);
        }
    }
}