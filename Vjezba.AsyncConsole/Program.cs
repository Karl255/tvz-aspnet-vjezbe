// zadatak 1.14

var t1 = CreateSleepTask("task 1", 1000);
var t2 = CreateSleepTask("task 2", 1500);

Task.WaitAll(t1, t2);

async Task CreateSleepTask(string name, int sleepForMilliseconds) => await Task.Run(() =>
{
    Console.WriteLine($"Task '{name}' is sleeping...");
    Thread.Sleep(sleepForMilliseconds);
    Console.WriteLine($"Task '{name}' finished sleeping.");
});
