using UnityEngine;
using UnityEngine.SceneManagement;

public class level_complete : MonoBehaviour
{
    public void load_next_level ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
