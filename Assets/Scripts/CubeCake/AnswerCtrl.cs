using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    //���� ��� �� ����� ������
    public GameObject[] QuestionList;
    //���� ������ ���� ����
    private int random;

    //ī�޶� ����Ʈ(��������)
    public List<Camera> CameraList = new List<Camera>();
    //��ư ����Ʈ(��������)
    public List<Button> ButtonList = new List<Button>();

    //ī�޶� ��ġ ����Ʈ(ī�޶� ��ġ ���� ���� �� �� ���)
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.475f, 0.405f, 0.23f, 0.34f), new Rect(0.475f, 0.049f, 0.23f, 0.34f), new Rect(0.71f, 0.049f, 0.23f, 0.34f), new Rect(0.71f, 0.405f, 0.23f, 0.34f)};

    //�¾��� �� �˾�
    public GameObject sign_yes;
    //Ʋ���� �� �˾�
    public GameObject[] sign_no;
    //�˾� �� �� ���� ��� ȭ��
    public GameObject black_screen;

    // Start is called before the first frame update
    void Start()
    {
        //ī�޶� ��ġ ���� ����
        for (int i = 0; i<4; i++)
        {
            int rand = Random.Range(0, RectList.Count);
            CameraList[i].rect = RectList[rand];
            RectList.RemoveAt(rand);
        }
        random = Random.Range(0, 4);
        //���� ����
        for(int i = 0; i<4; i++)
        {
            if(random == i)
            {
                QuestionList[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Btn0Clicked()
    {
        for(int i = 0; i<4; i++)
        {
            if (CameraList[i].rect == new Rect(0.475f, 0.405f, 0.23f, 0.34f))
            {
                if(i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[0].interactable = false;
                }
            }
        }
    }
    public void Btn1Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.71f, 0.405f, 0.23f, 0.34f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[1].interactable = false;
                }
            }
        }
    }
    public void Btn2Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.475f, 0.049f, 0.23f, 0.34f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[2].interactable = false;
                }
            }
        }
    }
    public void Btn3Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.71f, 0.049f, 0.23f, 0.34f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no[i].SetActive(true);
                    black_screen.SetActive(true);
                    ButtonList[3].interactable = false;
                }
            }
        }
    }

    public void Close_No()
    {
        for(int i = 0; i<4; i++)
        {
            sign_no[i].SetActive(false);
        }  
        black_screen.SetActive(false);
    }

    public void NextScene()
    {
        //�� �Ѿ�� �ڵ�
    }
}
