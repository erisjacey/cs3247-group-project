using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Students_cutscene : MonoBehaviour
{
    public float delay; //This implies a delay of 2 seconds.
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
