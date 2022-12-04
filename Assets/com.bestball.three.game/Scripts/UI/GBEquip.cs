using UnityEngine.UI;
using UnityEngine;

public class GBEquip : MonoBehaviour
{
    [SerializeField] Button backBtn;

    private void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
