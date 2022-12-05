using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resumeBtn;

    private void OnEnable()
    {
        var landscapeTemplate = LandscapeUtility.GetLandscape(AppManager.CurrentGameType);
        var canvasRef = gameObject.SetLandscape(landscapeTemplate);
        canvasRef.overrideSorting = false;
    }

    private void Start()
    {
        if (FindObjectOfType<Ball>() != null)
        {
            Ball.Sleep();
        }

        resumeBtn.onClick.AddListener(() =>
        {
            if (FindObjectOfType<Ball>() != null)
            {
                Ball.WakeUp();
            }

            Destroy(gameObject);
        });
    }
}
