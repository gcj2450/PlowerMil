using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinCoinScript : MonoBehaviour
{
    public Text gainedCoin;
    public Text totCoinTx;
    public int newCoin;
    public int oldCoin;
    public int tempCoin;
    public float coinCount;
    public float lowCount;
    public int  mainCount;
    bool control = false;
    public Text amount;
    // Update is called once per frame
    void Update()
    {
        totCoinTx.text = (PlayerPrefs.GetInt("totalCoinKey")).ToString();
        oldCoin = Convert.ToInt32(totCoinTx.text);
       

        if (control)
        {
            if (newCoin!=0 && lowCount >= 1)
            {
                mainCount += 5;
                lowCount -= 5;
                newCoin -= 5;
                totCoinTx.text = mainCount.ToString();
                PlayerPrefs.SetInt("totalCoinKey", mainCount);
            }
            else
            {
                control = false;
                amount.text = "";
                oldCoin = mainCount;
            }
        }
    }


    public void Gain()
    {
        amount.text = "+" + Convert.ToInt32(gainedCoin.text);
        
        winCoin(Convert.ToInt32(gainedCoin.text)); //new
        StartCoroutine(WaitScene());//new
    }
    public void winCoin(int value)
    {
        newCoin = value;
        mainCount = oldCoin;
        lowCount = newCoin;
        control = true;
    }

    IEnumerator WaitScene() //new 
    {
        yield return new WaitForSeconds(2);
        
    }
}
