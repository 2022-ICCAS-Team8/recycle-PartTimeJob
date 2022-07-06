using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SWCManager : MonoBehaviour
{


    public int correctAnswerCount;
    public int bpTotalCount; //���ѽð� ������ �и������� �Ѿ�ö� �ڵ������� �Ѱܹޱ�
    public int TotalCount;

    public GameObject player;
    public GameObject throwObject;

    BackpackManager bm;
    string selectItem = "";
    public Text txtType;
    
    [Header("Throw ����")]
    public Button btnThrow;
    public RecyclableItem item;
    public float playTime;
    public RectTransform ThrowGroup;
    

    [Header("Result ����")]
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

    // throw ��ư onClick �� ����
    public void trashThrow()
    {
        selectItem = throwObject.transform.GetChild(0).name.ToString();
        Debug.Log(selectItem);
        //���� ���õ� ���� null�� �ƴ϶��
        //���� ���õ� �������� Ÿ�԰� ���������� Ÿ���� �´��� Ȯ��
        if (txtType.text==selectItem)
        {
            //�¾����� correctCount 1����
            correctAnswerCount += 1;
        }
        Destroy(throwObject.transform.GetChild(0).gameObject);
        //���濡�� �ش� ������ �����
        bm.ConsumeHoldingItem();
        //���õ� �Ÿ� ���
        bm.lastSelectedIndex = -1;
        //throwObject false(�Ⱥ��̵���) �ϱ� <������ ���� �� true(���̵���)>
    }

    //���ѽð� ���� or ���� ������ 0����� ����(���)
    public void calcResult()
    {
        //throwâ �÷��� ������ �Ʒ��� ������
        if (true)
        {
            ThrowGroup.anchoredPosition = Vector3.down * 1000;
        }
        txtFind.text = bpTotalCount + " / " + TotalCount;
        txtSuccess.text = correctAnswerCount + " / " + bpTotalCount;

        //�ϴ� ������
        //�� �󸶳� ������
    }

}
