using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCtrl : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip[] MenuVoice;

    int menuCount = 0;//�ֹ��� �޴� ��


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

    public void NaviTalkStart(int x)
    {


        audioSrc.PlayOneShot(MenuVoice[x]);
        WaitForSeconds();
    }
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }











    // Update is called once per frame
    void Update()
    {
        
    }
}
