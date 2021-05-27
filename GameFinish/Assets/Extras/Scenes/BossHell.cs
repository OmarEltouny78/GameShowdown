using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHell : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;
    public float fireBallSpeed = 600;
    float timeLeftGame = 10f;
    public Vector2 direction;
    void Start()
    {
        direction.x = -20;
    }
    void Update()
    {
        timeLeftGame -= Time.deltaTime;
        if (timeLeftGame< 0)
        {
            Debug.Log("Game");
        }else{
            Spawner(0, 10);
        }
        
    }
    public void FireBallAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);

    }
    public void Spawner(float timeLeft,float org)
    {
        timeLeft -= 1;
        if (timeLeft < 0)
        {
            FireBallAttack();
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Aloy");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterController>
                      ().Move(direction);
            Destroy(gameObject);

        }
        
    }
}
