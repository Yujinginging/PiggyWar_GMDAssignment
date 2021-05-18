using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInMapSelect : MonoBehaviour
{
    public bool isSelect = false;
    //
    public Sprite levelBG;
    private Image img;

    public GameObject[] stars;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetChild(0).name == gameObject.name)
        {
            isSelect = true;
        }
        else
        {
            int levelBeforeNum = int.Parse(gameObject.name )- 1;
            if(PlayerPrefs.GetInt("level" + levelBeforeNum.ToString() ) >= 1)
            {
                isSelect = true;
            }

        }

        if (isSelect)
        {
            img.overrideSprite = levelBG;
            transform.Find("number").gameObject.SetActive(true);

            int countS = PlayerPrefs.GetInt("level" + gameObject.name); // get star count from level now
            if(countS > 0)
            {
                for(int i =0;i< countS; i++)
                {
                    stars[i].SetActive(true);
                }
            }
        }
    }

  


    public void Selected()
    {
        if (isSelect)
        {
            PlayerPrefs.SetString("levelInMapNow", "level" + gameObject.name);
            SceneManager.LoadScene(2);
        }
    }
}
