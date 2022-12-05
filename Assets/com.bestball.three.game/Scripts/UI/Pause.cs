using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resumeBtn;

    private void OnEnable()
    {
        gameObject.SetLandscape(LandscapeUtility.GetLandscape(AppManager.CurrentGameType));
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
