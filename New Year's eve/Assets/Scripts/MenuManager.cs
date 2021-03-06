using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("Scenes/CutScene");
    }
    public void OnStoreButton()
    {
        SceneManager.LoadScene("Scenes/Store");
    }
    public void OnExitButton()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
