using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    
    float scaleheight = ((float)Screen.width / Screen.height) / ((float)18.5 / 9);
    //float scalewidth = 1f / scaleheight;

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
        new Rect(0.475f, 0.434f, 0.23f, 0.363f), new Rect(0.475f, 0.052f, 0.23f, 0.363f), new Rect(0.71f, 0.052f, 0.23f, 0.363f), new Rect(0.71f, 0.434f, 0.23f, 0.363f)}; //����
    public List<Rect> RectList2 = new List<Rect>() {
        new Rect(0.475f, 0.434f, 0.2f, 0.363f), new Rect(0.475f, 0.052f, 0.2f, 0.363f), new Rect(0.68f, 0.052f, 0.2f, 0.363f), new Rect(0.68f, 0.434f, 0.2f, 0.363f)}; //���� ��
    public List<Rect> RectList3 = new List<Rect>() {
        new Rect(0.475f, 0.434f, 0.23f, 0.363f), new Rect(0.475f, 0.11f, 0.23f, 0.363f), new Rect(0.71f, 0.11f, 0.23f, 0.363f), new Rect(0.71f, 0.434f, 0.23f, 0.363f)}; //���� ��


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

    //ȿ����
    public AudioClip[] click;
    AudioSource audioSrc;

    //ȿ���� ������ �ϱ�
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (scaleheight < 1) //���� ����
        {
            //ī�޶� ��ġ ���� ����
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, RectList3.Count);
                CameraList[i].rect = RectList3[rand];
                RectList3.RemoveAt(rand);
            }
            random = Random.Range(0, 4);
            //���� ����
            for (int i = 0; i < 4; i++)
            {
                if (random == i)
                {
                    QuestionList[i].SetActive(true);
                    position_text.text = position[i];
                }
            }
        }
        else if (scaleheight > 1)//���� ����
        {
            //ī�޶� ��ġ ���� ����
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, RectList2.Count);
                CameraList[i].rect = RectList2[rand];
                RectList2.RemoveAt(rand);
            }
            random = Random.Range(0, 4);
            //���� ����
            for (int i = 0; i < 4; i++)
            {
                if (random == i)
                {
                    QuestionList[i].SetActive(true);
                    position_text.text = position[i];
                }
            }
        }
        else if (scaleheight == 1)//����
        {
            //ī�޶� ��ġ ���� ����
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, RectList.Count);
                CameraList[i].rect = RectList[rand];
                RectList.RemoveAt(rand);
            }
            random = Random.Range(0, 4);
            //���� ����
            for (int i = 0; i < 4; i++)
            {
                if (random == i)
                {
                    QuestionList[i].SetActive(true);
                    position_text.text = position[i];
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Btn0Clicked()
    {
        if (scaleheight < 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[0].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if(scaleheight > 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[0].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if(scaleheight == 1) //����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[0].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }

        
    }
    public void Btn1Clicked()
    {
        if (scaleheight < 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[1].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight > 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.68f, 0.434f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[1].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight == 1) //����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.434f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[1].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }

        
    }
    public void Btn2Clicked()
    {
        if (scaleheight < 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.11f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[2].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight > 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.052f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[2].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight == 1) //����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.475f, 0.052f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[2].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }


        
    }
    public void Btn3Clicked()
    {
        if (scaleheight < 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.11f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[3].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight > 1) //���� ����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.68f, 0.052f, 0.2f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[3].interactable = false;
                        cube_wrong += 1;
                    }
                }
            }
        }
        else if (scaleheight == 1) //����
        {
            for (int i = 0; i < 4; i++)
            {
                if (CameraList[i].rect == new Rect(0.71f, 0.052f, 0.23f, 0.363f))
                {
                    if (i == random)
                    {
                        Popup pop = sign_yes.GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[0]);
                        //sign_yes.SetActive(true);
                        //black_screen.SetActive(true);
                        //��Ʈ �ø��� �ڵ�
                        GameManager.IncreaseHeart(cube_wrong);
                    }
                    else
                    {
                        Popup pop = sign_no[i].GetComponent<Popup>();
                        pop.PopUp();
                        audioSrc.PlayOneShot(click[1]);
                        //sign_no[i].SetActive(true);
                        MoveLevel.wrongCount += 1;
                        //black_screen_no.SetActive(true);
                        ButtonList[3].interactable = false;
                        cube_wrong += 1;
                    }
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
