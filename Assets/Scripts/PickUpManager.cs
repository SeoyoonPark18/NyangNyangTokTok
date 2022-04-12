using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PickUpManager : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //����

    public GameObject boss;
    public GameObject cat1;
    //private string[] cats = { "cat1", "cat2", "cat3" }; //���� ������ ����� ĳ���� ����

    private string m_text;


    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        //this.animator = GetComponent<Animation>().speed = 0.0f;

        Invoke("CatShowUp", 1f);

    }
    
    void Update()
    {

    }
    void CatShowUp()
    {
        boss.SetActive(true);
        Invoke("CatTalkStart", 1f);
    }
    void CatTalkStart()
    {
        m_text = "���� ��ħ�Դϴ�~\n���� �Ϸ絵 ������ ī�並 ��غ��ô�~!";
        if(SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
        {

        }
        StartCoroutine(_typing());
    }
    public void ShowBoss()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        cat1.SetActive(false);
        talkPanel.SetActive(false);
        talkPanel.SetActive(true);
        cat1.SetActive(true);
        Invoke("BossTalkStart", 1f); //���� ������ �°� �� ����
    }



    IEnumerator _typing()
    {
        for(int i=0; i<= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }


}
