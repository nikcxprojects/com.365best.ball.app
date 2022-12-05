using UnityEngine;
using UnityEngine.UI;

public class OverZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UIManager.OpenWindow(Window.GameOver);

        GBGame.GameOver(out GameObject landscape);

        landscape.transform.SetParent(FindObjectOfType<GameOver>().transform);
        landscape.transform.SetAsFirstSibling();

        landscape.GetComponent<Canvas>().enabled = true;
        landscape.GetComponent<Image>().enabled = true;
    }
}