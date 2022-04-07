using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCounter : MonoBehaviour
{
	public int orbNum;
  public Text orbCount;

  private void Start()
  {
    orbCount.text = orbNum.ToString();
  }

  public int GetOrbCount()
  {
    return orbNum;
  }

  public void IncreaseCount()
  {
    orbNum++;
    UpdateCountText(orbNum);
  }

  public void SetCount(int newCount)
  {
    orbNum = newCount;
    UpdateCountText(orbNum);
  }

	void UpdateCountText(int amount)
	{
		orbCount.text = amount.ToString();
	}
}
