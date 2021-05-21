using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Random = System.Random;
using System;

public class ShopManager : MonoBehaviour
{
    public Image denemeee;
    public GameObject boughtScreen;

    public Button button;
    public Text deneme;
    public Text totalCoin;
   
    public Image itemImage;
    public int newCoin = 0; 
    public int oldCoin = 0;
    public Text priceText;
    public float lowCount;
    public int tempCoin = 0;
    public float coinCount;
    public bool control = false;
    int result;
    // Start is called before the first frame update
    void Start()
    {
        totalCoin.text = (PlayerPrefs.GetInt("totalCoinKey")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
 

        oldCoin = Convert.ToInt32(totalCoin.text);


        if (control)
        {
            
            if (coinCount < newCoin )
            {
                lowCount -= 5;
                coinCount += 5;
                priceText.text =  lowCount.ToString();
                totalCoin.text = (tempCoin - coinCount).ToString();

            }
            else
            {

                
                control = false;
                deneme.text = "";
                button.gameObject.SetActive(false);
            }

        }
        
        
        
        if (Convert.ToInt32(priceText.text) > Convert.ToInt32(totalCoin.text))
        {
            
            button.interactable = false;
           
        }


    }
    public void buy()
    {
        boughtScreen.SetActive(true);
        denemeee.sprite = itemImage.sprite;
        loseCoin(Convert.ToInt32(priceText.text));
        deneme.text = "-" + priceText.text;
        PlayerPrefs.SetInt("totalCoinKey", PlayerPrefs.GetInt("totalCoinKey") - Convert.ToInt32(priceText.text));
    }
    public void loseCoin(int value)
    {
        StartCoroutine(WaitScene());
        newCoin = value;
        tempCoin = oldCoin;
        oldCoin -= newCoin;
        lowCount = newCoin;
        coinCount = 0;
        control = true;
    }
    IEnumerator WaitScene()
    {
        yield return new WaitForSeconds(4);
    }

}
