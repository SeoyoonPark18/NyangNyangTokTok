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
    public GameObject cup;
    public Sprite[] sprites = new Sprite[7];
    public GameObject btnMachine;
    public Sprite sprite1; //Ŀ�� ��������
    public Sprite sprite2; //�����·�

    public GameObject[] hintArrows = new GameObject[8];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupRecipe;
    public GameObject popupName;

    public GameObject coffeeShot;
    public GameObject choco_img;

    private IEnumerator coroutine;
    public GameObject hint;

    public GameObject recipeSlider;
    public ParticleSystem particle; //�ſ�
    public ParticleSystem particleBasic; //�׻�
    public ParticleSystem particleHeart; //��Ʈ

    //ȿ����
    public AudioClip[] click;
    AudioSource audioSrc;
    //ȿ���� ������ �ϱ�
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }

    void Start()
    {
        ClickedRecipe = "";
        coroutine = HintActive();

    }
    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            Invoke("Correct", 1.5f);
            recipeSlider.GetComponent<Image>().fillAmount = 1f;
        }
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
        popupRecipe.SetActive(false);
    }
    void BtnReScale()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //�������
    }
    void CupReScale()
    {
        RectTransform rectTran = cup.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 310);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 310); //�������
    }
    void BtnImgChange()
    {
        btnMachine.GetComponent<Image>().sprite = sprite2; //�� ����Ϸ�
        coffeeShot.SetActive(true); //�� ����
    }
    void BtnShot()
    {
        coffeeShot.SetActive(false); 
    }

    public void RecipeClickedBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedRecipe = clickObject.GetComponentInChildren<Text>().text;
        _list.Add(ClickedRecipe);

        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1); //Ŭ���� ũ��Ŀ����
        Invoke("BtnReScale", 0.1f);

        if (SceneManager.GetActiveScene().name == "HotAmericano") //�����ѾƸ޸�ī��
        {
            cnt = 3;
            if (_list[i] == hotAmericano[i])
            {
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                //0511ȿ����
                /*
                if(i == 0 || i == 2)//0�� ��, 2�� ��
                {
                    audioSrc.PlayOneShot(click[6]);
                }
                if (i == 1)//Ŀ�Ǹӽ�
                {
                    audioSrc.PlayOneShot(click[7]);
                }*/
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                
                if (i != 2)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                }
                if (i == 3)
                {
                    Invoke("BtnShot", 0.3f);
                    //audioSrc.PlayOneShot(click[2]);
                    particle.Play(); //�ϼ���ƼŬ
                    particleHeart.Play();
                }
            }
            else
            {
                _list.RemoveAt(i);
                wrongCnt++;
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                //audioSrc.PlayOneShot(click[3]);//Ʋ�� ȿ����
                if (wrongCnt == 1)
                {
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;

                if (i != 3)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.33f; //3����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 2)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                }
                if (i == 3)
                {
                    Invoke("BtnShot", 0.3f);
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 3)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 2)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                }
                if (i == 3)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if( i == 4)
                {
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.2f; //5����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 3)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if (i == 5)
                {
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.1428f; //7����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 4 && i != 3)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 3)
                {
                    choco_img.SetActive(true); //���ڽ÷� ����
                }
                if (i == 4)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                    choco_img.SetActive(false);
                }
                if (i == 5)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if (i == 7)
                {
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
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
                if (i != cnt - 1)
                {
                    particleBasic.Play();
                }
                img.sprite = sprites[i]; //�̹��� ����
                i++;
                recipeSlider.GetComponent<Image>().fillAmount += 0.166f; //6����
                hintArrows[0].SetActive(false);
                StopCoroutine(coroutine);
                hintArrows[i].SetActive(false);
                wrongCnt = 0;
                if (i != 2 && i != 3)
                {
                    RectTransform rectTran = cup.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                    Invoke("CupReScale", 0.1f);
                }
                if (i == 2)
                {
                    choco_img.SetActive(true); //���ڽ÷� ����
                }
                if (i == 3)
                {
                    btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                    Invoke("BtnImgChange", 1.5f);
                    choco_img.SetActive(false);
                }
                if (i == 4)
                {
                    Invoke("BtnShot", 0.3f);
                }
                if (i == 6)
                {
                    particle.Play(); //�ϼ���ƼŬ
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
                    popupWrong.SetActive(true);
                    MoveLevel.wrongCount += 1;
                }
                else if (wrongCnt == 2)
                {
                    popupWrong.SetActive(true);
                    hintArrows[0].SetActive(true); //������Ʈ����
                    StartCoroutine(coroutine);
                }
                else if (wrongCnt == 3)
                {
                    popupBoss.SetActive(true);
                    hintArrows[i + 1].SetActive(true); //��Ḧ �˷���
                }
            }
        }

        //��Ʈ �ø��� �ڵ�
        GameManager.IncreaseHeart(wrongCnt);

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
