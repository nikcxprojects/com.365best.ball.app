using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button restartBtn;

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
    }
}
