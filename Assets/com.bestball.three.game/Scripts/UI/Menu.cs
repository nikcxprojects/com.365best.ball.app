using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Space(10)]
    [SerializeField] Button footballRulesBtn;
    [SerializeField] Button bestPlayersBtn;

    private void Start()
    {
        footballRulesBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.FootballRules);
            Destroy(gameObject);
        });

        bestPlayersBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.FootballRules);
            Destroy(gameObject);
        });
    }
}
