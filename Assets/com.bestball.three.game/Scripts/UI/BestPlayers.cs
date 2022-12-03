using UnityEngine;

public class BestPlayers : MonoBehaviour
{
    public void OpenPlayer(BestPlayerData bestPlayerData)
    {
        Destroy(gameObject);
    }

    public void OpenMenu()
    {
        Destroy(gameObject);
        UIManager.OpenWindow(Window.Menu);
    }
}
