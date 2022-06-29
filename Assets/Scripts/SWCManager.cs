using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SWCMainManager : MonoBehaviour
{

    public SeparateWasteCollection player2;

    public int correctAnswerCount;
    public int bpTotalCount; //제한시간 지나서 분리수거장 넘어올때 자동적으로 넘겨받기
    public int TotalCount;

    [Header("Throw 로직")]
    public Button btnThrow;
    public PlayerController player;
    public RecyclableItem item;
    public float playTime;
    public RectTransform ThrowGroup;
    

    [Header("Result 로직")]
    public RectTransform ResultGroup;
    public Text txtFind;
    public Text txtSuccess;
    public Text txtDailyPay;
    public Text txtClothes;

    void InitAll()
    {
        correctAnswerCount = 0;
    }

    // throw 버튼 onClick 시 실행
    void trashThrow()
    {
        //현재 선택된 것이 null이 아니라면
        //현재 선택된 아이템의 타입과 쓰레기통의 타입이 맞는지 확인
        if (player2.trashtype.type.ToString() == "plastic")
        {
            //맞았으면 correctCount 1증가
            correctAnswerCount += 1;
        }
        //가방에서 해당 아이템 지우기
        //선택된 거 null로 변경
        //throwObject false(안보이도록) 하기 <아이템 선택 시 true(보이도록)>
    }

    //제한시간 종료 or 가방 아이템 0개라면 실행(결과)
    void calcResult()
    {
        //throw창 올려져 있으면 아래로 내리기
        if (player2.nearObject != null)
        {
            ThrowGroup.anchoredPosition = Vector3.down * 1000;
        }
        txtFind.text = bpTotalCount + " / " + TotalCount;
        txtSuccess.text = correctAnswerCount + " / " + bpTotalCount;

        //일당 얼마줄지
        //옷 얼마나 만들지

        //결과창 띄우기
        ResultGroup.anchoredPosition = Vector3.zero;
    }

}
