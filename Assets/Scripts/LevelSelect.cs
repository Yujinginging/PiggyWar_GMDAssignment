using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public int starNum = 0;
    public bool isSelect = false;

    //
    public GameObject levelLock;
    public GameObject stars;
    public GameObject panel;
    public GameObject map;
    public GameObject oops;

    public Text starText;
    public int beginLevelNum =1;
    public int EndLevelNum = 3;


    private void Start()
    {
        

        //after every level played, the stars will be stored to count if possible to move to next level
        //int totalStars = PlayerPrefs.GetInt("totalStarNum",0);
        if(PlayerPrefs.GetInt("totalStarNum", 0) >= starNum)
        {
            isSelect = true;
            
        }

        if (isSelect)
        {
            levelLock.SetActive(false);
            stars.SetActive(true);


            //TODO:text change
            int counts = 0;
            for(int i = beginLevelNum; i < EndLevelNum +1; i++)
            {
                counts += PlayerPrefs.GetInt("level" + i.ToString(), 0);
            }
            starText.text = counts.ToString() + "/9";
        }
    }

    //when user clicks the level
    public void WhenSelected()
    {
        if (isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
        else //if not able to go to the selected level bcs lack stars, jump a reminder
        {
            map.SetActive(false);
            oops.SetActive(true);
        }
    }

    public void PanelReturn()
    {
        
            panel.SetActive(false);
            map.SetActive(true);
       
    }

}
