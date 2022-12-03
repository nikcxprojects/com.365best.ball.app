using UnityEngine;
using UnityEngine.UI;

public class BestPlayers : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;

    [Space(10)]
    [SerializeField] GameObject detailsGo;
    [SerializeField] GameObject buttonsGo;

    [Space(10)]
    [SerializeField] Button menuBtn;
    [SerializeField] Button backBtn;

    private void Start()
    {
        backBtn.gameObject.SetActive(false);
        detailsGo.SetActive(false);

        menuBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
            UIManager.OpenWindow(Window.Menu);
        });

        backBtn.onClick.AddListener(() =>
        {
            backBtn.gameObject.SetActive(false);

            detailsGo.SetActive(false);
            buttonsGo.SetActive(true);
        });
    }

    public void OpenPlayer(BestPlayerData bestPlayerData)
    {
        backBtn.gameObject.SetActive(true);

        titleText.text = bestPlayerData.title;
        descriptionText.text = bestPlayerData.description;

        buttonsGo.SetActive(false);
        detailsGo.SetActive(true);
    }
}