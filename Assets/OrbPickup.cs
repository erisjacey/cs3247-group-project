using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbPickup : MonoBehaviour
{
    public int orbNum = 0;

    public Text OrbTextUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Orb")
        {
            orbNum ++;
            SetNewOrbNum(orbNum);
            Destroy(collision.gameObject);
        }
    }

    public void SetNewOrbNum(int count)
    {
        orbNum = count;
        OrbTextUI.text = count.ToString();
    }
}
