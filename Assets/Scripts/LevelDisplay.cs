using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    //public Text levelText;
    public Text heartText;//��Ʈ ǥ�� ����
    public GameObject[] level;//���� ǥ�õǾ��ִ� ���ڱ�
    public GameObject[] count;//ī��Ʈ ǥ��

    public GameObject[] HelpPopup;//��Ʈ, ���ڱ�, ���� �˾�
    public GameObject HeartEffect;
    public GameObject StepsEffect;
    public GameObject BlackScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    public void Display()
    {
        //���� ��Ʈ �����ͼ� ��ܹٿ� ǥ��
        heartText.text = GameManager.currentHeart.ToString();
        //���� ���� �����ͼ� ��ܹٿ� ǥ��
        for (int i = 1; i < 6; i++)
        {
            if (GameManager.currentLevel == i)
            {
                level[i-1].SetActive(true);
            }
        }
        //���� ���ڱ� ���� �����ͼ� ��ܹٿ� ǥ��
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.currentCount == i)
            {
                count[i].SetActive(true);
            }
        }
    }

    public void OpenHeartHelp()
    {
        Popup pop = HeartEffect.GetComponent<Popup>();
        pop.PopUp();
        Invoke("ShowGif1", 0.5f);
        //HelpPopup[0].SetActive(true);
        //BlackScreen.SetActive(true);
    }
    public void OpenStepsHelp()
    {
        Popup pop = StepsEffect.GetComponent<Popup>();
        pop.PopUp();
        Invoke("ShowGif2", 0.5f);
    }
    void ShowGif1()
    {
        HelpPopup[0].SetActive(true);
    }
    void ShowGif2()
    {
        HelpPopup[1].SetActive(true);
    }

    public void OpenHelp()
    {
        Popup pop = HelpPopup[2].GetComponent<Popup>();
        pop.PopUp5();
        //HelpPopup[2].SetActive(true);
        //BlackScreen.SetActive(true);
    }

    public void CloseHelp()
    {
        for(int i = 0; i<3; i++)
        {
            HelpPopup[i].SetActive(false);
            BlackScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
