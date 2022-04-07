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

    [SerializeField] public bool isBossDoor;
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
            KeyManager keyManager = FindObjectOfType<KeyManager>();
            int numKeys = isBossDoor ? keyManager.GetNumBossKeys() : keyManager.GetNumKeys();
            if (keyManager.GetNumKeys() >= keysNeeded) 
            {
                if (frontFacing) 
                {
                    exitPoint = other.transform.position.y < transform.position.y ? 1 : 0;
                }
                else
                {
                    exitPoint = other.transform.position.x < transform.position.x ? 1 : 0;
                }

                StartCoroutine(UnlockDoor(keyManager));
            }
            else
            {
                uiAnimator.SetBool("playerInRange", true);
            }
        }
    }

    IEnumerator UnlockDoor(KeyManager keyManager)
    {
        uiAnimator.SetTrigger("unlockDoor");
        yield return new WaitForSeconds(0.6f);

        // Use keys
        if (isBossDoor)
        {
            keyManager.UseBossKeys(keysNeeded);
        }
        else
        {
            keyManager.UseKeys(keysNeeded);
        }

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
