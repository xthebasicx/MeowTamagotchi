using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    public Status status;
    void Start()
    {
        
    }
    
    public void Shower(){
        status.ChangeHealth(1);
        status.ChangeMood(-2);
    }
    public void Exercise(){
        status.ChangeHealth(2);
        status.ChangeStamina(-1);
    }
    public void Sleep(){
        status.ChangeStamina(2);
    }
}
