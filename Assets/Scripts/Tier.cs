using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier : MonoBehaviour
{
    public bool IsActive = false;
    public bool LineComplete = false;

    public GameObject Solutions;
    public GameObject BollenObj;
    public Material[] RightCombination;
    public GameObject Arrow;

    public void UpdateCombination()
    {
        RightCombination = BollenObj.GetComponent<Bollen>().RightCombination();
        LineComplete = BollenObj.GetComponent<Bollen>().CompleteTier();
    }

    public void ShowArrow()
    {
        Arrow.gameObject.SetActive(true);
    }

    public void HideArrow()
    {
        Arrow.gameObject.SetActive(false);
    }
}
