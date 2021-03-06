using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{

    public Transform row_1;
    public Transform row_2;
    public Transform row_3;

    public Sprite[] sprites;
    public GameObject img;

    public Material playerMaterial;

    public Text colorBuySetText;
    public Text coins;

    private int[] colorCost = new int[] { 0, 125, 125, 200, 200, 250, 250, 325, 350 };
    private int selectedColorIndex;

    // Start is called before the first frame update
    private void Start()
    {
        InitShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitShop()
    {
        int i = 0;
        foreach (Transform t in row_1)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnColorSelect(currentIndex));

            if (currentIndex == SaveManager.Instance.currentSkin())
            {
                SetColor(currentIndex);
            }


            i++;
        }
        foreach (Transform t in row_2)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnColorSelect(currentIndex));

            if (currentIndex == SaveManager.Instance.currentSkin())
            {
                SetColor(currentIndex);
            }

            i++;
        }
        foreach (Transform t in row_3)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnColorSelect(currentIndex));

            if (currentIndex == SaveManager.Instance.currentSkin())
            {
                SetColor(currentIndex);
            }

            i++;
        }

        coins.text = "Coins: " + SaveManager.Instance.coins();
    }

    private void SetColor(int index)
    {
        img.GetComponent<Image>().sprite = sprites[index];
        SaveManager.Instance.change_current_skin(index);
        colorBuySetText.text = "Current";
    }

    private void OnColorSelect(int currentIndex)
    {
        Debug.Log(currentIndex);

        selectedColorIndex = currentIndex;

        if(SaveManager.Instance.IsColorOwned(currentIndex))
        {
            colorBuySetText.text = "Select";
        }else
        {
            colorBuySetText.text = "Buy: " + colorCost[currentIndex].ToString();
        }
    }

    public void OnColorBuySet()
    {
        if(SaveManager.Instance.IsColorOwned(selectedColorIndex))
        {
            SetColor(selectedColorIndex);
        }else
        {
            if(SaveManager.Instance.BuyColor(selectedColorIndex, colorCost[selectedColorIndex]))
            {
                SetColor(selectedColorIndex);
                coins.text = "Coins: " + SaveManager.Instance.coins();
            }
            else
            {
                Debug.Log("Not enough Money");
            }
        }
    }


}
