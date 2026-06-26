using Unity.Properties;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;

    public Rigidbody2D body;
    public TrailRenderer trail;
    public float speed;

    public Health health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(new Vector2(-1 * speed, Mathf.Sin(Time.time) * speed) * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerScript.readyToJump)
        {
            if (health == null)
            {
                health = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Health>();
            }
            health.addHealth(5);
            Destroy(gameObject);
        }
    }
}
