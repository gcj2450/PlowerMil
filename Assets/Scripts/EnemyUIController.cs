using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    public static EnemyUIController enemyUIControl;

    public Sprite baseIcon, airIcon, tickIcon;
    public List<Image> enemysIcon = new List<Image>();
    public List<Image> enemysSprite = new List<Image>();

    public int k;
    public int x;
    // Start is called before the first frame update

    private void Awake()
    {
        enemyUIControl = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTotalCount(int count)
    {
        for (int i = 0; i < enemysIcon.Count; i++)
        {
            enemysIcon[i].gameObject.SetActive(false);

        }
        k = 0;
        x = 0;

        for(int i =0; i<count; i++)
        {
            enemysIcon[i].gameObject.SetActive(true);
        }
    }

    public void TickEnemy()
    {
        enemysSprite[x].sprite = tickIcon;
        x++;
    }
}
