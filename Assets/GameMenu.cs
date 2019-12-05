using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    void Start()
    {
    }

    void onClick()
    {
        SceneManager.LoadScene("UnderSea");
    }
    public void ReturnBack()
    {
        SceneManager.LoadScene("1");
    }
    public void ARJump()
    {
        SceneManager.LoadScene("MainARScene");
    }
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}



//    public void OnStarGame()
//    {
//        SceneManager.LoadScene("s's 1");
//    }
//    public void OnExitGame()
//    {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying=false;
//#else
//        Application.Quit();
//#endif
//    }
//}
