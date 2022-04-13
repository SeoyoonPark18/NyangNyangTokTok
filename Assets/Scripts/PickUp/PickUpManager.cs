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

    public GameObject nextButton;
    public GameObject nextButton2;

    public GameObject boss;
    public GameObject cat1;
    //private string[] cats = { "cat1", "cat2", "cat3" }; //���� ������ ����� ĳ���� ����

    private string[] m_text = { "�� �ʹ� ���ְڴٳ�!\n", "���п� �ູ�����ٳ�!\n���� �Ϸ� �ǽö��~!" };

    private string[] thanktext = { "�� �� Ŀ������ �� ���ٳ�~!", "�˷ϴ޷��� ����ũ�� �����������ٳ�~!", "������ ���� �� ���� �� �� �������ٳ�~!", "�佺Ʈ�� �ʹ� �Ϳ��ٳ�~!", "���� ���״µ� ��� ���Ҵٳ�~!" };
    
    private int first_text;//1�ܰ� ������
    private int yes_coffee_text;//Ŀ�� ���� �� ������
    private int low_no_coffee_text;//���� �������� Ŀ�� ���� ��
    private int high_no_coffee_text;//���� �������� Ŀ�� ���� ��

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
        cat1.SetActive(true);
        Invoke("CatTalkStart", 1f);
    }
    void CatTalkStart()
    {
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
        //Ʋ���ų� �¾Ұų� �¾Ƽ� ���� �������°� ������ �ڵ�
    }


    public void ShowBoss()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        cat1.SetActive(false);
        talkPanel.SetActive(false);
        bossPanel.SetActive(true);
        cat1.SetActive(true);
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


}
