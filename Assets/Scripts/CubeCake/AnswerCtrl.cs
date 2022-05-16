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

    //ī�޶� ��ġ ����Ʈ(ī�޶� ��ġ ���� ���� �� �� ��� / �������� ��)
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.475f, 0.434f, 0.23f, 0.363f), new Rect(0.475f, 0.052f, 0.23f, 0.363f), new Rect(0.71f, 0.052f, 0.23f, 0.363f), new Rect(0.71f, 0.434f, 0.23f, 0.363f)};

    //�¾��� �� �˾�
    public GameObject sign_yes;
    //Ʋ���� �� �˾�
    public GameObject[] sign_no;
    //���� �˾� �� �� ���� ��� ȭ��
    //public GameObject black_screen;
    //���� �˾� �� �� ���� ��� ȭ��
    //public GameObject black_screen_no;

    //�˾� ��ġ
    public string[] position = { "����", "��", "��", "����" };
    //�˾� ��ġ �ؽ�Ʈ
    public Text position_text;

    //ť�� Ʋ�� �� 
    public static int cube_wrong;

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
                position_text.text = position[i];
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
            if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.23f, 0.363f))
            {
                if(i == random)
                {
                    //sign_yes.SetActive(true);
                    //black_screen.SetActive(true);
                    Popup pop = sign_yes.GetComponent<Popup>();
                    pop.PopUp();
                    //��Ʈ �ø��� �ڵ�
                    GameManager.IncreaseHeart(cube_wrong);
                }
                else
                {
                    Popup pop = sign_no[i].GetComponent<Popup>();
                    pop.PopUp();
                    //sign_no[i].SetActive(true);
                    MoveLevel.wrongCount += 1;
                    //black_screen_no.SetActive(true);
                    ButtonList[0].interactable = false;
                    cube_wrong += 1;
                }
            }
        }
    }
    public void Btn1Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.71f, 0.434f, 0.23f, 0.363f))
            {
                if (i == random)
                {
                    Popup pop = sign_yes.GetComponent<Popup>();
                    pop.PopUp();
                    //sign_yes.SetActive(true);
                    //black_screen.SetActive(true);
                    //��Ʈ �ø��� �ڵ�
                    GameManager.IncreaseHeart(cube_wrong);
                }
                else
                {
                    Popup pop = sign_no[i].GetComponent<Popup>();
                    pop.PopUp();
                    //sign_no[i].SetActive(true);
                    MoveLevel.wrongCount += 1;
                    //black_screen_no.SetActive(true);
                    ButtonList[1].interactable = false;
                    cube_wrong += 1;
                }
            }
        }
    }
    public void Btn2Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.475f, 0.052f, 0.23f, 0.363f))
            {
                if (i == random)
                {
                    Popup pop = sign_yes.GetComponent<Popup>();
                    pop.PopUp();
                    //sign_yes.SetActive(true);
                    //black_screen.SetActive(true);
                    //��Ʈ �ø��� �ڵ�
                    GameManager.IncreaseHeart(cube_wrong);
                }
                else
                {
                    Popup pop = sign_no[i].GetComponent<Popup>();
                    pop.PopUp();
                    //sign_no[i].SetActive(true);
                    MoveLevel.wrongCount += 1;
                    //black_screen_no.SetActive(true);
                    ButtonList[2].interactable = false;
                    cube_wrong += 1;
                }
            }
        }
    }
    public void Btn3Clicked()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CameraList[i].rect == new Rect(0.71f, 0.052f, 0.23f, 0.363f))
            {
                if (i == random)
                {
                    Popup pop = sign_yes.GetComponent<Popup>();
                    pop.PopUp();
                    //sign_yes.SetActive(true);
                    //black_screen.SetActive(true);
                    //��Ʈ �ø��� �ڵ�
                    GameManager.IncreaseHeart(cube_wrong);
                }
                else
                {
                    Popup pop = sign_no[i].GetComponent<Popup>();
                    pop.PopUp();
                    //sign_no[i].SetActive(true);
                    MoveLevel.wrongCount += 1;
                    //black_screen_no.SetActive(true);
                    ButtonList[3].interactable = false;
                    cube_wrong += 1;
                }
            }
        }
    }

    /*
    public void Close_No()
    {
        for(int i = 0; i<4; i++)
        {
            sign_no[i].SetActive(false);
        }  
        black_screen_no.SetActive(false);
    }
    */
    
}
