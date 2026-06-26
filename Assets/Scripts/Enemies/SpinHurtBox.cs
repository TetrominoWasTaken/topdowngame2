using UnityEngine;

public class SpinHurtBox : HurtBox
{
    public float rotateSpeed;
    public float spinDistance;
    void Update()
    {
        transform.position = transform.parent.position + new Vector3(Mathf.Sin(Time.time), Mathf.Cos(Time.time), 0) * spinDistance;
    }
}
