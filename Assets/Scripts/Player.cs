using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveForce;
    InputAction move;
    InputAction jump;
    public bool readyToJump;

    public Vector2 screenBounds;
    public float playerHalfWidth;
    public float playerHalfHeight;

    public Vector2 direction;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        Vector2 clampedPos;

        clampedPos.x = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        clampedPos.y = Mathf.Clamp(transform.position.y, -screenBounds.y + playerHalfHeight, screenBounds.y - playerHalfHeight);
        transform.position = clampedPos;

        if (readyToJump && jump.WasPressedThisFrame() && move.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = move.ReadValue<Vector2>();

            readyToJump = false;
        }

        if (!readyToJump)
        {
            transform.Translate(direction.normalized * Time.deltaTime * moveForce);
            if (Mathf.Abs(transform.position.x) >= screenBounds.x - playerHalfHeight || Mathf.Abs(transform.position.y) >= screenBounds.y - playerHalfHeight)
            {
                readyToJump = true;
            }
        }
    }
}
