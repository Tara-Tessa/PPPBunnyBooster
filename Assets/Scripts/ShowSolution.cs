using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSolution : MonoBehaviour
{
    public bool Show = true;

    public void HideSolution()
    {

        if (Show)
        {
            gameObject.SetActive(false);
            Show = false;
        } else
        {
            gameObject.SetActive(true);
            Show = true;
        }

        
    }

    
}
