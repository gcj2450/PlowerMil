using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject startScreen,playScreen,winScreen,loseScreen,chestScreen, levelScreen;
    public Text totalCoinText;
    public GameObject starAnim, starFX;
    public Button contBut;


    public static UIManager ui = new UIManager();
   

    private void Awake()
    {
        ui = this;
    }
    void Start()
    {
       
        StartGameUI();
    }

    void Update()
    {
         totalCoinText.text = (PlayerPrefs.GetInt("totalCoinKey")).ToString();
    }
    //Ana Ekran
    public void StartGameUI()
    {
        startScreen.SetActive(true);
        playScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        chestScreen.SetActive(false);
        levelScreen.SetActive(false);
    }
    //Oyun Ekranı
    public void PlayGameUI()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);        
        chestScreen.SetActive(false);
        levelScreen.SetActive(false);
    }
    public void WinGameUI()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(false);
        winScreen.SetActive(true);
        loseScreen.SetActive(false);
        chestScreen.SetActive(false);
        levelScreen.SetActive(false);

    }
    public void LoseGameUI()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(true);       
        chestScreen.SetActive(false);
        levelScreen.SetActive(false);
    }
    //Sandık Ekranı
    public void ChestGameUI()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        chestScreen.SetActive(true);
        levelScreen.SetActive(false);
    }
    public void LevelGameUI()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        chestScreen.SetActive(false);
        levelScreen.SetActive(true);
    }
    public void NextScene()
    {
        StartCoroutine(WaitScene());
    }
    IEnumerator WaitScene()
    {
        yield return new WaitForSeconds(2);
        contBut.interactable = true;
        starAnim.SetActive(false);      // win screen coin anim
        starFX.SetActive(false);        //win screen coin fx
        LevelGameUI();
    }

}
