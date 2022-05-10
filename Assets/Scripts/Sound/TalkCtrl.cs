using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCtrl : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip[] NaviMenuVoice;

    int menuCount = 0;//�ֹ��� �޴� ��

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

    public void NaviTalkStart()
    {
        WaitForSeconds(1);
        for(int j = 0; j<menuCount; j++)
        {
            for (int i = 0; i < 20; i++)//i�� �޴��� ������ȣ
            {
                if (SpecifyNumber.MakingMenu[num[0]] == i)//now+1��° �޴��� ������ȣ i �޴��� �޾Ҵٸ�
                {
                    audioSrc.PlayOneShot(NaviMenuVoice[i]);
                    WaitForTalk();
                }
            }
            num.RemoveAt(0);
        }
       
    }
    IEnumerator WaitForTalk()
    {
        yield return new WaitForSeconds(2.0f);
    }
    IEnumerator WaitForSeconds(int x)
    {
        yield return new WaitForSeconds(x);
    }











    // Update is called once per frame
    void Update()
    {
        
    }
}
