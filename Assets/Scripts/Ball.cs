using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;

    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector2 rndvec2 = UnityEngine.Random.insideUnitCircle;
        Vector3 rndvec3 = new Vector3(rndvec2.x, 0, rndvec2.y);
        SetVelocity(rndvec3);

    }
    public void ChangeVelocity(Vector3 dv)
    {
        SetVelocity((rb.velocity + dv * speed).normalized * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        SetVelocity(rb.velocity.normalized * speed);
    }
    private void SetVelocity(Vector3 v)
    {
        rb.velocity = v;
        SetRotation();
    }
    private void SetRotation()
    {
        rb.angularVelocity = (Quaternion.Euler(0, 90, 0) * rb.velocity * speed);
    }
    private void OnDestroy()
    {
        rb = null;
    }
}
