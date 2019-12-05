using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnded : MonoBehaviour
{
    public GameObject endUI;
    public GameObject end;
    public Text message;
    public bool check = false;
    private void Start()
    {
        endUI.SetActive(false);
        message.enabled = false;
        end.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            endUI.SetActive(true);
            message.enabled = true;
            end.SetActive(true);
            check = true;
        }
        if (check == true)
        {
            if (Input.GetKey(KeyCode.N))
            {
                no();
                check = false;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                yes();
            }
        }
    }
    public void no()
    {
        endUI.SetActive(false);
        message.enabled = false;
        end.SetActive(false);
    }
    public void backMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void yes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}

