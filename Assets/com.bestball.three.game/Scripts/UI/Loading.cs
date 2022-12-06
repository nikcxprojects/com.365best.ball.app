using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] GameObject VFX;
    [SerializeField] Text statusText;

    private Button continueBtn;

    private void OnEnable()
    {
        VFX.SetActive(true);
    }

    private void Awake()
    {
        continueBtn = statusText.GetComponent<Button>();
    }

    private IEnumerator Start()
    {
        float et = 0.0f;
        float loadingTime = Random.Range(2.25f, 4.5f);

        int index = 0;
        char[] letters = "Loading..".ToCharArray();

        while(et < loadingTime)
        {
            if(index > letters.Length - 1)
            {
                index = 0;
            }

            statusText.text += letters[index];
            et += Time.deltaTime;
            yield return null;
        }

        statusText.text = "PRESS TO CONTINUE";
        continueBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Menu);
        });
    }
}
