using UnityEngine;
public static class InstantiateUtility
{
    public static void Spawn<T>(T gameTemplate, Vector2 position, Quaternion rotation, Transform parent) where T : MonoBehaviour
    {
        Object.Instantiate(gameTemplate, position, rotation, parent);
    }
}
