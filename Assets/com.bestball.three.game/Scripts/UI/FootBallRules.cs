using UnityEngine;

public class FootBallRules : MonoBehaviour
{
    public void OpenRules(FootBallRulesData footBallRulesData)
    {
        Destroy(gameObject);
    }

    public void OpenMenu()
    {
        Destroy(gameObject);
        UIManager.OpenWindow(Window.Menu);
    }
}
