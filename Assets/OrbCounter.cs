using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCounter : MonoBehaviour
{
	public int OrbCountNum;
    public Text OrbCount;

    private void Start()
    {
        OrbCount.text = OrbCountNum.ToString();
    }

    public void IncreaseCount()
    {
		OrbCountNum++;
		UpdateCountText(OrbCountNum);
    }

	void UpdateCountText(int amount)
	{
		OrbCount.text = amount.ToString();
	}
}
