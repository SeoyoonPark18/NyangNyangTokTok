using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCtrl : MonoBehaviour
{
    AudioSource audioSrc;
    
    //���� ��Ҹ�
    public AudioClip[] NaviMenuVoice;
    public AudioClip NaviPlease;
    
    //�Ŀ� ��Ҹ�
    public AudioClip[] NyaongMenuVoice;
    public AudioClip NyaongPlease;

    //ü�� ��Ҹ�
    public AudioClip[] CherryMenuVoice;
    public AudioClip CherryPlease;

    int menuCount = 0;//�ֹ��� �޴� ��
    float time = 1.2f;//���ϴ� �ð�
    int random;

    public static List<int> num = new List<int>() { 0, 1, 2, 3 };

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (SpecifyNumber.MakingMenu[2] > 19)//3��° �޴��� ������ȣ�� ���� ������ ��(�ֹ��� �޴��� 2���� ��)
        {
            menuCount = 2;
        }else if(SpecifyNumber.MakingMenu[3] > 19)//4��° �޴��� ������ȣ�� ���� ������ ��(�ֹ��� �޴��� 3���� ��)
        {
            menuCount = 3;
        }
        else//�ֹ��� �޴��� 4���� ��
        {
            menuCount = 4;
        }

    }

    public void CatTalkStart()
    {
        if(GameManager.random == 0)
        {
            Invoke("NaviTalkStart", 1);
        }else if (GameManager.random == 1)
        {
            Invoke("NyaongTalkStart", 1);
        }
        else
        {
            Invoke("CherryTalkStart", 1);
        }


    }

    //���� ���ϰ� �ϱ�
    public void NaviTalkStart()
    {
        for (int i = 0; i<menuCount; i++)
        {
            Invoke("NaviTalkMenu", time*i);
        }
        Invoke("NaviTalkPlease", time*menuCount);
    }
    //���� �޴� ���ϱ�
    public void NaviTalkMenu()
    {
        for (int i = 0; i < 20; i++)//i�� �޴��� ������ȣ
        {
            if (SpecifyNumber.MakingMenu[num[0]] == i)//num[0]+1��° �޴��� ������ȣ i �޴��� �޾Ҵٸ�
            {
                audioSrc.PlayOneShot(NaviMenuVoice[i]);
            }
        }
        num.RemoveAt(0);
    }
    //���� �ּ��� ���ϱ�
    public void NaviTalkPlease()
    {
        audioSrc.PlayOneShot(NaviPlease);
    }

    //�Ŀ� ���ϰ� �ϱ�
    public void NyaongTalkStart()
    {
        for (int i = 0; i < menuCount; i++)
        {
            Invoke("NyaongTalkMenu", time * i);
        }
        Invoke("NyaongTalkPlease", time * menuCount);
    }
    //�Ŀ� �޴� ���ϱ�
    public void NyaongTalkMenu()
    {
        for (int i = 0; i < 20; i++)//i�� �޴��� ������ȣ
        {
            if (SpecifyNumber.MakingMenu[num[0]] == i)//num[0]+1��° �޴��� ������ȣ i �޴��� �޾Ҵٸ�
            {
                audioSrc.PlayOneShot(NyaongMenuVoice[i]);
            }
        }
        num.RemoveAt(0);
    }
    //�Ŀ� �ּ��� ���ϱ�
    public void NyaongTalkPlease()
    {
        audioSrc.PlayOneShot(NyaongPlease);
    }

    //ü�� ���ϰ� �ϱ�
    public void CherryTalkStart()
    {
        for (int i = 0; i < menuCount; i++)
        {
            Invoke("CherryTalkMenu", time * i);
        }
        Invoke("CherryTalkPlease", time * menuCount);
    }
    //���� �޴� ���ϱ�
    public void CherryTalkMenu()
    {
        for (int i = 0; i < 20; i++)//i�� �޴��� ������ȣ
        {
            if (SpecifyNumber.MakingMenu[num[0]] == i)//num[0]+1��° �޴��� ������ȣ i �޴��� �޾Ҵٸ�
            {
                audioSrc.PlayOneShot(CherryMenuVoice[i]);
            }
        }
        num.RemoveAt(0);
    }
    //���� �ּ��� ���ϱ�
    public void CherryTalkPlease()
    {
        audioSrc.PlayOneShot(CherryPlease);
    }











    // Update is called once per frame
    void Update()
    {
        
    }
}
