using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Space(10)]
    [SerializeField] Button footballRulesBtn;
    [SerializeField] Button bestPlayersBtn;

    [Space(10)]
    [SerializeField] GameObject VFX;

    private void Start()
    {
        VFX.SetActive(true);

        footballRulesBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.FootballRules);
            Destroy(gameObject);
        });

        bestPlayersBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BestPlayers);
            Destroy(gameObject);
        });
    }
}
