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

    public GameObject CountPopup;//ī��Ʈ�� 1,2�� ���� �� �˾�
    public GameObject Count3Popup;//ī��Ʈ�� 3�� ���� �� �˾�
    public GameObject LevelPopup;//���� �˾�

    private string[] b_text = { "���õ� ��� ���Ҿ��!\n���ϵ� ��̰� ���ؿ�~!", " �ǽŰ� ���ϵ����~!\n�����ε� ���� ����ְ� ���ؿ�!",
        "�����Ⱓ ������ �����ؿ�!\n�������ʹ� �˹ٻ��Բ� �佺Ʈ�� �ðܺ��Կ�~!", "�������� ���� �����༭ ������~!\n���ϵ� ���� ��̰� ���ؿ�:)" };
    private static int textOrder = 0;//b_text ���� ���� ����
    private string[] position = { "���� �˹ٻ���", "��� �˹ٻ���", "�θŴ�����", "�Ŵ�����"};//���� ����

    //�����
    public GameObject talkPanel; //����
    public GameObject cat1;

    public AudioClip click;
    AudioSource audioSrc;

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

                    //�˾� ����
                    Count3Popup.SetActive(true);
                    
                }else if (GameManager.currentLevel == 5){//����5�ε� �� 3�� ī��Ʈ ä�� ���
                    textOrder = 3;
                    //����� ��Ÿ���� ���ٴ� �λ�� �Բ� ����ش޶�� �޽��� ���ϱ�
                    ShowBoss();
                }
            }
            else//ī��Ʈ�� 1�̳� 2�� ä������ ��
            {
                textOrder = 0;
                //�˾� ����
                CountPopup.SetActive(true);
            }
        }
        else//�ѹ��̶� Ʋ���� ���ڱ�, ������ ����. ������̶� �λ��ϰ� �ٽ� ����ϱ⤡��
        {
            textOrder = 0;
            ShowBoss();
        }
        cat1.SetActive(false);
        talkPanel.SetActive(false);
        //PlayerPrefs.Save();//������ ����
    }

    //������ ����
    public void SaveData()
    {
        PlayerPrefs.SetInt("tmpLevel", GameManager.currentLevel);
        PlayerPrefs.SetInt("tmpCount", GameManager.currentCount);
        PlayerPrefs.SetInt("tmpHeart", GameManager.currentHeart);
        PlayerPrefs.Save();//PlayerPrefs�� ����
    }

    public void ShowBoss()
    {
        Debug.Log("��� �Լ� ����");
        //audioSrc.PlayOneShot(click, 0.5f);

        bossPanel.SetActive(true);
        boss.SetActive(true);
        WaitForSeconds();
        //BossTalkStart();
        //StartCoroutine(_typing(textOrder));
        Invoke("BossTalkStart", 1f); //���� ������ �°� �� ����
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    void BossTalkStart()
    {
        StartCoroutine(_typing(textOrder));
    }

    IEnumerator _typing(int a)
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= b_text[a].Length; i++)
        {
            bossText.text = b_text[a].Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }

    public void CloseBtn()//�˾� �ݱ� ��ư
    {
        CountPopup.SetActive(false);
        LevelPopup.SetActive(false);
        //ShowBoss();
    }
    public void NextBtn()//�˾� ������ư
    {
        Count3Popup.SetActive(false);
        LevelPopup.SetActive(true);
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
            SceneManager.LoadScene("Start");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
