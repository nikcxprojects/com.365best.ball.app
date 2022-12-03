using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static bool IsOpened { get; private set; }

    [SerializeField] Button backBtn;

    private void OnEnable()
    {
        IsOpened = true;
    }

    private void OnDestroy()
    {
        IsOpened = false;
    }

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
    }
}
