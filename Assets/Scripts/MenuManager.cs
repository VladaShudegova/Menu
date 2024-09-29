using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        //работает только в редакторе 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //остановка 
        //работает только в скомпилированном приложении 
        #elif UNITY_STANDALONE
            Application.Quit(); //выход из игры
        #endif
    }
}
