using UnityEngine.UI;
using UnityEngine;

public class BPGame : MonoBehaviour
{
    private int score;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void OnEnable()
    {
        BootPlayer.OnCollided += OnCollidedEvent;
    }

    private void OnDestroy()
    {
        BootPlayer.OnCollided -= OnCollidedEvent;
    }

    private void OnCollidedEvent()
    {
        scoreText.text = $"{++score}";

        ScoreUtility.CurrentScore = score;
        ScoreUtility.BestScore = score;
    }

    private void Start()
    {
        pauseBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Pause);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(false, true, false);
        });
    }

    public static void GameOver()
    {
        //Destroy(FindObjectOfType<GBGame>().gameObject);
        //Destroy(FindObjectOfType<BootPlayer>().gameObject);
        //Destroy(FindObjectOfType<OverZone>().gameObject);
        //Destroy(FindObjectOfType<Ball>().gameObject);
    }
}
