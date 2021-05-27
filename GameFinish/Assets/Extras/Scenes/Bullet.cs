using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bullet: MonoBehaviour
{
    public float bulletSpeed=0.0f;
    public Vector3 dir;
    public float speed = 30.0f;
    public Transform target;
    Transform nearestT;
    Vector3 vectorToTarget;
    float angle;
    public GameObject[] boxes;
    // Start is called before the first frame update
    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box");
        for (int i = 0; i < boxes.Length; i++)
        {
            nearestT = boxes[i].transform;
            target = nearestT;
            vectorToTarget = target.position - transform.position;
            angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }
}
