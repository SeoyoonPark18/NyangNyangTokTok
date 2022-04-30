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
    public GameObject BlackScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    public void Display()
    {
        //���� ���� �����ͼ� ��ܹٿ� ǥ��
        //levelText.text = GameManager.currentLevel.ToString();
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
        HelpPopup[0].SetActive(true);
        BlackScreen.SetActive(true);
    }

    public void OpenStepsHelp()
    {
        HelpPopup[1].SetActive(true);
        BlackScreen.SetActive(true);
    }

    public void OpenHelp()
    {
        HelpPopup[2].SetActive(true);
        BlackScreen.SetActive(true);
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
