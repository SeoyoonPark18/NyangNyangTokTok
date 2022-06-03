using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Cube1 : MonoBehaviour
{
    public GameObject popupStart;
    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    int i = 0;

    public AudioClip[] bossVoice;
    AudioSource audioSrc;

    public void BossVoice()
    {
        audioSrc.PlayOneShot(bossVoice[1]);
    }

    void Start()
    {
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
        if (i == 0)
        {
            boss.SetActive(true);
            bossPanel.SetActive(true);

            audioSrc.PlayOneShot(bossVoice[0]);
            m_text = "���̽� �Ƹ޸�ī�븦 �ϼ��߾��! ���� ���� �޴��� 3�� ť������ũ�� �����ؿ�~";
            audioSrc.PlayOneShot(bossVoice[0]);
            Invoke("BossVoice", 2.5f);
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            audioSrc.Stop();
            m_text = "�ȳ������� �� ���� �������� ť������ũ�� �ش� ���⿡�� �� ����� ����ּ���!";
            audioSrc.PlayOneShot(bossVoice[2]);
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            StopMethod();
            boss.SetActive(false);
            bossPanel.SetActive(false);
            //Invoke("StartPopup", 0.5f);
            i++;
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
    public void NextBtn()
    {
        //audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_PickUp");
    }
}
