using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatScript : MonoBehaviour
{
    [SerializeField] GameObject chat;
    // Update is called once per frame
    void Update()
    {
        if (chat.activeSelf)
        {
            StartCoroutine(coroutineA());
        }
    }

    IEnumerator coroutineA()
    {
        // wait for 1 second
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
