using UnityEngine.UI;
using UnityEngine;

public class GoldenBootsMenu : MonoBehaviour, IMenu
{
    [SerializeField] Button startBtn;
    [SerializeField] Button equipmentBtn;
    [SerializeField] Button settingsBtn;

    [Space(10)]
    [SerializeField] Image currentBoots;
    [SerializeField] Image currentBall;

    public void UpdateMenuIcons()
    {
        currentBoots.sprite = Resources.Load<Sprite>($"Boots/{PlayerPrefs.GetInt(Boots.BootsKey)}");
        currentBall.sprite = Resources.Load<Sprite>($"Balls/{PlayerPrefs.GetInt(Balls.BallKey)}");
    }

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            InstantiateUtility.Spawn(Resources.Load<Ball>("ball"), Vector2.zero, Quaternion.identity, null);
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

        UpdateMenuIcons();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !Settings.IsOpened && !GBEquip.IsEquip)
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        }
    }
}
