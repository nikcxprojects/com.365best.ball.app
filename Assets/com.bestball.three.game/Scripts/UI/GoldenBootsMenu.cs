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
            Ball ballRef = InstantiateUtility.Spawn<Ball>("ball", Vector2.up * 6, Quaternion.identity, null);

            InstantiateUtility.Spawn<BootPlayer>("boot player", Vector2.down * 3.688f, Quaternion.identity, null);
            InstantiateUtility.Spawn<OverZone>("over zone", Vector2.down * 5, Quaternion.identity, null);

            BootPlayer.BallRef = ballRef;
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
