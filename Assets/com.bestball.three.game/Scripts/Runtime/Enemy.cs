using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Vector2 Velocity { get; set; }
    private Rigidbody2D Rigidbody2D { get; set; }
    private static SpriteRenderer SpriteRenderer { get; set; }
    public static Transform Target { get; set; }
    private static Sprite[] Sprites { get; set; }

    private const float force = 2.14f;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateRender();
    }

    private void Start()
    {
        StartCoroutine(nameof(AnimationCycle));
    }

    private void Update()
    {
        Vector2 direction = Target.position - transform.position;
        transform.up = -direction;
    }

    public  void Sleep()
    {
        Velocity = Rigidbody2D.velocity;
        Rigidbody2D.Sleep();
    }

    public void WakeUp()
    {
        Rigidbody2D.WakeUp();
        Rigidbody2D.velocity = Velocity;

        UpdateRender();
    }

    private static void UpdateRender()
    {
        Sprites = Resources.LoadAll<Sprite>($"Shirts/{PlayerPrefs.GetInt(Shirts.ShirtKey)}");
    }

    IEnumerator AnimationCycle()
    {
        StartCoroutine(nameof(Following));

        while(true)
        {
            for(int i = 0; i < Sprites.Length; i++)
            {
                SpriteRenderer.sprite = Sprites[i];
                yield return new WaitForSeconds(0.25f);
            }

            yield return null;
        }
    }

    IEnumerator Following()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.8f, 2.0f));
            float et = 0.0f;
            float followTime = Random.Range(0.5f, 1.5f);
            while (et < followTime)
            {
                Vector2 direction = Target.position - transform.position;
                Rigidbody2D.AddForce(direction * force, ForceMode2D.Force);

                et += Time.deltaTime;
                yield return null;
            }
        }
    }
}
