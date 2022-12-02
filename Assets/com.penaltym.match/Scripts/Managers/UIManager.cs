using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static GameObject _last;

    private void Awake()
    {
        OpenWindow(Window.Menu);
    }

    public static void OpenWindow(string window)
    {
        WindowUtility.TryGetWindow(window, (window) =>
        {
            Instantiate(window, GameObject.Find("main canvas").transform);
        });
    }
}