using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Button goldenBoots;

    [Space(10)]
    [SerializeField] Button footballRulesBtn;
    [SerializeField] Button bestPlayersBtn;

    [Space(10)]
    [SerializeField] GameObject VFX;

    private void Start()
    {
        VFX.SetActive(true);

        goldenBoots.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GoldenBootsMenu, gameObject);
            AppManager.CurrentGameType = GameType.GB;
        });

        footballRulesBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.FootballRules, gameObject);
        });

        bestPlayersBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BestPlayers, gameObject);
        });
    }
}
