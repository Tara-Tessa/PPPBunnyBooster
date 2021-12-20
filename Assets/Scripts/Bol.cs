using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bol : MonoBehaviour
{
    public Material defaultColor;
    Mesh defaultMesh;
    public bool isRightTier;
    public Tier tier;

    void Awake()
    {
        defaultMesh = GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = new Mesh();
        GetComponent<MeshRenderer>().material = defaultColor;
    }

    public Material ColorBol()
    {
        return GetComponent<MeshRenderer>().material;
    }

    public void ChangeColor(Material NewColor)
    {
        if (!isRightTier && !tier.IsActive) 
        {
            WatchInactiveTier(); 
            return;
        }

        GetComponent<MeshFilter>().mesh = defaultMesh;
        GetComponent<MeshRenderer>().material = NewColor;
        FindObjectOfType<AudioManager>().Play("Plop");
        if (isRightTier)
        {
            GetComponentInParent<Bollen>().GetComponentInParent<DoelTier>().UpdateCombination();
        } else
        {
            GetComponentInParent<Bollen>().GetComponentInParent<Tier>().UpdateCombination();
        }
    }

    public void WatchInactiveTier()
    {
        print("This tier is inactive");
    }
}
