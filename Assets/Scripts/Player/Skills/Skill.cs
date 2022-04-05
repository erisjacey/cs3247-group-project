using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private GameObject[] skills;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in children)
        {
            if (child.parent == transform)
            {
                childObjects.Add(child.gameObject);
            }
        }
        skills = childObjects.ToArray();
        SetActiveSkill(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveSkill(int id)
    {
        if (id >= skills.Length)
        {
            return;
        }
        for (int i = 0; i < skills.Length; i++)
        {
            Debug.Log(skills[i].name);
            skills[i].SetActive(i == id);
        }
    }
}
