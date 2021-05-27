using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpSpeed = 40;
    public float gravity = -20;
    Transform groundCheck;
    LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        controller = GetComponent<CharacterController>();
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        bool isGrounded = Physics.CheckSphere(groundCheck.position,0.15f,groundLayer);
        direction.y += gravity * Time.deltaTime;
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpSpeed;
            }
        }
        
  


        controller.Move(direction * Time.deltaTime);
    }
}
