using UnityEngine;

public class Activity : MonoBehaviour
{
    public int MaxFood = 10;
    public int MaxShower = 10;
    public int MaxExercise = 10;
    public int MaxSleep = 10;
    public int MaxSix = 10;
    public int CurrentFood;
    public int CurrentShower;
    public int CurrentExercise;
    public int CurrentSleep;
    public int CurrentSix;

    private bool FoodClicked = false;
    private bool ShowerClicked = false;
    private bool ExerciseClicked = false;
    private bool SixClicked = false;

    public void FoodButton()
    {
        if (!FoodClicked)
        {
            CurrentFood++;
            FoodClicked = true;
        }
    }

    public void ShowerButton()
    {
        if (!ShowerClicked)
        {
            CurrentShower++;
            ShowerClicked = true;
        }
    }

    public void ExerciseButton()
    {
        if (!ExerciseClicked)
        {
            CurrentExercise++;
            ExerciseClicked = true;
        }
    }

    public void SixButton()
    {
        if (!SixClicked)
        {
            CurrentSix++;
            SixClicked = true;
        }
    }

    public void SleepButton()
    {
        CurrentSleep++;
        ResetDailyActivities();
    }

    private void ResetDailyActivities()
    {
        FoodClicked = false;
        ShowerClicked = false;
        ExerciseClicked = false;
        SixClicked = false;
    }
}
