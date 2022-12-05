using UnityEngine;

public static class LandscapeUtility
{
    public static GameObject GetLandscape(string gameType)
    {
        return Resources.Load<GameObject>($"Landscapes{gameType}");
    }
}
