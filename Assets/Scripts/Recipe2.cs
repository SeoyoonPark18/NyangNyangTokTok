using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] basicToast = { "�Ļ�", "�佺Ʈ��" };
    public string[] chocoToast = { "�Ļ�", "�佺Ʈ��", "���ڽ÷�"};
    public string[] strawberryToast = { "�Ļ�", "�佺Ʈ��", "������", "����" };
    public string[] blueberryToast = { "�Ļ�", "�佺Ʈ��", "��纣����", "��纣��" };
    public string[] strawberryChocoToast = { "�Ļ�", "�佺Ʈ��", "���ڽ÷�", "����" };
    public string[] nyangnyangToast = { "�Ļ�", "�佺Ʈ��", "���ڽ÷�", "��纣��", "����" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite;
    public Sprite sprite2;

    public GameObject[] hintArrows = new GameObject[6];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupRecipe;
    public GameObject popupName;

    void Start()
    {
        ClickedRecipe = "";
        
    }
    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            Invoke("Correct", 1.5f);
        }
    }
    void PanelStart()
    {
        InvokeRepeating("TimeCount", 1f, 1f);
        Invoke("TimeEnd", 20f);
    }
    void TimeCount()
    {
        --time;
        timeCounting.text = time.ToString();
    }
    void TimeEnd()
    {
        CancelInvoke("TimeCount");
        popupRecipe.SetActive(false);
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        if (SceneManager.GetActiveScene().name == "BasicToast") //�⺻�佺Ʈ
        {
            cnt = 2;
            if (_list[i] == basicToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                } 
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "ChocoToast") //�����佺Ʈ
        {
            cnt = 3;
            if (_list[i] == chocoToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                }
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "StrawberryToast") //�����佺Ʈ
        {
            cnt = 4;
            if (_list[i] == strawberryToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                }
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BlueberryToast") //��纣���佺Ʈ
        {
            cnt = 4;
            if (_list[i] == blueberryToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                }
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "StrawberryChocoToast") //���������佺Ʈ
        {
            cnt = 4;
            if (_list[i] == strawberryChocoToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                }
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "NyangNyangToast") //�ɳ��佺Ʈ
        {
            cnt = 5;
            if (_list[i] == nyangnyangToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                }
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
    }
    public void Show_Recipe()
    {
        popupName.SetActive(false);
        popupRecipe.SetActive(true);
        Invoke("PanelStart", 1f);
    }
    public void Help_Click()
    {
        popupHelp.SetActive(true);
        hintArrows[0].SetActive(false);
    }
    public void Correct()
    {
        popupCorrect.SetActive(true);
    }
}
