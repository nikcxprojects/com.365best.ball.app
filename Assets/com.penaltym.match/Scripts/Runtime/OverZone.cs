using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UIManager.OpenWindow(Window.GameOver);

        Destroy(FindObjectOfType<Game>().gameObject);
        Destroy(FindObjectOfType<Player>().gameObject);
        Destroy(FindObjectOfType<Ball>().gameObject);
    }
}
