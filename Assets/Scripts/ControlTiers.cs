using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTiers : MonoBehaviour
{
    public Tier[] tiers;
    public GameObject ActiveTier;
    public int numActiveTier;

    void Start()
    {
        ActivateTier(0);
    }

    public void ActivateTier(int numTier)
    {
        for (int i = 0; i < tiers.Length; i++)
        {
            tiers[i].IsActive = false;
            tiers[i].GetComponent<Tier>().HideArrow();
        }

        //Debug.Log("zet tier isActive" + numTier);
        //Bollen.Counter = 0;
        tiers[numTier].IsActive = true;
        ActiveTier = tiers[numTier].gameObject;
        numActiveTier = numTier;
        if (numTier >= 0)
        {
            tiers[numTier].GetComponent<Tier>().ShowArrow();
        }
    }

    public void CopyNextTier()
    {
        Tier NewTier = tiers[numActiveTier];

        for (int i=0; i<4; i++)
        {
            NewTier.BollenObj.GetComponent<Bollen>().ObjBollen[i].GetComponent<Bol>().ChangeColor(tiers[numActiveTier - 1].RightCombination[i]);
        }
    }
}
