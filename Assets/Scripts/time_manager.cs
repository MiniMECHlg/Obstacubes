using UnityEngine;

public class time_manager : MonoBehaviour
{
    public float slowdownFactor = 0.25f;
    public float slowdownLength = 2f;

    void Update ()
    {
        if (pause_menu.game_paused == false)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0.25f, 1f);
        }
    }

    public void slow_motion ()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
