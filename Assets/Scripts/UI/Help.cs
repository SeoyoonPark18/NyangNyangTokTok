using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject Help_Popup;

    //AudioClip �Ҹ�
    public AudioClip popup;
    public AudioClip click;
    AudioSource audioSrc;

    //���� ȭ��
    public GameObject black_screen;

    public void Help_Click()
    {
        //Help_Popup.SetActive(true);
        Popup pop = Help_Popup.GetComponent<Popup>();
        pop.PopUp();
        audioSrc.PlayOneShot(popup, 0.5f);
        //black_screen.SetActive(true);
    }
    public void Close_Help()
    {
        //Help_Popup.SetActive(false);
        audioSrc.PlayOneShot(click, 0.5f);
        //black_screen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //����� ������Ʈ ��������
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
