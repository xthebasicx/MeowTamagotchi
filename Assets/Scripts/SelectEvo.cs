using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEvo : MonoBehaviour
{
    public void Evo1()
    {
        PlayerPrefs.SetInt("Evo", 1);
    }
    public void Evo2()
    {
        PlayerPrefs.SetInt("Evo", 2);
    }
}
