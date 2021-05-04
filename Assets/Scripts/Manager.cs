using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public List<cutepig> cuties;
    public List<badpig> badPigs;


    //
    public static Manager _instance;  //use singleton pattern to help cutepigs "fly" and disappear one by one in order

    private Vector3 originalPos; //original position of cute pig

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
        for(int i =0; i< cuties.Count;i++)
        {
            if(i == 0)
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
    public void NextCuty()
    {
        if(badPigs.Count > 0)
        {
            if(cuties.Count > 0)
            {
                //make next cutypig able to fly
                Initiated();
            }
            else
            {
                //we lose the game

            }
        }
        else
        {
            //we win,yeahhh! >.<
        }
    }
}
