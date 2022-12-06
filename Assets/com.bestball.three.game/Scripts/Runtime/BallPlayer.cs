using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    private Camera Camera { get; set; }
    private static Vector2 Velocity { get; set; }
    private static Rigidbody2D Rigidbody2D { get; set; }
    private static SpriteRenderer SpriteRenderer { get; set; }

    [SerializeField] float dragForce;

    private void Awake()
    {
        Camera = Camera.main;

        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateRender();
    }

    private void OnMouseDrag()
    {
        Vector2 direction = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Rigidbody2D.AddForce(direction.normalized * dragForce, ForceMode2D.Force);
    }

    public static void Sleep()
    {
        Velocity = Rigidbody2D.velocity;
        Rigidbody2D.Sleep();
    }

    public static void WakeUp()
    {
        Rigidbody2D.WakeUp();
        Rigidbody2D.velocity = Velocity;

        UpdateRender();
    }

    private static void UpdateRender()
    {
        SpriteRenderer.sprite = Resources.Load<Sprite>($"Balls/{PlayerPrefs.GetInt(Balls.BallKey)}");
    }
}
