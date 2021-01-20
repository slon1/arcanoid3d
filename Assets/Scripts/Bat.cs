using System;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public event Action<float> OnBatCollision = delegate { };
    public float Speed { get => speed; set => speed = value; }

    private float speed;
    private float xMaxBorder, xMinBorder;
    private Renderer rend;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetBorderX(float _xMaxBorder, float _xMinBorder)
    {
        Bounds bounds = rend.bounds;
        xMaxBorder = _xMaxBorder - bounds.extents.x;
        xMinBorder = _xMinBorder + bounds.extents.x;
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnBatCollision?.Invoke(GetFactor(collision.contacts[0].point.x));
    }
    private float GetFactor(float contactX)
    {
        float xMaxBat = rend.bounds.center.x + rend.bounds.extents.x;
        float xMinBat = rend.bounds.center.x - rend.bounds.extents.x;
        return (contactX - xMinBat) / (xMaxBat - xMinBat);
    }
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f)
        {
            Vector3 dt = transform.right * Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            float newX = transform.position.x + dt.x;
            if (newX > xMinBorder && newX < xMaxBorder)
            {
                transform.Translate(dt);
            }
        }
    }
    private void OnDestroy()
    {
        rend = null;
    }

}
