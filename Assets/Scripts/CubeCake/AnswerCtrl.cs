using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    //���� ��� �� ����� ������
    public Text question;
    //���� ������ ���� ����
    private int random;

    //ī�޶� ����Ʈ(��������)
    public List<Camera> CameraList = new List<Camera>();
    //��ư ����Ʈ(��������)
    public List<Button> ButtonList = new List<Button>();
    //Ʋ���� �� �������� ȸ�� �̹��� ����Ʈ(��������)
    public List<Image> NoneList = new List<Image>();

    //ī�޶� ��ġ ����Ʈ(ī�޶� ��ġ ���� ���� �� �� ���)
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.5f, 0.5f, 0.25f, 0.5f), new Rect(0.5f, 0, 0.25f, 0.5f), new Rect(0.75f, 0, 0.25f, 0.5f), new Rect(0.75f, 0.5f, 0.25f, 0.5f)};

    //�¾��� �� �˾�
    public GameObject sign_yes;
    //Ʋ���� �� �˾�
    public GameObject sign_no;
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
        RandAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���� ����( �� ��ư �� ȸ�� �̹��� ����)
    public void RandAnswer()
    {
        if(random == 0)
        {
            question.text = "�����ʿ��� �� ����� ������.";
        }else if(random == 1)
        {
            question.text = "���ʿ��� �� ����� ������.";
        }
        else if (random == 2)
        {
            question.text = "���ʿ��� �� ����� ������.";
        }
        else if (random == 3)
        {
            question.text = "���ʿ��� �� ����� ������.";
        }
    }

    public void Btn0Clicked()
    {
        for(int i = 0; i<4; i++)
        {
            if (CameraList[i].rect == new Rect(0.5f, 0.5f, 0.25f, 0.5f))
            {
                if(i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }
    public void Btn1Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.75f, 0.5f, 0.25f, 0.5f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }
    public void Btn2Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.5f, 0, 0.25f, 0.5f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }
    public void Btn3Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.75f, 0, 0.25f, 0.5f))
            {
                if (i == random)
                {
                    sign_yes.SetActive(true);
                    black_screen.SetActive(true);
                }
                else
                {
                    sign_no.SetActive(true);
                    black_screen.SetActive(true);
                }
            }
        }
    }

    public void Close_No()
    {
        sign_no.SetActive(false);
        black_screen.SetActive(false);
    }

    public void NextScene()
    {
        //�� �Ѿ�� �ڵ�
    }
}
