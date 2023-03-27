using System;
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
        Debug.Log("Starting tasks...");
        Task[] tasks = new Task[5];

        for (int i = 0; i < tasks.Length; i++)
        {
            int num = i;
            tasks[i] = Task.Run(async () =>
            {
                System.Random rnd = new System.Random();
                int delay = rnd.Next(500, 10000);
                await Task.Delay(delay);
                Debug.Log($"Task {num + 1} completed after {delay} ms.");
            });
        }

        await Task.WhenAll(tasks);
        Debug.Log("All tasks completed.");
    }
}
