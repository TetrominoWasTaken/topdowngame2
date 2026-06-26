using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;

public class SpinerEnemy : EnemyBase
{
    public Vector2 direction;
    public Vector2 screenBounds;
    public float speed;
    public float rotateSpeed;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Health>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        direction = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
    }

    private void OnBecameInvisible()
    {
        
    }

    void Update()
    {
        Vector2 clampedPos;

        transform.Translate(direction * Time.deltaTime * speed);

        clampedPos.x = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        clampedPos.y = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);

        if (Mathf.Abs(transform.position.x) >= screenBounds.x)
        {
            direction = Vector2.Reflect(direction, Vector2.right * Mathf.Sign(transform.position.x));
        }
        if (Mathf.Abs(transform.position.y) >= screenBounds.y)
        {
            direction = Vector2.Reflect(direction, Vector2.up * Mathf.Sign(transform.position.y));
        }
    }
}
