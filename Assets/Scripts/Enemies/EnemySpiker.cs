using UnityEngine;

public class EnemySpiker : EnemyBase
{
    public int direction;
    public Vector2 screenBounds;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Health>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        direction = Random.Range(0, 1);
        if (direction == 0)
        {
            direction = -1;
        }
    }

    void Update()
    {
        Vector2 clampedPos;

        transform.Translate(Vector3.left * direction * Time.deltaTime);

        clampedPos.x = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        clampedPos.y = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        transform.position = clampedPos;
        if (transform.position.x == screenBounds.x || transform.position.x == -screenBounds.x)
        {
            direction = direction * -1;
        }
    }
}
