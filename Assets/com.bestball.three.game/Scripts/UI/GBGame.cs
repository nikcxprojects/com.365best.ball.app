using UnityEngine;
using UnityEngine.UI;

public class GBGame : MonoBehaviour
{
    private int score;
    private static Transform land;

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
        });

        Transform parent = GameObject.Find("Environment").transform;

        Ball ballRef = InstantiateUtility.Spawn<Ball>("ball", Vector2.up * 6, Quaternion.identity, parent);
        InstantiateUtility.Spawn<BootPlayer>("boot player", Vector2.down * 3.688f, Quaternion.identity, parent);
        InstantiateUtility.Spawn<OverZone>("over zone", Vector2.down * 5, Quaternion.identity, parent);

        land = Instantiate(Resources.Load<Transform>("Landscapes/GB"), GameObject.Find("main canvas").transform);

        land.SetParent(FindObjectOfType<GBGame>().transform);
        land.SetAsFirstSibling();

        BootPlayer.BallRef = ballRef;
    }

    public static void GameOver(out GameObject landscape)
    {
        Destroy(FindObjectOfType<GBGame>().gameObject);
        Destroy(FindObjectOfType<BootPlayer>().gameObject);
        Destroy(FindObjectOfType<OverZone>().gameObject);
        Destroy(FindObjectOfType<Ball>().gameObject);

        landscape = land.gameObject;
    }
}
