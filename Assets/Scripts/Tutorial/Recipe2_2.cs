using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Recipe2_2 : MonoBehaviour
{
    string ClickedRecipe;
    public string[] basicToast = { "�Ļ�", "�佺Ʈ��" };

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
    
    public GameObject hint;

    public ParticleSystem particle; //���ÿ� �ϼ���
    public ParticleSystem particleBasic; //�׻�
    public ParticleSystem particleHeart; //��Ʈ

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    int t_i = 0;

    public AudioClip[] click;
    AudioSource audioSrc;
    //ȿ���� ������ �ϱ�
    public void ClickSound(int x)
    {
        audioSrc.PlayOneShot(click[x]);
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ClickedRecipe = "";
        //Invoke("StartPopup", 0.5f);
        Invoke("BossTalk", 1f);
        //Invoke("BossShowUp", 1f);
    }
    void BossShowUp()
    {
        boss.SetActive(true);
        Invoke("BossTalk", 1f);
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
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "�����ؿ�! ���� �����Ⱓ�� ���� �������� ���˹ٻ����� �Ǿ����~";
            StartMethod();
            t_i++;
        }
        else if (t_i == 1)
        {
            StopMethod();
            m_text = "���ݱ��� �޴��� �ʹ� �� ������༭ ���� ���佺Ʈ�� �޴��� ��Ź�ҰԿ�!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 2)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            Invoke("StartPopup", 0.5f);
            t_i++;
        }
        else if (t_i == 3)
        {
            StopMethod();
            CancelInvoke("TimeCount");
            CancelInvoke("TimeEnd");
            boss.SetActive(true);
            bossPanel.SetActive(true);
            m_text = "���� '�⺻ �佺Ʈ'�� ���� ����� �����?";
            StartMethod();
            t_i++;
        }
        else if (t_i == 4)
        {
            StopMethod();
            m_text = "�ܿ� ������ ������� ��Ḧ �����ؼ� �佺Ʈ�� �ϼ����ּ���!";
            StartMethod();
            t_i++;
        }
        else if (t_i == 5)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            t_i++;
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
            Invoke("Correct", 1.5f);
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
        clickObject.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1); //Ŭ���� ũ��Ŀ����
        Invoke("BtnReScale", 0.1f);

        cnt = 2;
        if (_list[i] == basicToast[i])
        {
            if (i == 0)//��
            {
                audioSrc.PlayOneShot(click[3]);
            }
            if (i == 1)//�佺��
            {
                audioSrc.PlayOneShot(click[4]);
            }
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
            recipeSlider.GetComponent<Image>().fillAmount += 0.5f; //2����
            hintArrows[0].SetActive(false);
            StopCoroutine(coroutine);
            hintArrows[i].SetActive(false);
            wrongCnt = 0;

            if (i == 1)
            {
                btnMachine.GetComponent<Image>().sprite = sprite1; //�������� ��
                Invoke("BtnImgChange", 0.8f);
                //�Ļ��� ��迡 ��(��ư ���� ����)
            }
            if (i == 2)
            {
                btnMachine.GetComponent<Image>().sprite = sprite2;
                particle.Play(); //�׸��� �ϼ���ƼŬ
                particleHeart.Play();
                MapManager.secondT = 1;
                Invoke("CorrectSound", 1f);//1�� �� ���� ȿ����
            }
        }
        else
        {
            _list.RemoveAt(i);
            wrongCnt++;
            audioSrc.PlayOneShot(click[2]);//���� ȿ����
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
    public void Show_Recipe()
    {
        Invoke("PanelStart", 1f);
    }
    public void Help_Click()
    {
        Popup pop = popupHelp.GetComponent<Popup>();
        audioSrc.PlayOneShot(click[0]);
        pop.PopUp();
        hintArrows[0].SetActive(false);
       
    }
    public void Correct()
    {
        Popup pop = popupCorrect.GetComponent<Popup>();
        pop.PopUp();
        MapManager.secondT = 1;
    }
    public void CorrectSound()
    {
        audioSrc.PlayOneShot(click[2]);//���� ȿ����
    }

    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        GameManager.ResetMenu();
        
        SceneManager.LoadScene("Main"); //2�ܰ� ���� ����! (��������)
    }
}
