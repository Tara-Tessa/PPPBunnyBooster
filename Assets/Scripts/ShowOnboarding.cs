using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnboarding : MonoBehaviour
{
    private int OnboardingCounter;
    public GameObject onboarding;
    public GameObject[] panels;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        OnboardingCounter = 0;
        Debug.Log(OnboardingCounter);

        for (int i=0; i< panels.Length; i++)
        {
            Debug.Log(panels[i]);
            panels[OnboardingCounter].SetActive(true);
        }
    }

    public void Previous() {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(PrevPanel());  
    }

    IEnumerator PrevPanel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        OnboardingCounter--;
        Debug.Log(OnboardingCounter);

        for (int i = 0; i < panels.Length; i++)
        {
            Debug.Log(panels[i]);
            panels[OnboardingCounter + 1].SetActive(false);
            panels[OnboardingCounter].SetActive(true);
        }

        transition.SetTrigger("Stop");
    }

    public void Next()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(NextPanel());
    }

    IEnumerator NextPanel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (OnboardingCounter < panels.Length - 1)
        {
            OnboardingCounter++;
            Debug.Log(OnboardingCounter);

            for (int i = 0; i < panels.Length; i++)
            {
                Debug.Log(panels[i]);
                panels[OnboardingCounter - 1].SetActive(false);
                panels[OnboardingCounter].SetActive(true);
            }
        }
        else
        {
            onboarding.SetActive(false);
            OnboardingCounter = 0;
        }

        transition.SetTrigger("Stop");
    }

}
