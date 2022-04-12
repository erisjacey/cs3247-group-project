using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorController : MonoBehaviour
{   
    private DoorController DoorController;

    void Start()
    {
        DoorController = transform.parent.GetComponentInChildren<DoorController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.tag == "Player") 
        {
           DoorController.OpenDoor();
        }
    }
}
