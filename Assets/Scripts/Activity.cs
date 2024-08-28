using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Activity : MonoBehaviour
{
    public Status status;
    public SceneTransition sceneTransition;
    private Animator playerAnimator;
    private AudioManager audioManager;
    public void Start(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Snack()
    {
        playerAnimator.SetTrigger("Eat");
        status.ChangeFood(1);
        status.ChangeHealth(-1);
        status.ChangeMood(1);
        audioManager.PlayVoice(audioManager.eat);
    }
    public void HealthyFood()
    {
        playerAnimator.SetTrigger("Eat");
        status.ChangeFood(2);
        status.ChangeHealth(1);
        audioManager.PlayVoice(audioManager.eat);
    }
    public void Medicine()
    {
        if (status.currentHealth <= 3)
        {
            playerAnimator.SetTrigger("Eat");
            status.ChangeHealth(1);
            status.ChangeMood(-1);
            audioManager.PlayVoice(audioManager.eat);
        }
    }
    public void Shower()
    {
        playerAnimator.SetTrigger("Shower");
        status.ChangeMood(-2);
        status.ChangeShower(2);
    }
    public void Exercise()
    {
        if (status.currentStamina > 0)
        {
            playerAnimator.SetTrigger("Exercise");
            status.ChangeHealth(2);
            status.ChangeShower(-1);
            status.ChangeFood(-1);
            status.ChangeStamina(-1);
        }    }
    public void MiniGame()
    {
        if (status.currentStamina > 0)
        {
            status.ChangeMood(3);
            status.ChangeFood(-2);
            status.ChangeStamina(-1);
            status.SaveStatus();
            StartCoroutine(sceneTransition.TransitionEnd("Minigame Scene"));
        }
    }
    public void Sleep()
    {
        playerAnimator.SetTrigger("Sleep");
        status.ChangeStamina(2);
        status.ChangeDay(1);
        RandomStatus();
        audioManager.PlayVoice(audioManager.sleep);
    }
    private void RandomStatus(){

        int healthChange = Random.Range(-1, 1);
        int showerChange = Random.Range(-1, 1);
        int foodChange = Random.Range(-1, 1);
        int moodChange = Random.Range(-1, 1);

        int randomStatus = Random.Range(0, 4);

        switch (randomStatus)
        {
            case 0:
                healthChange = -2;
                break;
            case 1:
                showerChange = -2;
                break;
            case 2:
                foodChange = -2;
                break;
            case 3:
                moodChange = -2;
                break;
        }

        status.ChangeHealth(healthChange);
        status.ChangeShower(showerChange);
        status.ChangeFood(foodChange);
        status.ChangeMood(moodChange);
    }
}