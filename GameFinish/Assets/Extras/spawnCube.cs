using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCube : MonoBehaviour
{
    public GameObject Cube;
    public Transform targetPoint;
    public Transform target2;
    public GameObject Door;
    public bool doorIsOpening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening == true)
        {
            Debug.Log("MouseDown");
            Door.transform.Translate(Vector3.up * Time.deltaTime * 800);
            //if the bool is true open the door

        }
        if (Door.transform.position.y > 30f)
        {
            doorIsOpening = false;
            //if the y of the door is > than 7 we want to stop the door
        }
    }
    void OnMouseDown()
    { //THIS FUNCTION WILL DETECT THE MOUSE CLICK ON A COLLIDER,IN OUR CASE WILL DETECT THE CLICK ON THE BUTTON

        Instantiate(Cube, targetPoint.position, targetPoint.rotation);
        //if we click on the button door we must start to open
        Instantiate(Cube, target2.position, target2.rotation);
        doorIsOpening = true;
    }
}
