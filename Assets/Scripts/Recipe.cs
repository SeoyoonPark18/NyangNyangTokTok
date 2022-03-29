using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe : MonoBehaviour
{
    string ClickedRecipe;
    public string[] hotAmericano = { "��", "Ŀ�Ǹӽ�", "��" };
    public string[] iceAmericano = { "����", "��", "Ŀ�Ǹӽ�", "��" };
    public string[] hotLatte = { "����", "Ŀ�Ǹӽ�", "��" };
    public string[] iceLatte = { "����", "����", "Ŀ�Ǹӽ�", "��" };
    public string[] hotVanillaLatte = { "����", "Ŀ�Ǹӽ�", "��", "�ٴҶ�÷�" };
    public string[] iceVanillaLatte = { "����", "����", "Ŀ�Ǹӽ�", "��", "�ٴҶ�÷�" };
    public string[] hotCafeMocha = { "����", "���ڽ÷�", "Ŀ�Ǹӽ�", "��", "����", "���ڽ÷�" };
    public string[] iceCafeMocha = { "����", "����", "���ڽ÷�", "Ŀ�Ǹӽ�", "��", "����", "���ڽ÷�" };
    //�ٸ��޴��� �߰�

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    //int time = 5; //���� 20��

    public Image img;
    public Sprite[] sprites = new Sprite[7];

    public GameObject[] hintArrows = new GameObject[8];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject coffeeShot;

    void Start()
    {
        ClickedRecipe = ""; 
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        if (SceneManager.GetActiveScene().name == "HotAmericano") //�����ѾƸ޸�ī��
        {
            if (_list[i] == hotAmericano[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "IceAmericano") //���̽��Ƹ޸�ī��
        {
            if (_list[i] == iceAmericano[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 4)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "HotLatte") //�����Ѷ�
        {
            if (_list[i] == hotLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "IceLatte") //���̽���
        {
            if (_list[i] == iceLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 4)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "HotVanillaLatte") //�����ѹٴҶ��
        {
            if (_list[i] == hotVanillaLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 4)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "IceVanillaLatte") //���̽��ٴҶ��
        {
            if (_list[i] == iceVanillaLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 5)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "IceCafeMocha") //���̽�ī���ī
        {
            if (_list[i] == iceCafeMocha[i]) 
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 7)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(true); //�� ����
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
        if (SceneManager.GetActiveScene().name == "HotCafeMocha") //������ī���ī
        {
            if (_list[i] == hotCafeMocha[i]) 
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 6)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
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
    public void Help_Click()
    {
        popupHelp.SetActive(true);
        hintArrows[0].SetActive(false);
    }
}
