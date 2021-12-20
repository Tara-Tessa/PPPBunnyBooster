using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Solutions : MonoBehaviour
{

    public bool Easy;
    public GameObject[] SolutionsObj;
    public Material wit;
    public Material zwart;
    public Material defaultColor;
    public bool Solved;
    public DoelTier doelTier;
    public Mesh MeshInitial;
    public ControlTiers controlTiers;
    public Difficulty difficulty;
    public GameObject gewonnen;

    public void Awake()
    {
        MeshInitial = GetComponentInChildren<MeshFilter>().mesh;

        for (int i = 0; i < SolutionsObj.Length; i++)
        {
            SolutionsObj[i].GetComponent<MeshFilter>().mesh = new Mesh();
        }
    }

    public void PlaceSolution()
    {
        Debug.Log("In solution handler in de if");
        if (Solved)
        {
            MessageTierSolved();
            return;
        }
        Tier tier = GetComponentInParent<Tier>();
        if (!tier.LineComplete)
        {
            MessageTierIncomplete();
            return;
        }
        if (!doelTier.LineComplete)
        {
            MessageDoelTierIncomplete();
            return;
        }

        FindObjectOfType<AudioManager>().Play("Check");
        Material[] solutions = new Material[4];
        solutions = Calculator();

        if (!difficulty.easy)
        {
            solutions = StrangeSolutions(solutions);
        }

        for (int i = 0; i < SolutionsObj.Length; i++)
        {
            SolutionsObj[i].GetComponent<MeshRenderer>().material = solutions[i];

            if (solutions[i] != defaultColor)
            {
                SolutionsObj[i].GetComponent<MeshFilter>().mesh=MeshInitial;
            }

        }

        MessageSolutionCorrect();
        Debug.Log(controlTiers.numActiveTier+1);
        controlTiers.ActivateTier(controlTiers.numActiveTier+1);

        Solved = true;


    }

    public Material[] Calculator()
    {
        Material[] Result = new Material[4];
        Tier tier = GetComponentInParent<Tier>();
        bool exists = false;

        for (int x = 0; x < tier.RightCombination.Length; x++)
        {
            exists = false;
            for (int i= 0; i < tier.RightCombination.Length; i++) {
                if (tier.RightCombination[x].color == doelTier.RightCombination[i].color)
            {
                    exists = true;

                if (i == x)
                {
                    Result[x] = wit;
                    break;
                } else
                {
                    if (Result[x] != wit) {
                            Result[x] = zwart;
                    }
                }
            }
            if (!exists)
            {
                Result[x] = defaultColor;
            } 
        }
    }

    if (Won(Result)) {
            MessageWon();
}


        return Result;
    }

    public bool Won(Material[] solutions)
{
    bool Result=true;

    for (int i=0; i < solutions.Length; i++)
    {
        if (solutions[i] != wit)
        {
            return false;
        }
    }

    return Result;
}


    Material[] StrangeSolutions(Material[] materials)
    {
        for (int i = 0; i < materials.Length; i++)
        {
            Material temp = materials[i];
            int RandomIndex = Random.Range(i, materials.Length);
            materials[i] = materials[RandomIndex];
            materials[RandomIndex] = temp;
        }
        return materials;
    }


    public void MessageTierSolved()
    {
        print("This tier is solved");
    }

    public void MessageTierIncomplete()
    {
        print("This tier is not complete");
    }

    public void MessageDoelTierIncomplete()
    {
        print("This doeltier is not complete");
    }

    public void MessageSolutionCorrect ()
    {
        print("Right solution!");
    }

    public void MessageWon()
    {
    print("You won!");
        gewonnen.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}


