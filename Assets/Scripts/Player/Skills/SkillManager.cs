using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillManager : MonoBehaviour
{
    private int skillBarId = 0;
    private int activeSkill;
    [SerializeField] private GameObject[] skillBars = new GameObject[3];

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Contains("Supermarket")
            || currentScene.Contains("Shop_Creation 1"))
        {
            UnlockHope();
        }
        else if (currentScene.Contains("Classroom")
            || currentScene.Contains("Shop_Creation 2"))
        {
            UnlockExcitement();
        }
        else if (currentScene.Contains("House")
            || currentScene.Contains("Shop_Creation 3"))
        {
            UnlockConfidence();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // SetSkillBar(skillBarId);
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
        if (skillBars.Length == 0) return;

        for (int i = 0; i < skillBars.Length; i++)
        {
            if (skillBars[i]) skillBars[i].SetActive(i == id);
        }
    }
}
