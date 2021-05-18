using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{

    private Animator animator;
    public GameObject button;

    //
    public GameObject pausePanel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Retry()
    {
        Time.timeScale = 1; //
        UnityEngine.SceneManagement.SceneManager.LoadScene(2); //02-game scene

    }

    public void Pause()
    {
        //when click "pause"
        //show animation first
        pausePanel.SetActive(true);
        animator.SetBool("isPause", true);
        
        button.SetActive(false);
        
    }

    

    public void Continue()
    {
        Time.timeScale = 1; //?
        animator.SetBool("isPause", false);

    }

    public void PauseAnimEnd()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0; //?
       
    }

    public void ContinueAnimEnd()
    {
        button.SetActive(true);
        pausePanel.SetActive(false);
    }
}
