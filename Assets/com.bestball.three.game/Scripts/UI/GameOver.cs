using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    private static Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
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

    public static void SetLandscape(Transform landscape)
    {
        landscape.SetParent(thisTransform);
    }
}
