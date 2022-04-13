using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChat : MonoBehaviour
{
    [SerializeField] GameObject chat;
    [SerializeField] GameObject nextChat;
    [SerializeField] float endTime;
    
    // Start is called before the first frame update
    void Start()
    {   
        
        StartCoroutine(coroutineA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator coroutineA()
    {

        yield return new WaitForSeconds(endTime);
        if (nextChat != null)
        {
            nextChat.SetActive(nextChat);
        }
        Destroy(gameObject);
    }
}
