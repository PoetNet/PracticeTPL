using System;
using System.Collections.Generic;
using System.Threading.Tasks;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine("Пример 1: Используем Parallel.ForEach для выполнения операций параллельно");

Parallel.ForEach(numbers, num =>
{
    Console.WriteLine($"Поток {Task.CurrentId}: Вывод числа: {num}");
});

Console.WriteLine("Пример 2: Используем Task для выполнения операций");
Task.Run(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Поток {Task.CurrentId}: Выполняется итерация: {i}");        
    }
}).Wait();

Console.WriteLine("Пример 3: Используем Task.WhenAll для ожидания выполнения нескольких задач");
Task[] tasks = new Task[3];
for (int i = 0; i < 3; i++)
{
    int index = i;
    tasks[i] = Task.Run(() =>
    {
        Console.WriteLine($"Поток {Task.CurrentId}: Задача {index}");        
    });
}
Task.WaitAll(tasks);

Console.WriteLine($"Готово");
