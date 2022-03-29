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
    public string[] strawblueToast = { "�Ļ�", "�佺Ʈ��", "��纣����", "����" };
    public string[] nyangnyangToast = { "�Ļ�", "�佺Ʈ��", "������", "��纣��", "���ڽ÷�" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    //int time = 5; //���� 20��

    public Image img;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite;

    public GameObject[] hintArrows = new GameObject[6];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;

    void Start()
    {
        ClickedRecipe = "";
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        if (SceneManager.GetActiveScene().name == "BasicToast") //�⺻�佺Ʈ
        {
            if (_list[i] == basicToast[i])
            {
                if (i > 0)
                {
                    img.sprite = sprites[i - 1]; //�̹��� ����
                } 
                i++;
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    popupCorrect.SetActive(true);
                }
                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite;
                    //�Ļ��� ��迡 ��(��ư ���� ����)
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
