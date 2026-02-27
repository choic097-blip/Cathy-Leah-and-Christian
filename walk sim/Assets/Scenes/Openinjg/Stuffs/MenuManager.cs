using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필수
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject aboutPanel;

    public void ClickStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ClickAbout()
    {
        if (aboutPanel != null)
        {
            aboutPanel.SetActive(true);
        }
    }

    public void CloseAbout()
    {
        if (aboutPanel != null)
        {
            aboutPanel.SetActive(false);
        }
    }

    public void ClickQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
        Debug.Log("게임이 종료되었습니다.");
    }
}