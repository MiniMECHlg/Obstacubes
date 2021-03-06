using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class text_manager : MonoBehaviour
{

    public Text level_text;

    // Update is called once per frame
    void Start()
    {
        level_text.text = SceneManager.GetActiveScene().name;
    }
}
