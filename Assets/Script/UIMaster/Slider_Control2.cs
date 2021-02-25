using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Control2 : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = DataCenter.instance.gameData.sensitivity;
    }

    void Update()
    {
        DataCenter.instance.SetSensitivity(slider.value);
    }
}
