using UnityEngine;
using TMPro; 

public class TextDisappear : MonoBehaviour
{
    [Header("targeting_text")]
    public GameObject targetText; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            HideText();
        }
    }

    void HideText()
    {
        if (targetText != null)
        {
            targetText.SetActive(false);
            
            Debug.Log("text gone");
        }
    }
}