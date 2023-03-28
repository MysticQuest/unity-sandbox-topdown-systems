using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ComplexTasks : MonoBehaviour
{
    private void Awake()
    {
        Task.Run(() => RunTasks());
    }

    public async Task RunTasks()
    {
        Debug.Log($"Starting tasks on thread {Thread.CurrentThread.ManagedThreadId}");
        Task[] tasks = new Task[5];
        System.Random rnd = new();

        for (int i = 0; i < tasks.Length; i++)
        {
            int num = i;
            int delay = rnd.Next(500, 10000);
            tasks[i] = Task.Run(async () =>
            {
                await Task.Delay(delay);
                Debug.Log($"Task {num + 1}, completed after {delay} ms, on thread {Thread.CurrentThread.ManagedThreadId}.");
            });
        }

        await Task.WhenAll(tasks);
        Debug.Log("All tasks completed.");
    }

}
