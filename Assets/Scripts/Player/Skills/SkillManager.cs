using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillManager : MonoBehaviour
{
    private int skillBarId = 0;
    private int activeSkill;
    private GameObject[] skillBars;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Contains("Supermarket"))
        {
            UnlockHope();
        }
        else if (currentScene.Contains("Classroom"))
        {
            UnlockExcitement();
        }
        else if (currentScene.Contains("House"))
        {
            UnlockConfidence();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        skillBarId = 0;
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

    // Returns true if successful change, false otherwise
    public bool SetActiveSkill(int id)
    {
        if (id > skillBarId)
        {
            return false;
        }
        activeSkill = id;
        skillBars[skillBarId].GetComponent<Skill>().SetActiveSkill(id);
        FindObjectOfType<AuraManager>().TriggerAura(id);
        return true;
    }

    public int GetActiveSkill()
    {
        return activeSkill;
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
