using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{

    public bool IsSave;//����� �����Ͱ� �ִ��� Ȯ���ϱ� ���� �Ұ�



    public void LoadData()
    {
        IsSave = PlayerPrefs.HasKey("tmpLevel");

        //���̺� �����Ͱ� ���ٸ� ��� ������ ���� �ʱ�ȭ
        if (!IsSave)
        {
            Debug.Log("����� ������ ����");
            GameManager.currentLevel = 4;
            GameManager.currentCount = 2;
            GameManager.currentHeart = 0;
            MapManager.firstT = 0;
            MapManager.secondT = 0;
            Debug.Log("����: " + GameManager.currentLevel);
            Debug.Log("ī��Ʈ: " + GameManager.currentCount);
            Debug.Log("��Ʈ: " + GameManager.currentHeart);
            Debug.Log("Ʃ�丮��1: " + MapManager.firstT);
            Debug.Log("Ʃ�丮��2: " + MapManager.secondT);
            //level = 3;
            //count = 0;
            //heart = 0;
        }
        else
        {
            Debug.Log("����� ������ ����");
            GameManager.currentLevel = PlayerPrefs.GetInt("tmpLevel");
            GameManager.currentCount = PlayerPrefs.GetInt("tmpCount");
            GameManager.currentHeart = PlayerPrefs.GetInt("tmpHeart");
            MapManager.firstT = PlayerPrefs.GetInt("tmpFirstT");
            MapManager.secondT = PlayerPrefs.GetInt("tmpSecondT");
            Debug.Log("����: " + GameManager.currentLevel);
            Debug.Log("ī��Ʈ: " + GameManager.currentCount);
            Debug.Log("��Ʈ: " + GameManager.currentHeart);
            Debug.Log("Ʃ�丮��1: " + MapManager.firstT);
            Debug.Log("Ʃ�丮��2: " + MapManager.secondT);
        }
        //GameManager.currentLevel = int.Parse(PlayerPrefs.GetInt("tmpLevel", 3).ToString());
        
    }

    //������ ����
    void DeleteData()
    {
        PlayerPrefs.DeleteAll();
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

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
