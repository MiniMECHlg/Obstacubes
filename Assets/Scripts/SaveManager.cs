using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveScript state;
    public Material playerMaterial;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveScript>(state));
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveScript>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveScript();
            Save();
            Debug.Log("No save file");
        }
        change_current_skin(state.currentSkin);
    }

    public int coins()
    {
        return (state.coins);
    }

    public int difficulty()
    {
        return (state.difficulty);
    }

    public int deaths()
    {
        return (state.deaths);
    }

    public int completedLevels()
    {
        return (state.completedLevels);
    }

    public bool touch()
    {
        return (state.controls);
    }

    public void touch_buttons()
    {
        state.controls = true;
        Save();
    }

    public void touch_controls()
    {
        state.controls = false;
        Save();
    }

    public void level_complete()
    {
        state.completedLevels += 1;
        Save();
    }

    public void death()
    {
        state.deaths += 1;
        Save();
    }

    public void add_coins(int value)
    {
        state.coins += value;
        Save();
    }

    public void set_difficulty_baby()
    {
        state.difficulty = 1;
        Save();
    }

    public void set_difficulty_normal()
    {
        state.difficulty = 2;
        Save();
    }

    public void set_difficulty_pro()
    {
        state.difficulty = 3;
        Save();
    }

    public int currentSkin()
    {
        return (state.currentSkin);
    }

    public void change_current_skin(int index)
    {
        state.currentSkin = index;
        float y = 0;
        float x = 0;

        if (index == 0)
        {
            x = 0.0f;
            y = 0.6666f;
        }
        else if (index == 1)
        {
            x = 0.3333f;
            y = 0.6666f;
        }
        else if (index == 2)
        {
            x = 0.6666f;
            y = 0.6666f;
        }
        else if (index == 3)
        {
            x = 0.0f;
            y = 0.3333f;
        }
        else if (index == 4)
        {
            x = 0.3333f;
            y = 0.3333f;
        }
        else if (index == 5)
        {
            x = 0.6666f;
            y = 0.3333f;
        }
        else if (index == 6)
        {
            x = 0.0f;
            y = 0.0f;
        }
        else if (index == 7)
        {
            x = 0.3333f;
            y = 0.0f;
        }
        else if (index == 8)
        {
            x = 0.6666f;
            y = 0.0000f;
        }

        playerMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));

        Save();
    }

    public bool IsColorOwned(int index)
    {
        return(state.colorOwned & (1 << index)) != 0;
    }

    public bool BuyColor(int index, int cost)
    {
        if (state.coins >= cost)
        {
            state.coins -= cost;
            UnlockColor(index);

            Save();
            return true;
        }else
        {
            return false;
        }
    }

    public void UnlockColor(int index)
    {
        state.colorOwned |= 1 << index;
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}
