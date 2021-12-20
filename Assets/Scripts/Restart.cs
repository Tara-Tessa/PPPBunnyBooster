using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Difficulty difficulty;

    public void Restart_()
    {
        //nu doe ik niets meer
    }

    public void Leave()
    {
        Application.Quit();
        print("Leaving...");
    }
}
