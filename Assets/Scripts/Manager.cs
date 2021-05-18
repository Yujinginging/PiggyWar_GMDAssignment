using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public List<cutepig> cuties;
    public List<badpig> badPigs;


    //
    public static Manager _instance;  //use singleton pattern to help cutepigs "fly" and disappear one by one in order

    private Vector3 originalPos; //original position of cute pig

    //get position of uis
    public GameObject win;
    public GameObject lose;


    //star obj
    public GameObject[] stars;

    private int total = 3;

    private int starNum;

    private void Awake()
    {
        _instance = this;
        if (cuties.Count > 0)
        {
            originalPos = cuties[0].transform.position;
        }
    }


    private void Start()
    {
        Initiated();
    }
    //cutepig
    private void Initiated()
    {
        for (int i = 0; i < cuties.Count; i++)
        {
            if (i == 0)
            {
                cuties[i].transform.position = originalPos;
                cuties[i].enabled = true;
                cuties[i].springJoint2D.enabled = true;
            }
            else
            {
                cuties[i].enabled = false;
                cuties[i].springJoint2D.enabled = false;
            }
        }
    }



    //see if cute pigs already won
    //logic
    public void NextCuty()
    {
        if (badPigs.Count > 0)
        {
            if (cuties.Count > 0)
            {
                //make next cutypig able to fly
                Initiated();
            }
            else
            {
                //we lose the game
                lose.SetActive(true);
            }
        }
        else
        {
            //we win,yeahhh! >.<
            win.SetActive(true);
        }
    }

    public void ShowStarsForWin()
    {
        StartCoroutine("ShowStarInOrder");
    }

    IEnumerator ShowStarInOrder()
    {

        for (; starNum < cuties.Count + 1; starNum++)
        {
            if (starNum >= stars.Length)
            {
                break; //if there are more than three cutepigs in one level
            }
            yield return new WaitForSeconds(0.25f);
            stars[starNum].SetActive(true);
        }

        //print(starNum);
    }

    //store star num
    public void SaveStars()
    {
        if (starNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("levelInMapNow"))){
            PlayerPrefs.SetInt(PlayerPrefs.GetString("levelInMapNow"), starNum);
        }

        //get total star number
        int sum = 0;
        for (int i = 1;i< total; i++)
        {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalStarNum", sum); //totalstarnum is in levelselect
    }

    //button functions
    //retry
    public void Retry()
    {
        SaveStars();
        SceneManager.LoadScene(2); //02-game scene
    }

    public void BackToFront()
    {
        SaveStars();
        SceneManager.LoadScene(1); //01-level
    }
}
