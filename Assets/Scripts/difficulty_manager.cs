using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficulty_manager : MonoBehaviour
{
    public List<Toggle> difficultys;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i + 1 == SaveManager.Instance.difficulty())
            {
                difficultys[i].isOn = true;
            }
        }
    }
}
