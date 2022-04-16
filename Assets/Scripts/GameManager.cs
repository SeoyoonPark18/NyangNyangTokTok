using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Auth;


public class GameManager : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSrc;

    public Text bossText;
    public Text talkText;
    public GameObject bossPanel;
    public GameObject talkPanel; //����

    public GameObject boss;
    public GameObject cat1;
    //private string[] cats = { "cat1", "cat2", "cat3" }; //���� ������ ����� ĳ���� ����

    public static int currentLevel; //����!!
    public static int currentCount; //���ڱ� ��

    //public Text levelText;

    //1�ܰ�� �޴� ���
    private string[] level1_Coffee_menu = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���" };
    private string level1_Cube_menu = "3�� ť������ũ";
    int randomCoffee1;

    //2�ܰ�� �޴� ��� 
    private int level2_random;
    private string[] level2_Coffee_menu = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���", "���̽� ī���" };
    private string[] level2_Toast_menu = { "�⺻ �佺Ʈ", "���� �佺Ʈ" };
    private string level2_Cube_menu = "4�� ť������ũ";
    int randomCoffee2;
    int randomToast2;

    //3�ܰ�� �޴� ��� 
    private int level3_random;
    private string[] level3_Coffee_menu = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���", "���̽� ī���", "������ �ٴҶ��", "���̽� �ٴҶ��" };
    private string[] level3_Coffee_menu_1 = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���", "���̽� ī���", "���̽� �ٴҶ��" };
    private string[] level3_Toast_menu = { "�⺻ �佺Ʈ", "���� �佺Ʈ", "���� �佺Ʈ", "��纣�� �佺Ʈ", "���� ���� �佺Ʈ" };
    private string[] level3_Cube_menu = { "4�� ť������ũ", "5�� ť������ũ", "6�� ť������ũ" };
    int randomCoffee3;
    int randomCoffee3_1;
    int randomToast3;
    int randomToast3_1;
    int randomCube3;

    //4�ܰ�� �޴� ��� 
    private int level4_random;
    private string[] level4_Coffee_menu = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���", "���̽� ī���", "������ �ٴҶ��", "���̽� �ٴҶ��", "������ ī���ī" };
    private string[] level4_Toast_menu = { "���� �佺Ʈ", "��纣�� �佺Ʈ", "���� ���� �佺Ʈ" };
    private string[] level4_Cube_menu = { "5�� ť������ũ", "6�� ť������ũ", "7�� ť������ũ" };
    int randomCoffee4;
    int randomCoffee4_1;
    int randomToast4;
    int randomToast4_1;
    int randomCube4;

    //5�ܰ�� �޴� ��� 
    private int level5_random;
    private string[] level5_Coffee_menu = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���", "���̽� ī���", "������ �ٴҶ��", "���̽� ī���ī", "���̽� �ٴҶ��", "������ ī���ī" };
    private string[] level5_Coffee_menu_1 = { "������ �Ƹ޸�ī��", "���̽� �Ƹ޸�ī��", "������ ī���", "���̽� ī���", "������ �ٴҶ��",  "���̽� �ٴҶ��", "������ ī���ī", "���̽� ī���ī"};
    private string[] level5_Toast_menu = { "���� �佺Ʈ", "��纣�� �佺Ʈ", "���� ���� �佺Ʈ", "�ɳ� �佺Ʈ" };
    private string[] level5_Cube_menu = { "5�� ť������ũ", "6�� ť������ũ", "7�� ť������ũ", "8�� ť������ũ" };
    int randomCoffee5;
    int randomCoffee5_1;
    int randomToast5;
    int randomToast5_1;
    int randomCube5;
    int randomCube5_1;



    //�� 4�� �޴� �ֹ� ����
    public static string OrderMenu1 = "";
    public static string OrderMenu2 = "";
    public static string OrderMenu3 = "";
    public static string OrderMenu4 = "";

    public static int coffeeCount;
    public static int toastCount;
    public static int cubeCount;

    private string m_text;
    private string[] m = new string[4];
    private string[] m_ = { "��", "��", "��", "��", "~" };


    //Animation animator;

    void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;


        audioSrc = GetComponent<AudioSource>();
        //this.animator = GetComponent<Animation>().speed = 0.0f;

        //levelText.text = currentLevel.ToString();

        if (currentLevel == 1) //1�ܰ�
        {
            randomCoffee1 = Random.Range(0, 3); 
            OrderMenu1 = level1_Coffee_menu[randomCoffee1];
            ++coffeeCount;
            OrderMenu2 = level1_Cube_menu;
            ++cubeCount;
        }
        else if(currentLevel == 2) //2�ܰ�
        {
            
            level2_random = Random.Range(1, 3); 
            randomCoffee2 = Random.Range(0, 4);
            randomToast2 = Random.Range(0, 2);

            switch (level2_random)
            {
                case 1:
                    OrderMenu1 = level2_Coffee_menu[randomCoffee2];
                    ++coffeeCount;
                    OrderMenu2 = level2_Cube_menu;
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level2_Toast_menu[randomToast2];
                    ++toastCount;
                    OrderMenu2 = level2_Cube_menu;
                    ++cubeCount;
                    break;
            }     
        }
        else if (currentLevel == 3) //3�ܰ�
        {

            level3_random = Random.Range(1, 4);
            randomCoffee3 = Random.Range(0, 6);
            randomCoffee3_1 = Random.Range(0, 5);
            randomToast3 = Random.Range(0, 4);
            randomToast3_1 = Random.Range(1, 4);
            randomCube3 = Random.Range(0, 2);

            switch (level3_random)
            {
                case 1:
                    OrderMenu1 = level3_Coffee_menu[randomCoffee3];
                    ++coffeeCount;
                    OrderMenu2 = level3_Toast_menu[randomToast3];
                    ++toastCount;
                    OrderMenu3 = level3_Cube_menu[1];
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level3_Coffee_menu_1[randomCoffee3_1];
                    ++coffeeCount;
                    OrderMenu2 = level3_Coffee_menu[4];
                    ++coffeeCount;
                    OrderMenu3 = level3_Cube_menu[randomCube3];
                    ++cubeCount;
                    break;
                case 3:
                    OrderMenu1 = level3_Toast_menu[randomToast3_1];
                    ++toastCount;
                    OrderMenu2 = level3_Toast_menu[4];
                    ++toastCount;
                    OrderMenu3 = level3_Cube_menu[2];
                    ++cubeCount;
                    break;
            }
        }
        else if (currentLevel == 4) //4�ܰ�
        {

            level4_random = Random.Range(1, 4);
            randomCoffee4 = Random.Range(5, 7);
            randomCoffee4_1 = Random.Range(0, 5);
            randomToast4 = Random.Range(0, 2);
            randomToast4_1 = Random.Range(1, 3);
            randomCube4 = Random.Range(0, 2);

            switch (level4_random)
            {
                case 1:
                    OrderMenu1 = level4_Coffee_menu[randomCoffee4];
                    ++coffeeCount;
                    OrderMenu2 = level4_Toast_menu[randomToast4];
                    ++toastCount;
                    OrderMenu3 = level4_Cube_menu[randomCube4];
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level4_Coffee_menu[randomCoffee4_1];
                    ++coffeeCount;
                    OrderMenu2 = level4_Coffee_menu[6];
                    ++coffeeCount;
                    OrderMenu3 = level4_Cube_menu[randomCube4];
                    ++cubeCount;
                    break;
                case 3:
                    OrderMenu1 = level4_Toast_menu[randomToast4_1];
                    ++toastCount;
                    OrderMenu2 = level4_Cube_menu[1];
                    ++cubeCount;
                    OrderMenu3 = level4_Cube_menu[2];
                    ++cubeCount;
                    break;
            }
        }
        else if (currentLevel == 5) //5�ܰ�
        {

            level5_random = Random.Range(1, 5);
            randomCoffee5 = Random.Range(0, 6);
            randomCoffee5_1 = Random.Range(0, 6);
            randomToast5 = Random.Range(2, 4);
            randomToast5_1 = Random.Range(0, 3);
            randomCube5 = Random.Range(0, 2);
            randomCube5_1 = Random.Range(2, 4);

            switch (level5_random)
            {
                case 1:
                    OrderMenu1 = level5_Coffee_menu[randomCoffee5];
                    ++coffeeCount;
                    OrderMenu2 = level5_Coffee_menu[6];
                    ++coffeeCount;
                    OrderMenu3 = level5_Coffee_menu[7];
                    ++coffeeCount;
                    OrderMenu4 = level5_Cube_menu[randomCube5];
                    ++cubeCount;
                    break;
                case 2:
                    OrderMenu1 = level5_Coffee_menu_1[randomCoffee5_1];
                    ++coffeeCount;
                    OrderMenu2 = level5_Coffee_menu_1[7];
                    ++coffeeCount;
                    OrderMenu3 = level5_Toast_menu[randomToast5];
                    ++toastCount;
                    OrderMenu4 = level5_Cube_menu[2];
                    ++cubeCount;
                    break;
                case 3:
                    OrderMenu1 = level5_Coffee_menu_1[7];
                    ++coffeeCount;
                    OrderMenu2 = level5_Toast_menu[randomToast5_1];
                    ++toastCount;
                    OrderMenu3 = level5_Toast_menu[3];
                    ++toastCount;
                    OrderMenu4 = level5_Cube_menu[randomCube5_1];
                    ++cubeCount;
                    break;
                case 4:
                    OrderMenu1 = level5_Coffee_menu_1[randomCoffee5_1];
                    ++coffeeCount;
                    OrderMenu2 = level5_Coffee_menu_1[7];
                    ++coffeeCount;
                    OrderMenu3 = level5_Cube_menu[randomCube5];
                    ++cubeCount;
                    OrderMenu4 = level5_Cube_menu[3];
                    ++cubeCount;
                    break;
            }
        }


        Invoke("BossShowUp", 1f);

    }


    
    void Update()
    {

    }
    void BossShowUp()
    {
        boss.SetActive(true);
        Invoke("BossTalkStart", 1f);
    }
    void BossTalkStart()
    {
        //bossText.text = "���� ��ħ�Դϴ�~\n���� �Ϸ絵 ������ ī�並 ��غ��ô�~!";
        m_text = "���� ��ħ�Դϴ�~\n���� �Ϸ絵 ������ ī�並 ��غ��ô�~!";
        StartCoroutine(_typing());
    }
    public void ShowCat()
    {
        audioSrc.PlayOneShot(click, 0.5f); 

        boss.SetActive(false);
        bossPanel.SetActive(false);
        talkPanel.SetActive(true);
        cat1.SetActive(true);
        Invoke("CatTalkStart", 1f); //���� ������ �°� �� ����
    }

    void CatTalkStart()
    {
        

        if (currentLevel == 1) //1�ܰ�
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "�� ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";
        }
        else if(currentLevel == 2) //2�ܰ�
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "�� ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>";
        }
        else if (currentLevel == 3) //3�ܰ�
        {
            
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "�� ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>" + "�� ";
            m[2] = "<color=#d85b00>" + OrderMenu3 + "</color>";

        }
        else if (currentLevel == 4) //4�ܰ�
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "�� ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>" + "�� ";
            m[2] = "<color=#d85b00>" + OrderMenu3 + "</color>";
        }
        else if (currentLevel == 5) //5�ܰ�
        {
            m[0] = "<color=#d85b00>" + OrderMenu1 + "</color>" + "�� ";
            m[1] = "<color=#d85b00>" + OrderMenu2 + "</color>" + "�� ";
            m[2] = "<color=#d85b00>" + OrderMenu3 + "</color>" + "�� ";
            m[3] = "<color=#d85b00>" + OrderMenu4 + "</color>";
        }
        StartCoroutine(_typing2());
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for(int i=0; i<= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < 4; i++)
        {
            talkText.text += m[i];
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 5; i++)
        {
            talkText.text += m_[i];
            yield return new WaitForSeconds(0.07f);
        }
    }
    public void SceneMove()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("MemorizeMenu");
    }
}
