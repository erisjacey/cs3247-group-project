using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private int numKeys = 0;
    [SerializeField] private int numBossKeys = 0;

    [SerializeField] private Text keyCount;
    [SerializeField] private Text bossKeyCount;

    void Update()
    {
        keyCount.text = numKeys.ToString();
        bossKeyCount.text = numBossKeys.ToString();
    }

    public int GetNumKeys() 
    {
        return numKeys;
    }

    public int GetNumBossKeys() 
    {
        return numBossKeys;
    }

    public void AddKey() 
    {
        numKeys += 1;
    }

    public void AddBossKey() 
    {
        numBossKeys += 1;
    }

    public void UseKeys(int keysUsed) 
    {
        numKeys -= keysUsed;
    }

    public void UseBossKeys(int keysUsed) 
    {
        numBossKeys -= keysUsed;
    }

    
}
