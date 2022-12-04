using UnityEngine.UI;
using UnityEngine;

public class Boots : MonoBehaviour
{
    public static string BootsKey { get => "ball"; }

    [SerializeField] Button backBtn;

    [Space(10)]
    [SerializeField] Transform boots;
    [SerializeField] Transform hover;

    private void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });

        hover.transform.position = boots.GetChild(PlayerPrefs.GetInt(BootsKey)).position;

        foreach (Transform ball in boots)
        {
            ball.GetComponent<Button>().onClick.AddListener(() =>
            {
                hover.position = ball.position;

                PlayerPrefs.SetInt(BootsKey, ball.GetSiblingIndex());
                PlayerPrefs.Save();

                //FindObjectOfType<Menu>()?.UpdateMenuBall();
            });
        }
    }
}
