using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Button goldenBoots;
    [SerializeField] Button bestPenalty;

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

        goldenBoots.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.BestPenaltyMenu, gameObject);
            AppManager.CurrentGameType = GameType.BP;
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
