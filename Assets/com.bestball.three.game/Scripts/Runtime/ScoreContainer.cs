using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    [SerializeField] string key;
    private void OnEnable()
    {
        if (string.Equals(key, "CurrentScore"))
        {
            GetComponent<Text>().text = $"SCORE:{AppManager.CurrentGameType}";
        }
        else
        {
            GetComponent<Text>().text = $"BEST SCORE:{AppManager.CurrentGameType}";
        }
    }
}
