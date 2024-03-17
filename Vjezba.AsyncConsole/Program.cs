Console.WriteLine("Zadatak 1.14");

var t1 = CreateSleepTask("task 1", 1000);
var t2 = CreateSleepTask("task 2", 1500);

Task.WaitAll(t1, t2);

async Task CreateSleepTask(string name, int sleepForMilliseconds) => await Task.Run(() =>
{
    Console.WriteLine($"Task '{name}' is sleeping...");
    Thread.Sleep(sleepForMilliseconds);
    Console.WriteLine($"Task '{name}' finished sleeping.");
});

// -------------------

Console.Out.WriteLine("Zadatak 1.15");

await SleepF1();

async Task SleepF1()
{
    Console.WriteLine("SleepF1 started.");
    await SleepF2();
    Console.WriteLine("SleepF1 is sleeping...");
    Thread.Sleep(750);
    Console.WriteLine("SleepF1 finished sleeping.");
}

async Task SleepF2()
{
    Console.WriteLine("SleepF2 started.");
    Console.WriteLine("SleepF2 is sleeping...");
    await Task.Run(() => Thread.Sleep(1000));
    Console.WriteLine("SleepF2 finished sleeping.");
}
