using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    //������
    public GameObject[] LevelMap;
    //���ڱ� �� ���� ����
    public GameObject[] Step1;//���ڱ��� 1���� ��
    public GameObject[] Step2;//���ڱ��� 2���� ��


    public static bool firstT = false;//ù��° Ʃ�丮��
    public static bool secondT = false;//�ι��� Ʃ�丮��


    // Start is called before the first frame update
    void Start()
    {
        ShowLevel();
        ShowSteps();
        //TimeStart();
    }

    //���� �� ����
    public void ShowLevel()
    {
        for(int i = 1; i<6; i++)
        {
            if(GameManager.currentLevel == i)
            {
                LevelMap[i-1].SetActive(true);
            } 
        }
    }

    //���ڱ� ����
    public void ShowSteps()
    {
        for(int i = 1; i<6; i++)//���� 1~5 ����
        {
            if(GameManager.currentLevel == i)
            {
                if (GameManager.currentCount == 1)//���ڱ��� 1�϶�
                {
                    Step1[i - 1].SetActive(true);//�� �ܰ��� ���ڱ� 1 ���
                }
                if (GameManager.currentCount == 2)//�� �ܰ��� ���ڱ� 1, 2 ���
                {
                    Step1[i - 1].SetActive(true);
                    Step2[i - 1].SetActive(true);
                }
            }
            
        }
    }

    
    public void GameStart()
    {
        GameManager.ResetMenu();
        if (GameManager.currentLevel == 1 && GameManager.currentCount == 0)
        {
            SceneManager.LoadScene("T_Main");
        }else if (GameManager.currentLevel == 2 && GameManager.currentCount == 0)
        {
            SceneManager.LoadScene("T_BasicToast");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
