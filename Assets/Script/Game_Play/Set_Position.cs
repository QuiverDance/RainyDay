using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Set_Position : MonoBehaviour
{
    public GameObject player;
    private Vector3 position;
    void Start()
    {
        position = Vector3.zero;
        if (DataCenter.instance.gameData.isShowRange == false)
            gameObject.SetActive(false);

    }

    void Update()
    {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y - 0.7f;
        position.z = player.transform.position.z;
        transform.position = position;

        if (GameManager.instance.isGameover)
            gameObject.SetActive(false);
    }
}
