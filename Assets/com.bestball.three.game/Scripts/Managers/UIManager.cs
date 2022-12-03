using UnityEngine;

public static class UIManager
{
    public static void OpenWindow(string window)
    {
        WindowUtility.TryGetWindow(window, (window) =>
        {
            Object.Instantiate(window, GameObject.Find("main canvas").transform);
        });
    }
}