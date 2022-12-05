using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPenalty : MonoBehaviour
{
    private Vector2 initScale = Vector3.one * 0.3491603f;
    private Vector2 targetScale = Vector3.one * 0.1604941f;

    private Transform Center { get; set; }
    private const float totalDistance = 4.0f;

    [SerializeField] float force;

    private Rigidbody2D Rigidbody { get; set; }

    private void Start()
    {
        Center = GameObject.Find("center").transform;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        float distanceToGoal = Mathf.Abs(Center.position.y - transform.position.y);
        transform.localScale = Vector2.Lerp(targetScale, initScale, distanceToGoal / totalDistance);
    }
}
