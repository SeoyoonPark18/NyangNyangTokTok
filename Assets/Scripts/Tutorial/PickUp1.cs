using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PickUp1 : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //����

    public GameObject boss;
    public GameObject cat1;

    public GameObject background;
    public GameObject counter;
    public GameObject menu1;
    public GameObject menu2;

    private string m_text;

    int i = 0;

    void Start()
    {

        Invoke("BossTalk", 1f);
        //BossTalk();
    }
    void BossShowUp()
    {
        m_text = "";
        StartMethod();
        boss.SetActive(true);
        bossPanel.SetActive(true);
        Invoke("BossTalk", 1f);
    }

    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "�ֹ��� �޴��� ��� �غ��߾��! " + "\n" + "���� �մԿ��� �޴��� �������ּ���~";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            m_text = "";
            StartMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);

            background.SetActive(false);
            counter.SetActive(false);
            menu1.SetActive(false);
            menu2.SetActive(false);

            talkPanel.SetActive(true);
            cat1.SetActive(true);
            Invoke("CatTalk", 1f);
            i++;
        }
        else if (i == 2)
        {
            m_text = "�޴� �غ��ϴ��� ���� ���Ҿ��! " + "\n" + "�����ε� �� ��Ź�ؿ�~";
            StartMethod();
            i++;
        }
        else if (i == 3)
        {
            StopMethod();
            m_text = "���� �������� ������ �����غ����?";
            StartMethod();
            i++;
        }
        else if (i == 4)
        {
            SceneMove();
        }
    }

    int j = 0;
    public void CatTalk()
    {
        if (j == 0)
        {
            m_text = "�� �ʹ� ���ְڴٳ�!" + "\n" + "���������� �غ����༭ ���ٳ�~!";
            StartMethod2();
            j++;
        }
        else if (j == 1)
        {
            StopMethod2();
            m_text = "���п� �ູ�����ٳ�!" + "\n" +"�����ε� �� ��Ź�Ѵٳ�~";
            StartMethod2();
            j++;
        }
        else if (j == 2)
        {
            talkPanel.SetActive(false);
            cat1.SetActive(false);
            BossShowUp();
        }
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
        for (int i = 0; i <= m_text.Length; i++)
        {
            talkText.text = m_text.Substring(0, i);
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

    IEnumerator coroutine2;
    void StartMethod2()
    {
        coroutine2 = _typing2();
        StartCoroutine(coroutine2);
    }
    void StopMethod2()
    {
        if (coroutine2 != null)
        {
            StopCoroutine(coroutine2);
        }
    }

    public void SceneMove()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        //SceneManager.LoadScene(""); //����ϱ� ������ �̵�
    }
}
