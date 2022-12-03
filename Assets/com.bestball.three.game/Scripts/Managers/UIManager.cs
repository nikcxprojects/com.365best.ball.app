using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        OpenWindow(Window.BestPlayers);
    }

    public static void OpenWindow(string window)
    {
        WindowUtility.TryGetWindow(window, (window) =>
        {
            Instantiate(window, GameObject.Find("main canvas").transform);
        });
    }
}