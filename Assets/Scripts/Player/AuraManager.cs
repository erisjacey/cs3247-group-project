using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraManager : MonoBehaviour
{
    private const int HOPE = 0;
    private const int EXCITEMENT = 1;
    private const int CONFIDENCE = 2;

    private Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerAura(int skill)
    {
        switch (skill)
        {
            case HOPE:
                Hope();
                break;
            case EXCITEMENT:
                Excitement();
                break;
            case CONFIDENCE:
                Confidence();
                break;
            default:
                break;
         }
    }

    private void Hope()
    {
        myAnim.SetTrigger("hope");
        //myAnim.Play("Hope2");
    }

    private void Excitement()
    {
        myAnim.SetTrigger("excitement");
    }

    private void Confidence()
    {
        myAnim.SetTrigger("confidence");
    }
}
