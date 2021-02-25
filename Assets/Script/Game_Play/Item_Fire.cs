using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Item_Fire : MonoBehaviour
{
    public GameObject item;
    public float fire_delay;
    private bool fire_state;

    public int max_item;
    private MemoryPool memory_pool;
    private GameObject[] item_array;
    public Item_Generate vaild;
    public Item_Generate.ITEMCODE item_code;

    private Vector3 location = new Vector3(0, 0, 0);

    private new Camera camera;
    private CircleCollider2D circleCollider2D;
    private void OnApplicationQuit()
    {
        memory_pool.Dispose();
    }

    void Start()
    {
        fire_state = true;
        memory_pool = new MemoryPool();
        memory_pool.Create(item, max_item);
        item_array = new GameObject[max_item];
        camera = Camera.main;
    }

    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            if (vaild.ItemGenerate(item_code))
            {
                SetLocation();
                Fire();
            }
            Recall();
        }
    }

    private void SetLocation()
    {
        location.x = Random.Range(0.0f, Screen.width);
        location.y = Screen.height + 2f;

        location = camera.ScreenToWorldPoint(location);
        location.z = 0;
    }
    private void Fire()
    {
        if (fire_state == true)
        {
            StartCoroutine(FireCycleControl());
            for (int i = 0; i < max_item; i++)
            {
                if (item_array[i] == null)
                {
                    item_array[i] = memory_pool.NewItem();
                    item_array[i].transform.position = location;
                    break;
                }
            }
        }
    }

    private void Recall()
    {
        for (int i = 0; i < max_item; i++)
        {
            if (item_array[i])
            {
                circleCollider2D = item_array[i].GetComponent<CircleCollider2D>();
                if (circleCollider2D.enabled.Equals(false))
                {
                    circleCollider2D.enabled = true;
                    memory_pool.RemoveItem(item_array[i]);
                    item_array[i] = null;
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
}
