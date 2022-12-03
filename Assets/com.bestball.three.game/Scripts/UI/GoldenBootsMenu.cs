using UnityEngine.UI;
using UnityEngine;

public class GoldenBootsMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button equipmentBtn;
    [SerializeField] Button settingsBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });

        equipmentBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
        });
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !Settings.IsOpened)
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        }
    }
}
