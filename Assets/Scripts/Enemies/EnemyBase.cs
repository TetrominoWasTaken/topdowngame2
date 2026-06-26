using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;

    public Rigidbody2D body;
    public TrailRenderer trail;

    public Health health;
    public float HealthWorth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        StartBehavior();
    }

    public void StartBehavior()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!playerScript.readyToJump)
            {
                if (health == null)
                {
                    health = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Health>();
                }
                health.addHealth(HealthWorth);
                Destroy(gameObject);
            }
        }
    }
}
