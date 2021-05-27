﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>
                      ().AddForce(Vector3.right * 500);
        }
    }
}
