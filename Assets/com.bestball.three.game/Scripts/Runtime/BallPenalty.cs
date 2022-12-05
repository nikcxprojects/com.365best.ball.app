using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class BallPenalty : MonoBehaviour
{
    private Vector2 InitScale { get; set; } = Vector3.one * 0.35f;
    private Vector2 TargetScale { get; set; } = Vector3.one * 0.1f;

    private Transform Center { get; set; }
    private Transform Target { get; set; }

    private const float totalDistance = 4.0f;
    private const float force = 8;

    private Rigidbody2D Rigidbody { get; set; }

    private bool EndTravel { get; set; }
    public static Action OnTravelled { get; set; }

    private void Start()
    {
        Center = GameObject.Find("center").transform;
        Target = GameObject.Find("target").transform;

        Rigidbody = GetComponent<Rigidbody2D>();

        ResetMe();
    }

    private void OnMouseDown()
    {
        if(Rigidbody.velocity.sqrMagnitude > 0)
        {
            return;
        }

        Target.position = new Vector2(Random.Range(-2.21f, 2.21f), Random.Range(-0.5f, 1.72f));
        Vector2 direction = Target.position - transform.position;

        Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Invoke(nameof(ResetMe), 2.5f);
    }

    private void Update()
    {
        float distanceToGoal = Mathf.Abs(Center.position.y - transform.position.y);
        if(distanceToGoal <= 1 && !EndTravel)
        {
            EndTravel = true;
            OnTravelled?.Invoke();
        }

        transform.localScale = Vector2.Lerp(TargetScale, InitScale, distanceToGoal / totalDistance);
    }

    private void ResetMe()
    {
        EndTravel = false;

        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = new Vector2(0, -2.699363f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("over zone"))
        {
            return;
        }

        UIManager.OpenWindow(Window.GameOver);
        BPGame.GameOver();
    }
}
