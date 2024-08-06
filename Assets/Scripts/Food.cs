using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Status status;
    public void Snack(){
        status.ChangeFood(1);
        status.ChangeHealth(-1);
        status.ChangeMood(1);
    }
    public void HealthyFood(){
        status.ChangeFood(2);
        status.ChangeHealth(1);
    }
    public void Medicine(){
        if(status.currentHealth<=3){
        status.ChangeHealth(1);
        status.ChangeMood(-1);
        }
    }
}
