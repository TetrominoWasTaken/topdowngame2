using UnityEngine;
using UnityEngine.InputSystem;

public class Arrow : MonoBehaviour
{
    InputAction move;
    public float spinDistance;

    private void Start()
    {
        move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        transform.position = transform.parent.position + new Vector3(move.ReadValue<Vector2>().x, move.ReadValue<Vector2>().y, 0) * spinDistance;

        Vector3 diff = new Vector3(move.ReadValue<Vector2>().x, move.ReadValue<Vector2>().y, 0);
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
