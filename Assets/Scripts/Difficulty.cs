using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{

    public bool easy;

    public Toggle toggleEasy;

    public GameObject[] Tiers;

    void Start()
    {
        ChangeDifficulty();
    }

    public void ChangeDifficulty()
    {
        if (toggleEasy.isOn)
        {
            easy = true;
        } else
        {
            easy = false;
        }
    }

    public void nextLevel()
    {
        for (int i=0; i<Tiers.Length; i++)
        {
            if (Tiers[i].GetComponent<Tier>().RightCombination != null) { 
            System.Array.Clear(Tiers[i].GetComponent<Tier>().RightCombination, 0, Tiers[i].GetComponent<Tier>().RightCombination.Length);
            }
        }
        easy = false;
    }

}
