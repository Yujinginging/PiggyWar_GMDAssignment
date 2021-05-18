using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour
{
    public GameObject panel;
    public GameObject map;
    public GameObject oops;


    //when user clicks the level
    public void WhenSelected()
    {
       
            map.SetActive(false);
            oops.SetActive(true);
        
    }

    public void PanelReturn()
    {

        oops.SetActive(false);
        map.SetActive(true);

    }
}
