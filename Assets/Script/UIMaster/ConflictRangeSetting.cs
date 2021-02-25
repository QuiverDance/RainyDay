using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ConflictRangeSetting : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    void Start()
    {
        if(DataCenter.instance.gameData.isShowRange == false)
        {
            on.SetActive(false);
            off.SetActive(true);
        }
        else
        {
            off.SetActive(false);
            on.SetActive(true);
        }
    }
    void Update()
    {
        if (DataCenter.instance.gameData.isShowRange == false)
        {
            on.SetActive(false);
            off.SetActive(true);
        }
        else
        {
            off.SetActive(false);
            on.SetActive(true);
        }
    }
}
