using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public Health health;

    private void Start()
    {
        health = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player;

        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            ContactPoint2D contactPoint = collision.contacts[0];
            Vector2.Reflect(player.direction, contactPoint.normal);

            player.direction.x = - player.direction.x;
            health.addHealth(-4);
        }
    }
}
