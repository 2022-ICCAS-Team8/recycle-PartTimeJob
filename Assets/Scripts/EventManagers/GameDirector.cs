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

    public GameObject StartGroup;
    public GameObject LoginGroup;

    public Text labelCollectNum;

    int collectCount = 0;
    

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

        UpdateCollectCount();
    }

    public void Login()
    {
        StartGroup.SetActive(false);
        LoginGroup.SetActive(true);
    }

    public void BackMain()
    {
        StartGroup.SetActive(true);
        LoginGroup.SetActive(false);
    }

    public void AddCollectCount()
    {
        collectCount++;
        UpdateCollectCount();
    }

    public void UpdateCollectCount()
    {
        labelCollectNum.text = "Count of item: " + collectCount;
    }
}
