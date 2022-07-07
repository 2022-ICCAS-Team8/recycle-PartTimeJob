using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject player;

    public GameObject SignupGroup;

    public GameObject StartGroup;
    public GameObject LoginGroup;

    public GameObject BackpackWindow;
    public GameObject HintPanel;

    private void Awake()
    {
        // set frame rate up to 60 fps ASAP
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        StartPanel.SetActive(true);
        GamePanel.SetActive(false);
        player.SetActive(false);
    }

    public void GameStart()
    {
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        player.SetActive(true);
    }

    public void Login()
    {
        StartGroup.SetActive(false);
        LoginGroup.SetActive(true);
    }

    public void Signup(){
      LoginGroup.SetActive(false);
      SignupGroup.SetActive(true);
    }
    public void BackMain()
    {
        StartGroup.SetActive(true);
        LoginGroup.SetActive(false);
    }

    public void clickHint(){
        BackpackWindow.SetActive(false);
        HintPanel.SetActive(true);
    }
    
    public void closeHint(){
      HintPanel.SetActive(false);
    }
}
