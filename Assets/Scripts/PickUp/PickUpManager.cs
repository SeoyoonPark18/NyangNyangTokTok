using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PickUpManager : MonoBehaviour
{
    public static AudioSource audioSrc;

    public Text playerText;
    public Text bossText;
    public Text[] talkText;//���� �Ŀ� ���� �ؽ�Ʈ
    public GameObject playerPanel;
    public GameObject bossPanel;
    public GameObject[] talkPanel; //���� �Ŀ� ü�� ���ϴ� �г�
    
    public GameObject[] nextButton;//ù��° ��� �Ѿ �� ��ư
    public GameObject[] nextButton2;//�ι�° �гο� �ִ� ���� ��ư

    public GameObject p_nextButton;

    public GameObject big_counter;
    public GameObject big_background;
    public GameObject counter;

    public GameObject boss;
    public GameObject[] cat; //���� �Ŀ� ü��

    //���� ���
    private string[] m_text = { "�� �ʹ� ���ְڴٳ�!\n", "���п� �ູ�����ٳ�!\n���� �Ϸ� �ǽö��~!" };
    private string[] thanktext = { "�� �� Ŀ������ �� ���ٳ�~!", "�˷ϴ޷��� ����ũ�� �����������ٳ�~!", "������ ���� �� ���� �� �� �������ٳ�~!", "�佺Ʈ�� �ʹ� �Ϳ��ٳ�~!", "���� ���״µ� ��� ���Ҵٳ�~!" };
    public AudioClip[] naviThank;
    //�Ŀ� ���
    private string[] m2_text = { "��� ���־� ���δٳ�!\n", "���ְ� ������༭ ���ٳ�!\n���� �Ϸ� �ǽö��~!" };
    private string[] thank2text = { "��ħ�� �� ���ٳ�! ���� Ŀ�Ǵ� ���Ⱑ �ְ���!", "�� ����� ����̵��� ��� ���� ī�丸 �´ٳ�!"};
    public AudioClip[] nyaongThank;
    //ü�� ���
    private string[] m3_text = { "�� �� �԰�ʹٳ�!\n", "���п� ����� �������ٳ�!\n���� �Ϸ� �ǽö��~!" };
    private string[] thank3text = { "��� ���� Ŀ���⿡ ���Ѵٳ�~!", "ü�� ���⿡ �� ���� �� ���ٳ�~!"};
    public AudioClip[] cherryThank;

    private string p_text = "�ֹ��Ͻ� �޴� ���Խ��ϴ�~!\n";
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
        PlayerTalkStart();

    }
    
    void Update()
    {

    }
    public void P_NextBtn()
    {
        playerPanel.SetActive(false);
        big_background.SetActive(false);
        counter.SetActive(true);
        big_counter.SetActive(false);
        talkPanel[GameManager.random].SetActive(true);
        Invoke("CatShowUp", 1f);
    }
    void CatShowUp()
    {
        cat[GameManager.random].SetActive(true);
        if(GameManager.random == 0)
        {
            Invoke("CatTalkStart", 1f);
        }else if (GameManager.random == 1)
        {
            Invoke("Cat2TalkStart", 1f);
        }else if (GameManager.random == 2)
        {
            Invoke("Cat3TalkStart", 1f);
        }

    }
    //����
    void CatTalkStart()
    {
        first_text = Random.Range(0, 2);
        yes_coffee_text = Random.Range(0, 3);
        low_no_coffee_text = Random.Range(1, 4);
        high_no_coffee_text = Random.Range(1, 5);

        audioSrc.PlayOneShot(naviThank[0]);

        if (GameManager.currentLevel == 1)//1�ܰ�
        {
            m_text[0] += thanktext[first_text];

            StartCoroutine(catsTalking(first_text + 3));
            //catsTalking(first_text+3);
        }else if(GameManager.currentLevel == 2)//2�ܰ�
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
            {
                m_text[0] += thanktext[yes_coffee_text];
                StartCoroutine(catsTalking(yes_coffee_text + 3));
                //catsTalking(yes_coffee_text + 3);
            }
            else//�佺Ʈ�� ť�길 ���� ��
            {
                m_text[0] += thanktext[low_no_coffee_text];
                StartCoroutine(catsTalking(low_no_coffee_text + 3));
                //catsTalking(low_no_coffee_text + 3);
            }
        }
        else//3,4,5�ܰ�
        {
            if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
            {
                m_text[0] += thanktext[yes_coffee_text];
                StartCoroutine(catsTalking(yes_coffee_text + 3));
                //catsTalking(yes_coffee_text + 3);
            }
            else//�佺Ʈ�� ť�길 ���� ��
            {
                m_text[0] += thanktext[high_no_coffee_text];
                StartCoroutine(catsTalking(high_no_coffee_text + 3));
                //catsTalking(high_no_coffee_text + 3);
            }
        }
        StopMethod();
        StartMethod(0);
        //StartCoroutine(_typing(0));
    }
    //�Ŀ�
    void Cat2TalkStart()
    {
        int coffee = Random.Range(0, 2);

        audioSrc.PlayOneShot(nyaongThank[0]);

        if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
        {
            m2_text[0] += thank2text[coffee];
            StartCoroutine(catsTalking(coffee + 3));
            //catsTalking(coffee + 3);
        }
        else//�佺Ʈ�� ť�길 ���� ��
        {
            m2_text[0] += thank2text[1];
            StartCoroutine(catsTalking(4));
            //catsTalking(4);
        }

        StopMethod();
        StartMethod(0);
    }
    //ü��
    void Cat3TalkStart()
    {
        int coffee = Random.Range(0, 2);

        audioSrc.PlayOneShot(cherryThank[0]);

        if (SpecifyNumber.MakingMenu[0] <= 7)//Ŀ�� �޴��� ������ �� 
        {
            m3_text[0] += thank3text[coffee];
            StartCoroutine(catsTalking(coffee + 3));
            //catsTalking(coffee + 3);
        }
        else//�佺Ʈ�� ť�길 ���� ��
        {
            m3_text[0] += thank3text[1];
            StartCoroutine(catsTalking(4));
            //catsTalking(4);
        }

        StopMethod();
        StartMethod(0);
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
        
        StartCoroutine(_typing2());//
    }


    public void NextTalk()
    {
        StopMethod();
        StartMethod(1);
        //����, �Ŀ�, ü�� �ι�° �г� ���
        StartCoroutine(catsTalking2());

        nextButton[GameManager.random].SetActive(false);
        nextButton2[GameManager.random].SetActive(true);
    }

    //����̵� ���� ��� ���ϱ�(ù��° �г�)
    IEnumerator catsTalking(int x)
    {
        //����
        if(GameManager.random == 0)
        {
            yield return new WaitForSeconds(1.7f);
            audioSrc.PlayOneShot(naviThank[x]);
        }
        //�Ŀ�
        if (GameManager.random == 1)
        {
            yield return new WaitForSeconds(1.7f);
            audioSrc.PlayOneShot(nyaongThank[x]);
        }
        //ü��
        if (GameManager.random == 2)
        {
            yield return new WaitForSeconds(1.9f);
            audioSrc.PlayOneShot(cherryThank[x]);
        }
    }

    //����̵� ��� ���ϱ�(�ι�° �г�
    IEnumerator catsTalking2()
    {
        yield return new WaitForSeconds(0f);
        //ù��° ���
        //����
        if (GameManager.random == 0)
        {
            audioSrc.PlayOneShot(naviThank[1]);
            yield return new WaitForSeconds(1.5f);
        }
        //�Ŀ�
        if (GameManager.random == 1)
        {
            audioSrc.PlayOneShot(nyaongThank[1]);
            yield return new WaitForSeconds(1.8f);
        }
        //ü��
        if (GameManager.random == 2)
        {
            audioSrc.PlayOneShot(cherryThank[1]);
            yield return new WaitForSeconds(1.8f);
        }
        //�ι�° ���
        //����
        if (GameManager.random == 0)
        {
            audioSrc.PlayOneShot(naviThank[2]);
        }
        //�Ŀ�
        if (GameManager.random == 1)
        {
            audioSrc.PlayOneShot(nyaongThank[2]);
        }
        //ü��
        if (GameManager.random == 2)
        {
            audioSrc.PlayOneShot(cherryThank[2]);
        }
    }
    IEnumerator _typing(int x)
    {
        yield return new WaitForSeconds(0f);
        if(GameManager.random == 0)
        {
            for (int i = 0; i <= m_text[x].Length; i++)
            {
                talkText[0].text = m_text[x].Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
        }else if (GameManager.random == 1)
        {
            for (int i = 0; i <= m2_text[x].Length; i++)
            {
                talkText[1].text = m2_text[x].Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
        }else if (GameManager.random == 2)
        {
            for (int i = 0; i <= m3_text[x].Length; i++)
            {
                talkText[2].text = m3_text[x].Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
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

    IEnumerator coroutine;
    void StartMethod(int x)
    {
        coroutine = _typing(x);
        StartCoroutine(coroutine);
    }
    void StopMethod()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
