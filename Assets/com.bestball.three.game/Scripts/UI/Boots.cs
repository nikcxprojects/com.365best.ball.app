using UnityEngine.UI;
using UnityEngine;

public class Boots : MonoBehaviour
{
    public static string BootsKey { get => "boot"; }

    [SerializeField] Button backBtn;

    [Space(10)]
    [SerializeField] Transform boots;
    [SerializeField] Transform hover;

    private void Start()
    {
        Debug.Log($"boot: {PlayerPrefs.GetInt(BootsKey)}");
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });

        hover.transform.position = boots.GetChild(PlayerPrefs.GetInt(BootsKey)).position;

        foreach (Transform boot in boots)
        {
            boot.GetComponent<Button>().onClick.AddListener(() =>
            {
                hover.position = boot.position;

                PlayerPrefs.SetInt(BootsKey, boot.GetSiblingIndex());
                PlayerPrefs.Save();

                //FindObjectOfType<Menu>()?.UpdateMenuBall();
            });
        }
    }
}
