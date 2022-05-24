using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //����
    public GameObject startPopup;
    public GameObject boss;
    public GameObject cat1;
   
    public static string OrderMenu1 = "";
    public static string OrderMenu2 = "";

    public static int coffeeCount;
    public static int cubeCount;

    private string m_text;
    private string[] m = new string[4];
    private string[] m_ = { "��", "��", "��", "��", "~" };

    int i = 0;

    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        OrderMenu1 = "���̽� �Ƹ޸�ī��";
        ++coffeeCount;
        OrderMenu2 = "3�� ť������ũ";
        ++cubeCount;

        Invoke("BossShowUp", 1f);

    }
    void BossShowUp()
    {
        boss.SetActive(true);
        Invoke("BossTalk", 1f);
    }

    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "�ݰ�����~ ���ú��� ����� �츮 ī���� '���� �˹ٻ�'�̿���!";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            m_text = "�ֹ��� �ް� �޴��� ����� �������� ���� �������״� �� ���� �������ּ���~";
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            audioSrc.PlayOneShot(click, 0.5f);
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            Popup pop = startPopup.GetComponent<Popup>();
            pop.PopUp();

            
        }
    }
    public void PopupBtn()
    {
        talkPanel.SetActive(true);
        cat1.SetActive(true);
        Invoke("CatTalk", 1f); //���� ������ �°� �� ����
        i = 0;
    }
    void CatTalk()
    {
        m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "�� ";
        m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";
        StartCoroutine(_typing2());
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for(int i=0; i<= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < 4; i++)
        {
            talkText.text += m[i];
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 5; i++)
        {
            talkText.text += m_[i];
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

    public void SceneMove()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_MemorizeMenu");
    }
}
