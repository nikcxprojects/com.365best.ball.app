using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _camera;
    Vector2 target;

    const float speed = 6.5f;

    public static Action OnCollided { get; set; } = delegate { };

    private void Awake()
    {
        _camera = Camera.main;
        target = transform.position;
    }

    private void OnMouseDrag()
    {
        target = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        Instantiate(Resources.Load<GameObject>("hit"), collision.GetContact(0).point, Quaternion.identity, GameObject.Find("Environment").transform);
        OnCollided?.Invoke();
    }
}
