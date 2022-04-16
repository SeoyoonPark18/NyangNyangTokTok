using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase;
using Firebase.Auth;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    DatabaseReference databaseReference;

    public static int wrongCount = 0;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    public GameObject bossBtn;

    public GameObject CountPopup;//ī��Ʈ�� 1,2�� ���� �� �˾�
    public GameObject Count3Popup;//ī��Ʈ�� 3�� ���� �� �˾�
    public GameObject LevelPopup;//���� �˾�

    private string[] b_text = { "���õ� ��� ���Ҿ��!\n���ϵ� ��̰� ���ؿ�~!", "�� �ǽŰ� ���ϵ����~!\n�����ε� ���� ����ְ� ���ؿ�!",
        "�����Ⱓ ������ �����ؿ�!\n�������ʹ� �˹ٻ��Բ� �佺Ʈ�� �ðܺ��Կ�~!", "�������� ���� �����༭ ������~!\n���ϵ� ���� ��̰� ���ؿ�:)" };
    private int textOrder;//b_text ���� ���� ����
    private string[] position = { "���� �˹ٻ�", "��� �˹ٻ�", "�θŴ���", "�Ŵ���"};//���� ����

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
                    LevelUp(GameManager.currentLevel);//������ ���� ������Ʈ!
                    CountUp(0);//������ ī��Ʈ 0���� ������Ʈ! 3���� ���� ������ �� �ٽ� 0�� �Ǳ� ����

                    if(GameManager.currentLevel == 2)//���� �˹ٻ��� �ż� ���� �佺Ʈ�� ����� �� ��
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
                CountUp(GameManager.currentCount);//������ ī��Ʈ ������Ʈ
                textOrder = 0;
                //�˾� ����
            }
        }
        else//�ѹ��̶� Ʋ���� ���ڱ�, ������ ����. ������̶� �λ��ϰ� ����ϱ⤡��
        {
            textOrder = 0;
            ShowBoss();
        }
    }

    public void ShowBoss()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        cat1.SetActive(false);
        talkPanel.SetActive(false);
        bossPanel.SetActive(true);
        boss.SetActive(true);
        WaitForSeconds();
        //BossTalkStart(textOrder);
        StartCoroutine(_typing(textOrder));
        //Invoke("BossTalkStart", 1f); //���� ������ �°� �� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //�����ϱ� ������ �������ϴ� �κп��� ������ ī��Ʈ �ø� �ڵ�
    public void CountUp(int count)
    {
        var DBTask = databaseReference.Child("users").Child("count").SetValueAsync(count);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //count is now updated
        }
    }

    //�����ϱ� ������ �������ϴ� �κп��� ������ ���� �ø� �ڵ�
    public void LevelUp(int level)
    {
        var DBTask = databaseReference.Child("users").Child("level").SetValueAsync(level);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //level is now updated
        }
    }

    void BossTalkStart(int x)
    {


 
        //StartCoroutine(_typing(x));
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

    public void CloseBtn()
    {
        CountPopup.SetActive(false);
        LevelPopup.SetActive(false);
        ShowBoss();
    }
    public void NextBtn()
    {
        Count3Popup.SetActive(false);
        LevelPopup.SetActive(true);
    }
    public void BossBtn()
    {
        if(textOrder == 2)
        {
            //�佺ƮƩ�丮��� �̵�
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
