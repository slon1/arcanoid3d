using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action OnBlockCollision = delegate { };
    // Start is called before the first frame update
   
    private void OnCollisionEnter(Collision collision)
    {
        OnBlockCollision?.Invoke();
    }
    
   
}
