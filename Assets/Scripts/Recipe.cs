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

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public Sprite[] sprites = new Sprite[7];

    public GameObject[] hintArrows = new GameObject[8];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupRecipe;
    public GameObject popupName;

    public GameObject coffeeShot;
    public GameObject choco_img;

    public GameObject recipeSlider;

    void Start()
    {
        ClickedRecipe = "";
        
        
    }
    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            Invoke("Correct", 1.5f);
            recipeSlider.GetComponent<Image>().fillAmount = 1f;
        }
    }
    void PanelStart()
    {
        InvokeRepeating("TimeCount", 0f, 1f);
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

        if (SceneManager.GetActiveScene().name == "HotAmericano") //�����ѾƸ޸�ī��
        {
            cnt = 3;
            if (_list[i] == hotAmericano[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //�� ����
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 4;
            if (_list[i] == iceAmericano[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 3;
            if (_list[i] == hotLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //�� ����
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 4;
            if (_list[i] == iceLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 4;
            if (_list[i] == hotVanillaLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    coffeeShot.SetActive(true); //�� ����
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 5;
            if (_list[i] == iceVanillaLatte[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.2f; //5����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 7;
            if (_list[i] == iceCafeMocha[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.1428f; //7����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 3)
                {
                    choco_img.SetActive(true); //���ڽ÷� ����
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(true); //�� ����
                    choco_img.SetActive(false);
                }
                if (i == 5)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
            cnt = 6;
            if (_list[i] == hotCafeMocha[i])
            {
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.166f; //6����
                hintArrows[0].SetActive(false);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i == 2)
                {
                    choco_img.SetActive(true); //���ڽ÷� ����
                }
                if (i == 3)
                {
                    coffeeShot.SetActive(true); //�� ����
                    choco_img.SetActive(false);
                }
                if (i == 4)
                {
                    coffeeShot.SetActive(false);
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
                    MoveLevel.wrongCount += 1;
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
