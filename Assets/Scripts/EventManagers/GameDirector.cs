using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public List<GameObject> DontDestroyObjects;

    private void Awake()
    {
        // set frame rate up to 60 fps ASAP
        Application.targetFrameRate = 60;

        for (int i=0; i < DontDestroyObjects.Count; i++)
        {
            DontDestroyOnLoad(DontDestroyObjects[i]);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
