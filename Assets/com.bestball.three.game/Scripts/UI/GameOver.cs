using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button menuBtn;

    private void OnEnable()
    {
        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;
    }

    private void Start()
    {
        FindObjectOfType<SFXManager>().GameOver();
        restartBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.GBGame);
            Destroy(gameObject);
        });

        menuBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        });
    }
}
