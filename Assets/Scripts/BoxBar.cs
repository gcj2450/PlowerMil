using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxBar : MonoBehaviour
{
    public static BoxBar bar; 
    
    public Image Bar;
    public GameObject CloseBox;
    public GameObject OpenBox;
    public Text percentText;
    public bool control=false;
    
    [SerializeField]
    private float fill;
    [SerializeField]
    private float lerpSpeed= 1f;

    private float value = 0;
    private float oldValue = 0;
    
    //public bool control = false;



    //public bool deneme = false;

     void Awake()
    {
        bar = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //oldValue = PlayerPrefs.GetFloat("giftbar");
       
        GetValue(25);
      


    }

    // Update is called once per frame
    void Update()
    {
       
        if (control)
        {
            percentText.text = "%"+(Bar.fillAmount*100).ToString(("F0"));
           
            if(Bar.fillAmount != fill)
            {
                Bar.fillAmount = Mathf.Lerp(Bar.fillAmount,fill,Time.deltaTime*lerpSpeed);
                percentText.gameObject.SetActive(true);
            }
            else
            {
                Bar.fillAmount = fill;
              
            }

            if ( Bar.fillAmount>=0.99f)
            {
                percentText.gameObject.SetActive(false);
                oldValue = 0;
                fill = 0;
                Bar.fillAmount = 0;
                this.gameObject.GetComponent<Image>().enabled = false;
                OpenBox.SetActive(true);
                
                control = false;
            }
                
            
            
        }

        // if( Input.GetKeyDown("space"))
        // {
        //     BoxBar.bar.GetValue(LevelManager.levelManager.currentLevel.giftPoint);
        // }
    }
    public void GetValue(float m)
    {   percentText.gameObject.SetActive(true);
        OpenBox.SetActive(false);
        value = m;
        this.gameObject.GetComponent<Image>().enabled = true;
        oldValue += value;
        //PlayerPrefs.SetFloat("giftbar",oldValue);
        fill = oldValue / 100;
        control = true;
    
    }

   
}