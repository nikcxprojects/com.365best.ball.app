using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Button backBtn;
    [SerializeField] Button ballsBtn;

    private void Start()
    {
        if (FindObjectOfType<Ball>() != null)
        {
            Ball.Sleep();
        }

        backBtn.onClick.AddListener(() =>
        {
            if (FindObjectOfType<Ball>() != null)
            {
                Ball.WakeUp();
            }

            Destroy(gameObject);
        });

        ballsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Balls);
        });
    }
}
