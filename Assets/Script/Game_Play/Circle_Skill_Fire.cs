using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Circle_Skill_Fire : MonoBehaviour
{
    public GameObject skill;
    public Transform Skill_Location;

    public int max_skill;
    private MemoryPool memory_pool;
    private GameObject[] skill_array;

    private CircleCollider2D circleCollider2D;
    private void OnApplicationQuit()
    {
        memory_pool.Dispose();
    }

    void Start()
    {
        memory_pool = new MemoryPool();
        memory_pool.Create(skill, max_skill);
        skill_array = new GameObject[max_skill];
    }

    void Update()
    { 
        Recall();
    }

    public void Fire()
    {
        for (int i = 0; i < max_skill; i++)
        {
            if (skill_array[i] == null)
            {
                skill_array[i] = memory_pool.NewItem();
                skill_array[i].transform.position = Skill_Location.position;
                break;
            }
        }

    }
    private void Recall()
    {
        for (int i = 0; i < max_skill; i++)
        {
            if (skill_array[i])
            {
                circleCollider2D = skill_array[i].GetComponent<CircleCollider2D>();
                if (circleCollider2D.enabled.Equals(false))
                {
                    circleCollider2D.enabled = true;
                    memory_pool.RemoveItem(skill_array[i]);
                    skill_array[i] = null;
                }
            }
        }
    }

    public void Remove()
    {
        for (int i = 0; i < max_skill; i++)
        {
            Destroy(skill_array[i]);
        }
    }
}
