using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
  float setTime = 60;
  public Text gameTime;
  int min;
  float sec;


  // [SerializeField]
  // Text _TimerText;

    // Start is called before the first frame update
    void Start()
    {
      gameTime.text = string.Format("{0:D2}:{1:D2}", 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
      Timer();  
	  }

    void Timer(){
       // 남은 시간을 감소시켜준다.
        setTime -= Time.deltaTime;
        
        if (setTime >= 60f)
        {
        	// 60으로 나눠서 생기는 몫을 분단위로 변경
            min = (int)setTime / 60;
            // 60으로 나눠서 생기는 나머지를 초단위로 설정
            sec = setTime % 60;
            // UI를 표현해준다
            gameTime.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
        }


        // 전체시간이 60초 미만일 때
        if (setTime < 60f)
        {
        	// 분 단위는 필요없어지므로 초단위만 남도록 설정
          gameTime.text = string.Format("<color=red>{0:D2}:{1:D2}</color>", 0, (int)setTime);
        }
        
        // 남은 시간이 0보다 작아질 때
        if (setTime <= 0)
        {
        	// UI 텍스트를 0초로 고정시킴.
          gameTime.text = string.Format("<color=red>{0:D2}:{1:D2}</color>", 0, 0);
        }
    }
}
