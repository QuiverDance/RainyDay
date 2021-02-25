using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Item_Generate : MonoBehaviour
{
    public int item_number = 4;
    public int Generate_Delay = 5;
    private int random_number;

    private float timer;
    public bool[] item_valid_list = new bool[4];
    public enum ITEMCODE {COAL, OIL, GUNPOWDER, OXYGEN};
    void Start()
    {
        for (int i = 0; i < item_number; i++)
            item_valid_list[i] = false;
        timer = 0f;
        SetRandomItem();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= Generate_Delay)
        {
            SetRandomItem();
            timer = 0;
        }
        Reset();
    }
    private void SetRandomItem()
    {
        random_number = Random.Range(0, item_number);
    }
    public bool ItemGenerate(ITEMCODE item)
    {
        if (item_valid_list[(int)item] == true)
            return true;
        else
            return false;
    }

    private void Reset()
    {
        for (int i = 0; i < item_number; i++)
            item_valid_list[i] = false;

        item_valid_list[random_number] = true;
    }
}
