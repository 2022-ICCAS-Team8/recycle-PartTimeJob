using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SWCMainManager : MonoBehaviour
{

    public SeparateWasteCollection player2;

    public int correctAnswerCount;
    public int bpTotalCount; //���ѽð� ������ �и������� �Ѿ�ö� �ڵ������� �Ѱܹޱ�
    public int TotalCount;

    [Header("Throw ����")]
    public Button btnThrow;
    public PlayerController player;
    public RecyclableItem item;
    public float playTime;
    public RectTransform ThrowGroup;
    

    [Header("Result ����")]
    public RectTransform ResultGroup;
    public Text txtFind;
    public Text txtSuccess;
    public Text txtDailyPay;
    public Text txtClothes;

    void InitAll()
    {
        correctAnswerCount = 0;
    }

    // throw ��ư onClick �� ����
    void trashThrow()
    {
        //���� ���õ� ���� null�� �ƴ϶��
        //���� ���õ� �������� Ÿ�԰� ���������� Ÿ���� �´��� Ȯ��
        if (player2.trashtype.type.ToString() == "plastic")
        {
            //�¾����� correctCount 1����
            correctAnswerCount += 1;
        }
        //���濡�� �ش� ������ �����
        //���õ� �� null�� ����
        //throwObject false(�Ⱥ��̵���) �ϱ� <������ ���� �� true(���̵���)>
    }

    //���ѽð� ���� or ���� ������ 0����� ����(���)
    void calcResult()
    {
        //throwâ �÷��� ������ �Ʒ��� ������
        if (player2.nearObject != null)
        {
            ThrowGroup.anchoredPosition = Vector3.down * 1000;
        }
        txtFind.text = bpTotalCount + " / " + TotalCount;
        txtSuccess.text = correctAnswerCount + " / " + bpTotalCount;

        //�ϴ� ������
        //�� �󸶳� ������

        //���â ����
        ResultGroup.anchoredPosition = Vector3.zero;
    }

}
