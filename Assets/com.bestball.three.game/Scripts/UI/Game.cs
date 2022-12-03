using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int score;

    [SerializeField] Button pauseBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void OnEnable()
    {
        Player.OnCollided += OnCollidedEvent;
    }

    private void OnDestroy()
    {
        Player.OnCollided -= OnCollidedEvent;
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
        });

        Player playerPrefab = Resources.Load<Player>("player");

        Vector2 position = new Vector2(0, -3.42f);
        Quaternion rotation = Quaternion.Euler(Vector3.zero);
        Transform parent = GameObject.Find("Environment").transform;

        Instantiate(playerPrefab, position, rotation, parent);

        Ball ballPrefab = Resources.Load<Ball>("ball");

        position = new Vector2(0, 6.88f);
        rotation = Quaternion.Euler(Vector3.zero);

        Instantiate(ballPrefab, position, rotation, parent);
    }
}
