using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _winnerPanel, _loserPanel;

    private static MenuManager _instance = null;
    public static MenuManager Instance
    {
        get 
        {
            if(_instance == null)
            {
                var manager = new GameObject("Menu");
                manager.AddComponent<MenuManager>();
            }
            return _instance;
        }
    }


    private void OnEnable(){
        EventBusMenu.onLoadWinnerPanel += ActivatePanel;
        EventBusMenu.onLoadLoserPanel += ActivatePanel;
        EventBusMenu.onLoadWinnerPanel += DeactivatePanel;
        EventBusMenu.onLoadLoserPanel += DeactivatePanel;
    }


    private void OnDisable() {
         EventBusMenu.onLoadWinnerPanel -= ActivatePanel;
         EventBusMenu.onLoadLoserPanel += ActivatePanel;
         EventBusMenu.onLoadWinnerPanel -= DeactivatePanel;
        EventBusMenu.onLoadLoserPanel -= DeactivatePanel;
    }


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

    public void ActivatePanel(string name)
    {
        _winnerPanel.SetActive(true);
    }

    public void DeactivatePanel(string name)
    {
        _winnerPanel.SetActive(false);
    }
}
