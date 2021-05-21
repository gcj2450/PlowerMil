using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NewShopManager : MonoBehaviour
{
    public int mainPrice=121;
    public int customPrice;
    public Text mainPriceText;
    public Image mainCustomImage;
    public GameObject boughtScreen;
    public bool buttonControl = false;
    
    public List<Image> customImages = new List<Image>();
    public List<Button> buyButtons = new List<Button>();
    public List<Button> useButtons = new List<Button>();
    public List<Text> priceTexts = new List<Text>();
    void Start()
    {
        mainPrice = Convert.ToInt32(mainPriceText);
    }

   
    void Update()
    {
        
    }
    public void Click()
    {

        for (int i = 0; i < buyButtons.Count; i++)
        {
            buyButtons[i].onClick.AddListener(()=>BuyCustom(i));
        }
    }
    public void BuyCustom(int value)
    {

    }
}
