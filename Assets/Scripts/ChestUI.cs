using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Random = System.Random;//new
using System;//new
using UnityEngine.SceneManagement;

public class ChestUI : MonoBehaviour
{
    
    public GameObject contBtn; //new
    Random rand = new Random();//new
    int gainedCoin = 0; //new
    public List<Text> coinQuantities = new List<Text>();//new
    public static ChestUI chestUI = new ChestUI();
    public GameObject starImg;
    public Text winCoinTx;
    public Text totCoinTx;
    public int newCoin = 0; 
    public int oldCoin; 
    public int tempCoin;
    public float coinCount; //artma +5 
    public float lowCount; //azalma -5
    bool control = false;
    public int i = 0;
    public List<GameObject> keyList = new List<GameObject>();
    public List<Button> chestButList = new List<Button>();
    public List<GameObject> openChestList = new List<GameObject>();
    public Text amount;
    
    private void Awake()
    {
        chestUI = this;
    }
    void Start()
    {
        totCoinTx.text = (PlayerPrefs.GetInt("totalCoinKey")).ToString();
        oldCoin = Convert.ToInt32(totCoinTx.text);

        foreach(Text t in coinQuantities) //new
        {
            t.text = (5*rand.Next(5, 21)).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (control)
        {
            if (coinCount <= newCoin && lowCount >= 1) 
            {
                lowCount -= 5;
                coinCount += 5;
                winCoinTx.text = lowCount.ToString();
                totCoinTx.text = (tempCoin + coinCount).ToString(); 
               
                    
            }
            else
            {
                control = false; 
                
            }    
        } 
    }
    public void openChest()
    {
        
        if(keyList[i].activeInHierarchy)
        {
            keyList[i].gameObject.SetActive(false);
            
            i++;
        }
        if (i >= keyList.Count) 
        {
            foreach(var button in chestButList)
            {
                button.interactable = false;
         
            }
            starImg.SetActive(true);
            
            PlayerPrefs.SetInt("totalCoinKey", PlayerPrefs.GetInt("totalCoinKey") + gainedCoin);
            winCoin(gainedCoin); //new
            
            StartCoroutine(WaitScene());//new
            

        }
    }
    public void winCoin(int value)
    {
        newCoin = value ;
        tempCoin = oldCoin;
        oldCoin += newCoin;
        
        lowCount = newCoin;
        coinCount = 0;
        control = true;
    }
    public void GetCoin(Text gain) //new
    {
        int coin = Convert.ToInt32(gain.text.ToString());
        gainedCoin += coin;
        openChest();

    }
    IEnumerator WaitScene()  
    {
        yield return new WaitForSeconds(2);
        starImg.SetActive(false);
        contBtn.SetActive(true);
    }
    public void ChestReset()
    {
        SceneManager.LoadScene("UIFullScene");
    }
}
