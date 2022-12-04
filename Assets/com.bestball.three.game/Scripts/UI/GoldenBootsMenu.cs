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
            UIManager.OpenWindow(Window.GBEquip);
        });

        settingsBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Settings);
            Settings.UpdateOptions(true, true, false);
        });
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !Settings.IsOpened && !GBEquip.IsEquip)
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        }
    }
}
