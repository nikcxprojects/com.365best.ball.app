using UnityEngine;

public static class ScoreUtility
{
    public static int CurrentScore 
    { 
        get => PlayerPrefs.GetInt("CurrentScore", 0); 
        set => PlayerPrefs.SetInt("CurrentScore", value); 
    }

    public static int BestScore
    {
        get => PlayerPrefs.GetInt("BestScore", 0);

        set
        {
            if(CurrentScore > BestScore)
            {
                PlayerPrefs.SetInt("BestScore", CurrentScore);
                PlayerPrefs.Save();
            }
        }
    }
}
