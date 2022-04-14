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

    public Text playerText;
    public Text bossText;
    public Text talkText;
    public GameObject playerPanel;
    public GameObject bossPanel;
    public GameObject talkPanel; //����
    
    public GameObject nextButton;
    public GameObject nextButton2;

    public GameObject p_nextButton;

    public GameObject big_counter;
    public GameObject big_background;

    public GameObject boss;
    public GameObject cat1;
    //private string[] cats = { "cat1", "cat2", "cat3" }; //���� ������ ����� ĳ���� ����

    private string[] m_text = { "�� �ʹ� ���ְڴٳ�!\n", "���п� �ູ�����ٳ�!\n���� �Ϸ� �ǽö��~!" };

    private string[] thanktext = { "�� �� Ŀ������ �� ���ٳ�~!", "�˷ϴ޷��� ����ũ�� �����������ٳ�~!", "������ ���� �� ���� �� �� �������ٳ�~!", "�佺Ʈ�� �ʹ� �Ϳ��ٳ�~!", "���� ���״µ� ��� ���Ҵٳ�~!" };

    private string p_text = "�ֹ��Ͻ� �޴� ���Խ��ϴ� :)\n";
    private string[] watchout_text = { "Ŀ�ǰ� �߰ſ�� ������ �����ϼ���!", "����ũ�� ������ �������!", "�佺Ʈ�� �߰ſ�� ������ �����ϼ���!" };

    private int first_text;//1�ܰ� ������
    private int yes_coffee_text;//Ŀ�� ���� �� ������
    private int low_no_coffee_text;//���� �������� Ŀ�� ���� ��
    private int high_no_coffee_text;//���� �������� Ŀ�� ���� ��

    private int p_coffee_text;
    private int p_noncoffee_text;

    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
        //this.animator = GetComponent<Animation>().speed = 0.0f;

        //Invoke("CatShowUp", 1f);
        PlayerTalkStart();

    }
    
    void Update()
    {

    }
    public void P_NextBtn()
    {
        playerPanel.SetActive(false);
        big_background.SetActive(false);
        big_counter.SetActive(false);
        talkPanel.SetActive(true);
        Invoke("CatShowUp", 1f);
    }
    void CatShowUp()
    {
        cat1.SetActive(true);
        Invoke("CatTalkStart", 1f);
    }
    void CatTalkStart()
    {
        /*
        playerPanel.SetActive(false);
        big_background.SetActive(false);
        big_counter.SetActive(false);

        talkPanel.SetActive(true);*/
        first_text = Random.Range(0, 2)
;       yes_coffee_text = Random.Range(0, 3);
        low_no_coffee_text = Random.Range(1, 4);
        high_no_coffee_text = Random.Range(1, 5);
        if (GameManager.currentLevel == 1)//1�ܰ�
        {
            m_text[0] += thanktext[first_text];
        }else if(GameManager.currentLevel == 2)//2�ܰ�
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
            {
                m_text[0] += thanktext[yes_coffee_text];
            }
            else//�佺Ʈ�� ť�길 ���� ��
            {
                m_text[0] += thanktext[low_no_coffee_text];
            }
        }
        else//3,4,5�ܰ�
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
            {
                m_text[0] += thanktext[yes_coffee_text];
            }
            else//�佺Ʈ�� ť�길 ���� ��
            {
                m_text[0] += thanktext[high_no_coffee_text];
            }
        }

        StartCoroutine(_typing(0));
    }
    void PlayerTalkStart()
    {
        p_coffee_text = Random.Range(0, 2);
        p_noncoffee_text = Random.Range(1, 3);

        if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
        {
            if (SpecifyNumber.MakingMenu[0] % 2 == 0 || SpecifyNumber.MakingMenu[1] % 2 == 0)//Ŀ�ǰ� �߰ſ� ��
            {
                p_text += watchout_text[p_coffee_text];
            }
            else//������ Ŀ�Ǹ� ���� ��
            {
                p_text += "���� �̲������ ������ �� �ٵ弼��!";
            }
        }
        else//�佺Ʈ�� ť�길 ���� ��
        {
            p_text += watchout_text[p_noncoffee_text];
        }
        StartCoroutine(_typing2());
    }

    void CatTalkStart2()
    {

    }

    public void NextTalk()
    {
        StartCoroutine(_typing(1));
        nextButton.SetActive(false);
        nextButton2.SetActive(true);
    }

    public void Ending()
    {
        //Ʋ���ų�, �¾Ұų�, �¾Ƽ� ���� �������°� ������ �ڵ�
    }


    public void ShowBoss()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        cat1.SetActive(false);
        talkPanel.SetActive(false);
        bossPanel.SetActive(true);
        boss.SetActive(true);
        Invoke("BossTalkStart", 1f); //���� ������ �°� �� ����
    }



    IEnumerator _typing(int x)
    {
        yield return new WaitForSeconds(0f);
        for (int i=0; i<= m_text[x].Length; i++)
        {
            talkText.text = m_text[x].Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= p_text.Length; i++)
        {
            playerText.text = p_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }


}
