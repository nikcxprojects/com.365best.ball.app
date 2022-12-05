using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPenalty : MonoBehaviour
{
    private Vector2 InitScale { get; set; } = Vector3.one * 0.3491603f;
    private Vector2 TargetScale { get; set; } = Vector3.one * 0.1604941f;

    private Transform Center { get; set; }
    private Transform Target { get; set; }

    private const float totalDistance = 4.0f;

    [SerializeField] float force;

    private Rigidbody2D Rigidbody { get; set; }

    private void Start()
    {
        Center = GameObject.Find("center").transform;
        Target = GameObject.Find("target").transform;

        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Target.localPosition = new Vector2(Random.Range(-2.34f, -2.34f), Random.Range(-0.65f, 1.35f));
        Vector2 direction = Target.position - transform.position;

        Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        float distanceToGoal = Mathf.Abs(Center.position.y - transform.position.y);
        transform.localScale = Vector2.Lerp(TargetScale, InitScale, distanceToGoal / totalDistance);
    }
}
