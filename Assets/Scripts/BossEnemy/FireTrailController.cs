using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireTrailController : MonoBehaviour
{   
    [SerializeField]
    private float burnDuration;
    [SerializeField]
    private int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Burn());
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
        }
    }

    IEnumerator Burn()
    {   
        yield return new WaitForSeconds(burnDuration);
        Destroy(gameObject);
    }

}
