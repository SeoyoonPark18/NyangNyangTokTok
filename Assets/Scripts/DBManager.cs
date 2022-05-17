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
            GameManager.currentLevel = 2;
            GameManager.currentCount = 0;
            GameManager.currentHeart = 0;
            Debug.Log("����: " + GameManager.currentLevel);
            Debug.Log("ī��Ʈ: " + GameManager.currentCount);
            Debug.Log("��Ʈ: " + GameManager.currentHeart);
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
            Debug.Log("����: " + GameManager.currentLevel);
            Debug.Log("ī��Ʈ: " + GameManager.currentCount);
            Debug.Log("��Ʈ: " + GameManager.currentHeart);
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
        PlayerPrefs.GetInt("tmpLevel", GameManager.currentLevel);
        PlayerPrefs.GetInt("tmpCount", GameManager.currentCount);
        PlayerPrefs.GetInt("tmpHeart", GameManager.currentHeart);
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
