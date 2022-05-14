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
    public GameObject plate;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite; //�� ������
    public Sprite sprite1; //�������� �߰�����
    public Sprite sprite2; //�����·�

    public GameObject[] hintArrows = new GameObject[6];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupStart;

    public GameObject recipeSlider;

    private IEnumerator coroutine;
    public GameObject hint;

    public ParticleSystem particle; //���ÿ� �ϼ���
    public ParticleSystem particleBasic; //�׻�
    public ParticleSystem particleHeart; //��Ʈ

    int updateCnt = 1;

    void Start()
    {
        ClickedRecipe = "";
        coroutine = HintActive();

        Invoke("StartPopup", 0.1f);
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp2();
    }

    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            
            Invoke("Correct", 1.0f);
            recipeSlider.GetComponent<Image>().fillAmount = 1f;
        }

        //����
        
        if (nameBtnDown)
        {
            while (updateCnt > 0)
            {
                Invoke("ShowRecipe", 1f);
                updateCnt--;
            }  
        }


    }
    //����

    bool nameBtnDown;

    public void reciPressed()
    {
        nameBtnDown = true;
    }


    IEnumerator HintActive()
    {
        while (true)
        {
            hint.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.7f);

            hint.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.7f);
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
        popupStart.GetComponent<Animator>().SetTrigger("sclose");
    }

    void BtnReScale()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //�������
    }
    void PlateReScale()
    {
        RectTransform rectTran = plate.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1250);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1250); //�׸� �������
    }
    void BtnImgChange()
    {
        btnMachine.GetComponent<Image>().sprite = sprite; //�ٱ�����
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);
        //
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1); //Ŭ���� ũ��Ŀ����
        Invoke("BtnReScale", 0.1f);


        if (SceneManager.GetActiveScene().name == "BasicToast") //�⺻�佺Ʈ
        {
            cnt = 2;
            if (_list[i] == basicToast[i])
            {
                if (i > 0)
                {
                    if(i != cnt-1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //�̹��� ����
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //�׸� Ŀ����
                    Invoke("PlateReScale", 0.1f);
                } 
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.5f; //2����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                    Invoke("BtnImgChange", 1.2f);
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                    particle.Play(); //�׸��� �ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
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
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //�̹��� ����
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //�׸� Ŀ����
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                    Invoke("BtnImgChange", 1.5f);
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 3)
                {
                    particle.Play(); //�׸��� �ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
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
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //�̹��� ����
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //�׸� Ŀ����
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                    Invoke("BtnImgChange", 1.5f);
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 4)
                {
                    particle.Play(); //�׸��� �ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
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
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //�̹��� ����
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //�׸� Ŀ����
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                    Invoke("BtnImgChange", 1.5f);
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 4)
                {
                    particle.Play(); //�׸��� �ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
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
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //�̹��� ����
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //�׸� Ŀ����
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                    Invoke("BtnImgChange", 1.5f);
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 4)
                {
                    particle.Play(); //�׸��� �ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
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
                    if (i != cnt - 1)
                    {
                        particleBasic.Play();
                    }
                    img.sprite = sprites[i - 1]; //�̹��� ����
                    RectTransform rectTran = plate.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1350); //�׸� Ŀ����
                    Invoke("PlateReScale", 0.1f);
                }
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.2f; //5����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i == 1)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                    Invoke("BtnImgChange", 1.5f);
                    //�Ļ��� ��迡 ��(��ư ���� ����)
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite2;
                }
                if (i == 5)
                {
                    particle.Play(); //�׸��� �ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                if (wrongCnt == 1)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    Popup pop = popupWrong.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    Popup pop = popupBoss.GetComponent<Popup>();
                    pop.PopUp();
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }
        //��Ʈ �ø��� �ڵ�
        GameManager.IncreaseHeart(wrongCnt);
    }
    IEnumerator AfterParticle()
    {
        yield return new WaitForSeconds(0.2f);
        img.sprite = sprites[i - 1]; //�̹��� ����
    }

    public void Show_Recipe()
    {
        Invoke("PanelStart", 1f);
    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        pop.PopUp();
        hintArrows[0].SetActive(false);
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
    }
}
