using UnityEngine;
using System;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public Text deathText;
    public Text levelsCompleted;
    public Text ratio;

    public void Awake()
    {
        float completedLevels = SaveManager.Instance.completedLevels();
        float deaths = SaveManager.Instance.deaths();

        deathText.text = "Deaths: " + deaths.ToString();
        levelsCompleted.text = "Levels Completed: " + completedLevels.ToString();
        float ratio_unrounded = (completedLevels / deaths);
        float ratio_rounded = (float) Math.Round(ratio_unrounded, 2);
        Debug.Log(ratio_unrounded);
        Debug.Log(ratio_rounded);
        ratio.text = "Ratio: " + ratio_rounded.ToString();
        
        
    }


}
