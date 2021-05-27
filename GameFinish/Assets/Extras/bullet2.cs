using UnityEngine;
using System.Collections;
using BulletSharp;
using BulletUnity;

public class bullet2 : BCollisionCallbacksDefault
{
    public float speed = 20.0f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

    public override void BOnCollisionEnter(CollisionObject other, PersistentManifoldList manifoldList)
    {
        Debug.Log("Hit");
        Destroy(gameObject);
    }
}
