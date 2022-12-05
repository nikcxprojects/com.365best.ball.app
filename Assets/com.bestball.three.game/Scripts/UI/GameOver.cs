using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button restartBtn;

    private void OnEnable()
    {
        gameObject.SetLandscape(LandscapeUtility.GetLandscape(AppManager.CurrentGameType));
    }

    private void Start()
    {
        FindObjectOfType<SFXManager>().GameOver();
        restartBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GBGame);
            Destroy(gameObject);
        });
    }
}
