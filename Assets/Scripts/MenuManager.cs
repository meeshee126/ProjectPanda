using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject generator;
    public Intro intro;
    public Animator pandaAni;
    public GameObject uiMain;
    public GameObject uiPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !uiMain.activeInHierarchy)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // checks after pressing "escape" button if pause Menu is active or not

        // if pause Menu is not active
        if (uiPause.activeInHierarchy == false)
        {
            // pause Menu is setting active
            uiPause.gameObject.SetActive(true);

            // disable enviroment physics
            Time.timeScale = 0;

            // disable Ball Controlls
           // Ball ball = GameObject.Find("Ball").GetComponent<Ball>();
            //ball.enabled = false;
        }

        // if pause menu is active after pressing "escape" button
        else
        {
            // pause menu is setting inactive
            uiPause.gameObject.SetActive(false);

            // enable enviroment physics
            Time.timeScale = 1;

            // enable Ball Controlls
           // Ball ball = GameObject.Find("Ball").GetComponent<Ball>();
          //  ball.enabled = true;
        }
    }

    public void StartGame()
    {
        generator.SetActive(true);
        intro.enabled = true;
        pandaAni.enabled = true;
        uiMain.SetActive(false);
    }

    public void ResumeGame()
    {
        PauseGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
