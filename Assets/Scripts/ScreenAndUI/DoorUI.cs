using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUI : MonoBehaviour
{
    void DestroyUnlockUI()
    {
        Destroy(gameObject.transform.Find("UnlockUI").gameObject);
    }
}
