using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoelTier : MonoBehaviour
{
    public bool LineComplete = false;

    public GameObject BollenObj;
    public Material[] RightCombination;

    public void UpdateCombination()
    {
        RightCombination = BollenObj.GetComponent<Bollen>().RightCombination();
        LineComplete = BollenObj.GetComponent<Bollen>().CompleteTier();
    }
}
