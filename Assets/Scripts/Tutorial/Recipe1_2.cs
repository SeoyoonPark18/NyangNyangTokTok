using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe1_2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] iceAmericano = { "����", "��", "Ŀ�Ǹӽ�", "��" };

    public List<string> _list = new List<string>();
    int i = 0;
    int wrongCnt = 0;
    int cnt = 0;
    public Text timeCounting;
    public int time = 20;

    public Image img;
    public GameObject cup;
    public Sprite[] sprites = new Sprite[4];
    public GameObject btnMachine;
    public Sprite sprite1; //Ŀ�� ��������
    public Sprite sprite2; //�����·�

    public GameObject[] hintArrows = new GameObject[5];
    public GameObject popupCorrect;
    public GameObject popupWrong;
    public GameObject popupHelp;
    public GameObject popupBoss;
    public GameObject popupStart;
    public GameObject coffeeShot;

    //private IEnumerator coroutine;
    public GameObject hint;

    public GameObject recipeSlider;
    public ParticleSystem particle; //�ſ�
    public ParticleSystem particleBasic; //�׻�
    public ParticleSystem particleHeart; //��Ʈ

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus1;
    public GameObject focus2;
    int t_i = 0;
    //int t_cnt = 0;

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
        Invoke("StartPopup", 0.5f);
        //Invoke("BossTalk", 1f);
        audioSrc = GetComponent<AudioSource>();
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp2();
    }
    public void Interval()
    {
        Invoke("BossTalk", 0.8f);
    }
    public void BossTalk()
    {
        if (t_i == 0)
        {
            CancelInvoke("TimeCount");
            CancelInvoke("TimeEnd");
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "���ݺ��� �ֹ����� �޴��� ����� �� ���ʿ���. ���� '���̽� �Ƹ޸�ī��'���� ����� �ּ���!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 1)
        {
            StopMethod();
            m_text = "���� �ܿ� ������ ������� ��Ḧ �����ؾ� �ſ�!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 2)
        {
            StopMethod();
            m_text = "����� �� ���� ���� �� ������ ���� ��ư�� ���� �����Ǹ� �ٽ� �� �� �ִ�ϴ�~";
            StartMethod();
            t_i++;
        }
        else if (t_i == 3)
        {
            StopMethod();
            m_text = "�켱 ù ��° ����� '����'���� Ŭ���� �ſ� ����ּ���~";
            StartMethod();
            t_i++;
        }
        else if( t_i == 4)
        {
            StopMethod();
            m_text = "";
            StartMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            t_i++;
        }
        else if (t_i == 5)
        {
            t_i++;
            StopMethod();
            m_text = "���� ���� ���鵵 ������� Ŭ�����ּ���!";
            StartMethod();
            bossPanel.SetActive(true);
            boss.SetActive(true);
        }
        else if (t_i == 6)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
        }

    }


    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator coroutine;
    void StartMethod()
    {
        coroutine = _typing();
        StartCoroutine(coroutine);
    }
    void StopMethod()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private void Update()
    {
        if (i != 0 && i == cnt)
        {
            Invoke("Correct", 1.0f);
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
       
        //popupRecipe.SetActive(false);
        popupStart.GetComponent<Animator>().SetTrigger("sclose");
        Invoke("BossTalk", 0.8f);
        //BossTalk();
        //t_i++;
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

        cnt = 4;
        if (_list[i] == iceAmericano[i])
        {
            img.sprite = sprites[i]; //�̹��� ����
            if (i == 0)//����
            {
                audioSrc.PlayOneShot(click[5]);
            }
            if (i == 1)//��
            {
                audioSrc.PlayOneShot(click[6]);
            }
            if (i == 2)//Ŀ�Ǹӽ�
            {
                audioSrc.PlayOneShot(click[7]);
            }
            if (i == 3)//��
            {
                audioSrc.PlayOneShot(click[10]);
            }
            i++;
            recipeSlider.GetComponent<Image>().fillAmount += 0.25f; //4����
            hintArrows[0].SetActive(false);
            StopCoroutine(coroutine);
            hintArrows[i].SetActive(false);
            wrongCnt = 0;

            if (i == 1)
            {
                Invoke("BossTalk", 1.0f);
            }
            if (i != 3)
            {
                if (i != 4)
                {
                    particleBasic.Play();
                }
                RectTransform rectTran = cup.GetComponent<RectTransform>();
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350); //�� Ŀ����
                Invoke("CupReScale", 0.1f);
            }
            if (i == 3)
            {
                btnMachine.GetComponent<Image>().sprite = sprite1; //Ŀ���� �ӽ�����
                Invoke("BtnImgChange", 0.8f);
            }
            if (i == 4)
            {
                Invoke("BtnShot", 0.3f);
                particle.Play(); //�ϼ���ƼŬ
                Invoke("CorrectSound", 1f);//1�� �� ���� ȿ����
                particleHeart.Play();
            }
        }
        else
        {
            _list.RemoveAt(i);
            wrongCnt++;
            audioSrc.PlayOneShot(click[3]);//���� ȿ����
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

        /*
         if (SceneManager.GetActiveScene().name == "T_IceAmericano") //���̽��Ƹ޸�ī��
         {
             cnt = 4;

             if (_list[i] == iceAmericano[i])
             {
                 img.sprite = sprites[i]; //�̹��� ����
                 i++;
                 hintArrows[i].SetActive(false);
                 wrongCnt = 0;

                 if (i == 1)
                 {
                     Invoke("BossTalk", 1.0f);
                 }

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
         */
    }
    public void Show_Name()
    {
        //popupName.SetActive(true);
    }
    public void Show_Recipe()
    {
        //popupName.SetActive(false);
        //popupRecipe.SetActive(true);
        //bossPanel.SetActive(true);
        //m_text = "���̽� �Ƹ޸�ī�븦 ����� �����ǿ���! �����Ǹ� ������� 20�� ���� �ܿ��ּ���~";
        //StartMethod();
        //t_i++;
        Invoke("PanelStart", 1f);

    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        audioSrc.PlayOneShot(click[0]);
        pop.PopUp();
        hintArrows[0].SetActive(false);

        focus2.SetActive(false);
        boss.SetActive(false);
        bossPanel.SetActive(false);
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
    }
    public void CorrectSound()
    {
        audioSrc.PlayOneShot(click[2]);//���� ȿ����
    }

    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_3CubeCakeScene1");
    }
}
