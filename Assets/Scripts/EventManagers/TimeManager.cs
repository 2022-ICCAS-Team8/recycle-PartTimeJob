using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float setTime = 300.0f;
    public Text gameTime;
    int min;
    float sec;
    public GameObject player;
    int count = 0;
    bool start = false;
    public RectTransform ResultGroup;
    public RectTransform UIGroup;

    SWCManager SWC;

    // [SerializeField]
    // Text _TimerText;

    void Awake()
    {
        SWC = GameObject.Find("GameDirector").GetComponent<SWCManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
      gameTime.text = string.Format("{0:D2}:{1:D2}", 0, 0);
    }

    void Update()
    {
        
        if (start)
        {
            Timer();
        }
    }

    public void Timer(){
      if (start!=true)
      {
        start = true;
        Debug.Log("타이머 시작");
      }
      sec += Time.deltaTime;
      gameTime.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
      if((int)sec > 59){
        sec = 0;
        min++;
      }
    }

    // public void Timer(){
    //     if (start!=true)
    //     {
    //         start = true;
    //         Debug.Log("타이머 시작");
    //     }
            
    //     // 남은 시간을 감소시켜준다.
    //     setTime -= Time.deltaTime;
        
    //     if (setTime >= 60f)
    //     {
    //     	// 60으로 나눠서 생기는 몫을 분단위로 변경
    //         min = (int)setTime / 60;
    //         // 60으로 나눠서 생기는 나머지를 초단위로 설정
    //         sec = setTime % 60;
    //         // UI를 표현해준다
    //         gameTime.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    //     }

    //     // 전체시간이 60초 미만일 때
    //     if (setTime < 60f)
    //     {
    //     	// 분 단위는 필요없어지므로 초단위만 남도록 설정
    //       gameTime.text = string.Format("<color=red>{0:D2}:{1:D2}</color>", 0, (int)setTime);
    //     }
        
    //     // 남은 시간이 0보다 작아질 때
    //     if (setTime <= 0)
    //     {
    //     	// UI 텍스트를 0초로 고정시킴.
    //       gameTime.text = string.Format("<color=red>{0:D2}:{1:D2}</color>", 0, 0);
    //         if (count == 0)
    //         {
    //             PlayerTransform();
    //             Reset_Timer();
    //         }
    //         else
    //             result();
    //     }
    // }

    private void Reset_Timer()
    {
        setTime = 20;
        count += 1;
    }

    void PlayerTransform()
    {
        SWC.InitAll();
        player.transform.position = new Vector3(-3.7f, 0.5f, -27f);
    }

    void result()
    {
        SWC.calcResult();
        ResultGroup.anchoredPosition = Vector3.zero;
        UIGroup.anchoredPosition = Vector3.down * 4000;
        player.SetActive(false);
    }
}
