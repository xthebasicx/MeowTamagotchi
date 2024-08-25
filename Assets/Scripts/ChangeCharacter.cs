using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private Animator animator;
    private int SelectCat;
    private int SelectEvo;
    public List<AnimatorControllerList> Cat;
    
    void Awake()
    {
        SelectCat = PlayerPrefs.GetInt("Cat", 0);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeCat(SelectCat,0);
    }
    void Update(){
        SelectEvo = PlayerPrefs.GetInt("Evo", 0);
        ChangeCat(SelectCat,SelectEvo);
    }

    public void ChangeCat(int listIndex, int index)
    {
        animator.runtimeAnimatorController = Cat[listIndex].Evo[index];
    }
}
[System.Serializable]
public class AnimatorControllerList
{
    public List<RuntimeAnimatorController> Evo;
}