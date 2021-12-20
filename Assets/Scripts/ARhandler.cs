using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARhandler : MonoBehaviour
{

    public GameObject[] tiers;
    public int BolCounter;
    private DateTime PrevTimestamp;
    private DateTime Timestamp;

    private void Start()
    {
        BolCounter = 0;
        PrevTimestamp = DateTime.Now;
    }

    public void NextBol()
    {

        for (int i = 0; i < tiers.Length; i++)
        {
            if (tiers[i].GetComponent<Tier>().IsActive)
            {
                Timestamp = DateTime.Now;
                TimeSpan interval = Timestamp - PrevTimestamp;
                //Debug.Log(interval.Seconds);
                
                    Bol bol = tiers[i].GetComponent<Tier>().GetComponentInChildren<Bollen>().transform.GetChild(BolCounter).GetComponent<Bol>();
                if (interval.Seconds > 2)
                {
                if (bol.ColorBol() != bol.defaultColor)
                {
                        if (BolCounter < 3)
                        {
                            BolCounter++;
                        }
                        else
                        {
                            BolCounter = 0;
                        }
                    }
                }
                PrevTimestamp = DateTime.Now;
            }
        }
    }

    public void Shown(Material CardColor)
    {
        Timestamp = DateTime.Now;
        TimeSpan interval = Timestamp - PrevTimestamp;
        Debug.Log(interval.Seconds);

        //if (interval.Seconds > 2)
        //{

        for (int i = 0; i < tiers.Length; i++)
            {
                if (tiers[i].GetComponent<Tier>().IsActive)
                {
                    tiers[i].GetComponent<Tier>().GetComponentInChildren<Bollen>().ChangeBol(CardColor, BolCounter);
                }
            }
        //}
    }

    public void Random()
    {
        Timestamp = DateTime.Now;
        TimeSpan interval = Timestamp - PrevTimestamp;
        //Debug.Log(interval.Seconds);


        for (int i = 0; i < tiers.Length; i++)
        {
            if (interval.Seconds > 2)
            {
                if (tiers[i].GetComponent<Tier>().IsActive)
                {
                    tiers[i].GetComponent<Tier>().GetComponentInChildren<Bollen>().RandomCombination();
                }
            }
        }
        PrevTimestamp = DateTime.Now;
    }
}
