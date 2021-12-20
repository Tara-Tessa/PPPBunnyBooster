using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bollen : MonoBehaviour
{
    public GameObject[] ObjBollen;
    public Material[] Colors;
    public Material defaultColor;

    public Material[] RightCombination()
    {
        Material[] Result = new Material[4];

        for (int i = 0; i < ObjBollen.Length; i++)
        {
            Result[i] = ObjBollen[i].GetComponent<Bol>().ColorBol();
        }

        return Result;
    }

    public void RandomCombination()
    {
        for (int i = 0; i < ObjBollen.Length; i++)
        {
            ObjBollen[i].GetComponent<Bol>().ChangeColor(Colors[Random.Range(0, Colors.Length)]);
        }
    }

    public bool CompleteTier()
    {
        bool Result = true;
        for (int i = 0; i < ObjBollen.Length; i++)
        {
            if (ObjBollen[i].GetComponent<Bol>().ColorBol().color == defaultColor.color)
            {
                return false;
            }
        }
        return Result;
    }

    public void ChangeBol(Material cardColor, int BolCounter)
    {
        int counter = BolCounter;
        ObjBollen[counter].GetComponent<Bol>().ChangeColor(cardColor);
    }
}
