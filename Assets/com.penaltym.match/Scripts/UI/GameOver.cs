using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button restartBtn;

    private void Start()
    {
        FindObjectOfType<SFXManager>().GameOver();
        restartBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Game);
            Destroy(gameObject);
        });
    }
}
