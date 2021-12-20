using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionsHanlder : MonoBehaviour
{
    public GameObject[] tiers;
    public ARhandler arHandler;

    public void SolutionHandling()
    {
        for (int i = 0; i < tiers.Length; i++)
        {
            if (tiers[i].GetComponent<Tier>().IsActive && tiers[i].GetComponent<Tier>().LineComplete)
            {
                tiers[i].GetComponent<Tier>().GetComponentInChildren<Solutions>().PlaceSolution();
                arHandler.BolCounter = 0;
            }
        }
    }



    
}