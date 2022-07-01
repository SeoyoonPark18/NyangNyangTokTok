using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    public static int wrongCount = 0;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    public GameObject bossBtn;

    //�����
    public AudioClip levelup;
    public AudioClip popup;
    public AudioClip[] bossTalk;

    public GameObject CountPopups;
    //public GameObject CountPopup;//ī��Ʈ�� 1,2�� ���� �� �˾�
    //public GameObject CountInfoPopup;//ī��Ʈ �������ִ� �˾�
    public GameObject LevelPopup;//������ �˾�(ī��Ʈ�� 3�� ���� �� �˾�)
    public GameObject Gifsteps;

    //������ �˾� �̹���
    public GameObject[] PopupImg;
    //���� �ؽ�Ʈ�� �� ��
    private string[] LvText = { "Lv.1\n�����Ⱓ\n�˹ٻ�", "Lv.2\n�˹ٻ�", "Lv.3\n��� �˹ٻ�", "Lv.4\n�θŴ���", "Lv.5\n�Ŵ���" };
    //���� �ؽ�Ʈ
    public Text BeforeLevel;//���� ����
    public Text AfterLevel;//������ ����
    //���ڱ�
    public GameObject Step1;
    public GameObject Step2;



    private string[] b_text = { "���õ� ��� ���Ҿ��!\n���ϵ� ��̰� ���ؿ�~!", " �ǽ� �� ���ϵ����~!\n�����ε� ���� ����ְ� ���ؿ�!",
        "�����Ⱓ ������ �����ؿ�!\n�������ʹ� �˹ٻ��Բ� �佺Ʈ�� �ðܺ��Կ�~!", "�������� ���� �����༭ ������~!\n���ϵ� ���� ��̰� ���ؿ�!" };
    private static int textOrder = 0;//b_text ���� ���� ����
    private string[] position = { "���� �˹ٻ���", "��� �˹ٻ���", "�θŴ�����", "�Ŵ�����"};//���� ����

    //�����
    public GameObject[] talkPanel; //����, �Ŀ�, ü��
    public GameObject[] cat;//����, �Ŀ�, ü��

    //AudioSource audioSrc;
    void Start()
    {
        
    }

    public void MovingLevel()
    {
        if(wrongCount == 0)//�ѹ��� Ʋ���� �ʾ��� ��
        {
            GameManager.currentCount += 1;//ī��Ʈ �ø���
            if (GameManager.currentCount == 3)//ī��Ʈ�� 3 ä������ �� ���� �÷��� ��
            {
                if(GameManager.currentLevel < 5)//���� 5�� �ƴ� ��
                {
                    GameManager.currentLevel += 1;//���� ������ �ø���!
                    GameManager.currentCount = 0;//������ ī��Ʈ 0���� ������Ʈ! 3���� ���� ������ �� �ٽ� 0�� �Ǳ� ����

                    if (GameManager.currentLevel == 2)//���� �˹ٻ��� �ż� ���� �佺Ʈ�� ����� �� ��
                    {
                        textOrder = 2;
                    }
                    else//���� �˹ٻ� �� ����
                    {
                        //���� ��Ʈ ����
                        b_text[1] = position[GameManager.currentLevel - 2] + b_text[1];
                        textOrder = 1;
                    }
                    for(int i = 2; i<6; i++)
                    {
                        if (GameManager.currentLevel == i)
                        {
                            PopupImg[i - 2].SetActive(true);
                        }
                    }

                    //���� �� �˾� ����
                    //LevelPopup.SetActive(true);
                    Popup pop = LevelPopup.GetComponent<Popup>();
                    Invoke("UpSound", 0.5f);
                    pop.PopUp7();
                    Invoke("ShowGif", 0.25f);

                }
                else if (GameManager.currentLevel == 5){//����5�ε� �� 3�� ī��Ʈ ä�� ���
                    textOrder = 3;
                    //����� ��Ÿ���� ���ٴ� �λ�� �Բ� ����ش޶�� �޽��� ���ϱ�
                    ShowBoss();
                }
            }
            else//ī��Ʈ�� 1�̳� 2�� ä������ ��
            {
                textOrder = 0;
                //�˾� ����
                for(int i = 1; i<5; i++)
                {
                    if(GameManager.currentLevel == i)
                    {
                        BeforeLevel.text = LvText[i-1];
                        AfterLevel.text = LvText[i];
                    }
                }
                if(GameManager.currentCount == 1)
                {
                    Step1.SetActive(true);
                }else if (GameManager.currentCount == 2)
                {
                    Step1.SetActive(true);
                    Step2.SetActive(true);
                }
                //���� �˾� ���� ����
                //CountInfoPopup.SetActive(true);
                Popup pop = CountPopups.GetComponent<Popup>();
                pop.PopUp6();
                Invoke("PopSound", 0.5f);
                //ī��Ʈ �ö󰡴� �˾� ����(������ư ������� ����)
                //CountPopup.SetActive(true);
            }
        }
        else//�ѹ��̶� Ʋ���� ���ڱ�, ������ ����. ������̶� �λ��ϰ� �ٽ� ����ϱ⤡��
        {
            textOrder = 0;
            ShowBoss();
        }
        cat[GameManager.random].SetActive(false);
        talkPanel[GameManager.random].SetActive(false);
        //PlayerPrefs.Save();//������ ����
    }
    void ShowGif()
    {
        Gifsteps.SetActive(true);
    }
    public void ShowCountPopup()
    {
        //CountInfoPopup.SetActive(false);
        //CountPopup.SetActive(true);
    }

    //������ ����
    public void SaveData()
    {
        PlayerPrefs.SetInt("tmpLevel", GameManager.currentLevel);
        PlayerPrefs.SetInt("tmpCount", GameManager.currentCount);
        PlayerPrefs.SetInt("tmpHeart", GameManager.currentHeart);
        PlayerPrefs.SetInt("tmpFirstT", MapManager.firstT);
        PlayerPrefs.SetInt("tmpSecondT", MapManager.secondT);
        PlayerPrefs.Save();//PlayerPrefs�� ����
    }

    public void ShowBoss()
    {
        bossPanel.SetActive(true);
        boss.SetActive(true);
        //BossTalkStart();
        StartCoroutine(_typing(textOrder));
        StartCoroutine(bossTalking(textOrder));
        //Invoke("BossTalkStart", 1f); //���� ������ �°� �� ����
    }

    IEnumerator bossTalking(int x)
    {
        yield return new WaitForSeconds(1f);

        if(x == 0)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[0]);
            yield return new WaitForSeconds(1.9f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[1]);
        }
        if (x == 1)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[GameManager.currentLevel]);
            yield return new WaitForSeconds(2.5f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[6]);
        }
        if (x == 2)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[7]);
            yield return new WaitForSeconds(2.5f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[8]);
        }
        if (x == 3)
        {
            PickUpManager.audioSrc.PlayOneShot(bossTalk[9]);
            yield return new WaitForSeconds(2.5f);
            PickUpManager.audioSrc.PlayOneShot(bossTalk[10]);
        }


    }

    private void UpSound()
    {
        PickUpManager.audioSrc.PlayOneShot(levelup);
    }
    private void PopSound()
    {
        PickUpManager.audioSrc.PlayOneShot(popup);
    }
    /*
    void BossTalkStart()
    {
        StartCoroutine(_typing(textOrder));
    }*/

    IEnumerator _typing(int a)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= b_text[a].Length; i++)
        {
            bossText.text = b_text[a].Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }

    public void CloseBtn()//�˾� �ݱ� ��ư
    {
        //CountPopup.SetActive(false);
        //LevelPopup.SetActive(false);
        //ShowBoss();
    }

    public void BossBtn()//����� ���λ� �г� ��ư
    {
        if(textOrder == 2)
        {
            //�佺ƮƩ�丮��� �̵�
            SceneManager.LoadScene("T_BasicToast");
        }
        else
        {
            SceneManager.LoadScene("LevelMap");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
