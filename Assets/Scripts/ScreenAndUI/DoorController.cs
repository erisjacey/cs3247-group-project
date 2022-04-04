using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public int keysNeeded = 0;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool blocked = false;

    [SerializeField] private GameObject UI;
    private Animator uiAnimator;
    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        uiAnimator = UI.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isOpen) return;

        if (other.tag == "Player") 
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.GetNumKeys() >= keysNeeded) 
            {
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

    private void OnTriggerExit2D(Collider2D other)
    {
        uiAnimator.SetBool("playerInRange", false);
    }
}
