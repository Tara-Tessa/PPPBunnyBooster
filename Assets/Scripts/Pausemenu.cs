using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject playMenuUI;
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(true);
        playMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        playMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MasterMindL1()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(MML1());
    }

    IEnumerator MML1()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MasterMindL1");
    }

    public void MasterMindL2()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(MML2());
    }

    IEnumerator MML2()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MasterMindL2");
    }

    public void Slingshot()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(SS());
    }

    IEnumerator SS()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Slingshot");
    }

    public void Home()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(HM());
    }

    IEnumerator HM()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Home");
    }

    public void Levels()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LVLS());
    }

    IEnumerator LVLS()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Levels");
    }

    public void Leave()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
        print("Leaving...");
    }
}
