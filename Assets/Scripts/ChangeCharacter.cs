using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private Animator animator;
    public List<AnimatorControllerList> Cat;
   
    void Start()
    {
        animator = GetComponent<Animator>();
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