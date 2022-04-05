using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public int skillBarId;
    private GameObject[] skillBars;

    // Start is called before the first frame update
    void Start()
    {
        skillBarId = 2;
        Transform[] children = GetComponentsInChildren<Transform>();
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in children)
        {
            if (child.parent == transform)
            {
                childObjects.Add(child.gameObject);
            }
        }
        skillBars = childObjects.ToArray();
        SetSkillBar(skillBarId);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveSkill(int id)
    {
        skillBars[skillBarId].GetComponent<Skill>().SetActiveSkill(id);
        FindObjectOfType<AuraManager>().TriggerAura(id);
    }

    private void UnlockHope()
    {
        skillBarId = 0;
        SetSkillBar(skillBarId);
    }

    private void UnlockExcitement()
    {
        skillBarId = 1;
        SetSkillBar(skillBarId);
    }

    private void UnlockConfidence()
    {
        skillBarId = 2;
        SetSkillBar(skillBarId);
    }

    private void SetSkillBar(int id)
    {
        for (int i = 0; i < skillBars.Length; i++)
        {
            skillBars[i].SetActive(i == id);
        }
    }
}