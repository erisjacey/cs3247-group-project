using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private int numKeys = 0;
    private int numBossKeys = 0;

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
