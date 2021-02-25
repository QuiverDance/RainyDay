using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Slider_Control : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = DataCenter.instance.gameData.volume;
    }

    void Update()
    {
        DataCenter.instance.SetVolume(slider.value);
    }
}
