using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire : MonoBehaviour
{
    public GameObject enemy;
    public float fire_delay;
    private bool fire_state;

    public int max_enemy;
    private MemoryPool memory_pool;
    private GameObject[] enemy_array;

    private Vector3 location = new Vector3(0, 0, 0);

    private bool harder;

    private new Camera camera;
    private CircleCollider2D circleCollider2D;
    private void OnApplicationQuit()
    {
        memory_pool.Dispose();    
    }

    void Awake()
    {
        fire_state = true;
        memory_pool = new MemoryPool();
        memory_pool.Create(enemy, max_enemy);
        enemy_array = new GameObject[max_enemy];
        harder = true;

        camera = Camera.main;
    }

    void Update()
    {
        if(!GameManager.instance.isGameover)
        {
            SetLocation();
            Fire();
            if (harder)
            {
                StartCoroutine(HarderDelay());
                fire_delay /= 2;
            }
        }
        Recall();
    }

    private void SetLocation()
    {
        location.x = Random.Range(0.0f, Screen.width);
        location.y = Screen.height + 10f;

        location = camera.ScreenToWorldPoint(location);
        location.z = 0;
    }

    private void Fire()
    {
        if(fire_state == true)
        {
            StartCoroutine(FireCycleControl());
            for(int i =0; i< max_enemy; i++)
            {
                if(enemy_array[i] == null)
                {
                    enemy_array[i] = memory_pool.NewItem();
                    enemy_array[i].transform.position = location;
                    break;
                }
            }
        }
    }

    private void Recall()
    {
        for (int i = 0; i < max_enemy; i++)
        {
            if (enemy_array[i])
            {
                circleCollider2D = enemy_array[i].GetComponent<CircleCollider2D>();
                if (circleCollider2D.enabled.Equals(false))
                {
                    circleCollider2D.enabled = true;
                    memory_pool.RemoveItem(enemy_array[i]);
                    enemy_array[i] = null;
                }
            }
        }
    }
    IEnumerator FireCycleControl()
    {
        fire_state = false;

        yield return new WaitForSeconds(fire_delay);
        fire_state = true;
    }

    IEnumerator HarderDelay()
    {
        harder = false;
        yield return new WaitForSeconds(60);
        harder = true;
    }
} 
