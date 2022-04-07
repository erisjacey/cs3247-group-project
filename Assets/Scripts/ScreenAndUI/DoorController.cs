using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public int keysNeeded = 0;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private int autoLock = 0;

    [SerializeField] private GameObject UI;
    private Animator uiAnimator;
    private Animator doorAnimator;

    [SerializeField] public bool frontFacing;
    private BoxCollider2D[] doorAreas = new BoxCollider2D[2];
    private int exitPoint = -1;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        uiAnimator = UI.GetComponent<Animator>();

        doorAreas = GetComponents<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isOpen) return;

        if (other.tag == "Player") 
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.GetNumKeys() >= keysNeeded) 
            {
                if (frontFacing) 
                {
                    exitPoint = other.transform.position.y < transform.position.y ? 1 : 0;
                }
                else
                {
                    exitPoint = other.transform.position.x < transform.position.x ? 1 : 0;
                }

                StartCoroutine(UnlockDoor(player));
            }
            else
            {
                // UI.transform.Find("keyUI").gameObject.SetActive(true);
                uiAnimator.SetBool("playerInRange", true);
            }
        }
    }

    IEnumerator UnlockDoor(PlayerController player)
    {
        uiAnimator.SetTrigger("unlockDoor");
        yield return new WaitForSeconds(0.6f);
        player.UseKeys(keysNeeded);
        isOpen = true;
        doorAnimator.SetBool("isOpen", isOpen);
    }

    void LockDoor()
    {
        isOpen = false;
        doorAnimator.SetBool("isOpen", isOpen);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        uiAnimator.SetBool("playerInRange", false);

        int exitingFrom;
        if (frontFacing) exitingFrom = other.transform.position.y < transform.position.y ? 0 : 1;
        else exitingFrom = other.transform.position.x < transform.position.x ? 0 : 1;

        if (isOpen && exitingFrom == exitPoint) 
        {
            if (autoLock > 0) 
            {
                autoLock -= 1;
                LockDoor();
            }
        }
    }
}
