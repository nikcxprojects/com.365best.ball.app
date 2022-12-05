using UnityEngine;

public static class WindowExtension
{
    public static void SetLandscape(this GameObject gameObject, GameObject landscape)
    {
        var land = Object.Instantiate(landscape, gameObject.transform);

        land.transform.SetParent(gameObject.transform);
        land.transform.SetAsFirstSibling();
    }
}
