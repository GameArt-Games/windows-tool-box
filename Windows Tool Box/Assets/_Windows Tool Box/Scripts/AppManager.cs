using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AppManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(300, 800, FullScreenMode.Windowed);
    }

    public void CreateProcess(string name)
    {
        var argument = $"/C {name}";

        var processInfo = new ProcessStartInfo
        {
            WorkingDirectory = Application.persistentDataPath,
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = "cmd.exe",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = argument,
        };

        Task.Run(() =>
        {
            try
            {
                var process = Process.Start(processInfo);
                var result = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                Debug.Log($"Process completed with result: {result}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error starting process: {ex.Message}");
            }
        });

        //----------

        //var argument = $"/C {name}";

        //var processInfo = new ProcessStartInfo
        //{
        //    WorkingDirectory = Application.persistentDataPath,
        //    WindowStyle = ProcessWindowStyle.Hidden,
        //    FileName = "cmd.exe",
        //    UseShellExecute = false,
        //    CreateNoWindow = true,
        //    RedirectStandardOutput = true,
        //    Arguments = argument,
        //};
        //var process = Process.Start(processInfo);
        //var result = process.StandardOutput.ReadToEnd();

        //process.WaitForExit();

        //----------

        //var argument = $"/C {name}";

        //var processInfo = new ProcessStartInfo
        //{
        //    WorkingDirectory = Application.persistentDataPath,
        //    FileName = name,
        //    UseShellExecute = false,
        //    CreateNoWindow = true,
        //};
        //Process.Start(processInfo);

        //----------
    }
}
