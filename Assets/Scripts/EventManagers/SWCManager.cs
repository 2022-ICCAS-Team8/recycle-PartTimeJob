using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SWCManager : MonoBehaviour
{


    public int correctAnswerCount;
    public int bpTotalCount; //제한시간 지나서 분리수거장 넘어올때 자동적으로 넘겨받기
    public int TotalCount;

    public GameObject player;
    public GameObject throwObject;

    BackpackManager bm;
    string selectItem = "";
    public Text txtType;
    
    [Header("Throw 로직")]
    public Button btnThrow;
    public RecyclableItem item;
    public float playTime;
    public RectTransform ThrowGroup;
    

    [Header("Result 로직")]
    public RectTransform ResultGroup;
    public Text txtFind;
    public Text txtSuccess;
    public Text txtDailyPay;
    public Text txtClothes;

    void Awake()
    {
        bm = GameObject.Find("GameDirector").GetComponent<BackpackManager>();
    }

    public void InitAll()
    {
        correctAnswerCount = 0;
        bpTotalCount = bm.Items.Count;
        TotalCount = 10;
    }

    // throw 버튼 onClick 시 실행
    public void trashThrow()
    {
        selectItem = throwObject.transform.GetChild(0).name.ToString();
        Debug.Log(selectItem);
        //현재 선택된 것이 null이 아니라면
        //현재 선택된 아이템의 타입과 쓰레기통의 타입이 맞는지 확인
        if (txtType.text==selectItem)
        {
            //맞았으면 correctCount 1증가
            correctAnswerCount += 1;
        }
        Destroy(throwObject.transform.GetChild(0).gameObject);
        //가방에서 해당 아이템 지우기
        bm.ConsumeHoldingItem();
        //선택된 거를 취소
        bm.lastSelectedIndex = -1;
        //throwObject false(안보이도록) 하기 <아이템 선택 시 true(보이도록)>
    }

    //제한시간 종료 or 가방 아이템 0개라면 실행(결과)
    public void calcResult()
    {
        //throw창 올려져 있으면 아래로 내리기
        if (true)
        {
            ThrowGroup.anchoredPosition = Vector3.down * 1000;
        }
        txtFind.text = bpTotalCount + " / " + TotalCount;
        txtSuccess.text = correctAnswerCount + " / " + bpTotalCount;

        //일당 얼마줄지
        //옷 얼마나 만들지
    }

}
