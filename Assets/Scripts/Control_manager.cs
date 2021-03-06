using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_manager : MonoBehaviour
{
    public List<Toggle> controls;

    void Start()
    {
        if (SaveManager.Instance.touch() == true)
        {
            controls[1].isOn = true;
        }else{
            controls[0].isOn = true;
        }
    }
}
