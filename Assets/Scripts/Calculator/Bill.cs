using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bill : MonoBehaviour
{
    //�޴� ���� 1~4 �迭 �ֱ� ���� ����
    [SerializeField] Text[] menu_price_;
    //�޴� �̸� 1~4 �迭 �ֱ� ���� ����
    [SerializeField] Text[] menu_;
    //1���ڸ���~10000���ڸ��� ����
    [SerializeField] Text sum_1;
    [SerializeField] Text sum_10;
    [SerializeField] Text sum_100;
    [SerializeField] Text sum_1000;
    [SerializeField] Text sum_10000;

    public GameObject popupStart;
    //�¾��� �� �˾�
    public GameObject sign_yes;
    //�ѹ� Ʋ���� ��/ �ι� Ʋ���� �� / 3, 4�� Ʋ���� �� / 5�� �̻� Ʋ���� �� �˾�
    public GameObject[] sign_no_;
    //Calculator ��������
    private Calculator cal;
    //menu1~4 ��� ��(����)
    string sum_doing = "";
    //Ʋ�� Ƚ��
    int wrong_count = 0;
    //�޴� ���� ���� ����
    string menu_price = "";

    //AudioClip �Ҹ�
    public AudioClip click;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public GameObject black_screen;//���� ȭ��

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartPopup", 0.5f);

        cal = GameObject.Find("Calculator").GetComponent<Calculator>();

        //����� ������Ʈ ��������
        audioSrc = GetComponent<AudioSource>();

        //���ڿ� ���̷� �޴����� �Ǵ��ؼ� �޴� �̸� �� ���� ������ �ִ� ����
        if (GameManager.OrderMenu3.Length > 2 && GameManager.OrderMenu4.Length < 2) //�޴� 3��
        {
            FindPrice(GameManager.OrderMenu1);
            menu_price_[0].text = menu_price;
            menu_[0].text = GameManager.OrderMenu1;

            FindPrice(GameManager.OrderMenu2);
            menu_price_[1].text = menu_price;
            menu_[1].text = GameManager.OrderMenu2;

            FindPrice(GameManager.OrderMenu3);
            menu_price_[2].text = menu_price;
            menu_[2].text = GameManager.OrderMenu3;
        }
        else if (GameManager.OrderMenu4.Length > 2) //�޴� 4��
        {
            FindPrice(GameManager.OrderMenu1);
            menu_price_[0].text = menu_price;
            menu_[0].text = GameManager.OrderMenu1;

            FindPrice(GameManager.OrderMenu2);
            menu_price_[1].text = menu_price;
            menu_[1].text = GameManager.OrderMenu2;

            FindPrice(GameManager.OrderMenu3);
            menu_price_[2].text = menu_price;
            menu_[2].text = GameManager.OrderMenu3;

            FindPrice(GameManager.OrderMenu4);
            menu_price_[3].text = menu_price;
            menu_[3].text = GameManager.OrderMenu4;
        }
        else //�޴� 2��
        {
            FindPrice(GameManager.OrderMenu1);
            menu_price_[0].text = menu_price;
            menu_[0].text = GameManager.OrderMenu1;

            FindPrice(GameManager.OrderMenu2);
            menu_price_[1].text = menu_price;
            menu_[1].text = GameManager.OrderMenu2;
        }

        sum_doing = (int.Parse(menu_price_[0].text) + int.Parse(menu_price_[1].text) + int.Parse(menu_price_[2].text) + int.Parse(menu_price_[3].text)).ToString();

        //�� ������ 10000���� ���� �ʴ´ٸ� 10000�� �ڸ� ��ĭ ��� ���ֱ�
        if (int.Parse(sum_doing) < 10000)
        {
            sum_10000.text = null;
        }
        //������ 0�� ���� ��ĭ �����
        for (int i = 0; i < 4; i++)
        {
            if (int.Parse(menu_price_[i].text) < 1)
            {
                menu_price_[i].text = "";
            }
        }
    }
    void StartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp();
    }

    void FindPrice(string menu)
    {
        switch (menu)
        {
            case "������ �Ƹ޸�ī��":
                menu_price = "2000";
                break;
            case "���̽� �Ƹ޸�ī��":
                menu_price = "2000";
                break;
            case "������ ī���":
                menu_price = "3000";
                break;
            case "���̽� ī���":
                menu_price = "3500";
                break;
            case "������ �ٴҶ��":
                menu_price = "4200";
                break;
            case "���̽� �ٴҶ��":
                menu_price = "4700";
                break;
            case "������ ī���ī":
                menu_price = "5100";
                break;
            case "���̽� ī���ī":
                menu_price = "5600";
                break;

            case "�⺻ �佺Ʈ":
                menu_price = "1000";
                break;
            case "���� �佺Ʈ":
                menu_price = "2000";
                break;
            case "���� �佺Ʈ":
                menu_price = "2500";
                break;
            case "��纣�� �佺Ʈ":
                menu_price = "2500";
                break;
            case "���� ���� �佺Ʈ":
                menu_price = "2700";
                break;
            case "�ɳ� �佺Ʈ":
                menu_price = "2900";
                break;

            case "3�� ť������ũ":
                menu_price = "5000";
                break;
            case "4�� ť������ũ":
                menu_price = "6500";
                break;
            case "5�� ť������ũ":
                menu_price = "7900";
                break;
            case "6�� ť������ũ":
                menu_price = "9200";
                break;
            case "7�� ť������ũ":
                menu_price = "10400";
                break;
            case "8�� ť������ũ":
                menu_price = "11500";
                break;
        }
    }

    //���� Ȯ�� ��ư ������ �¾Ҵ��� ��
    public void Compare()
    {
        if (cal.InputField.text == sum_doing)//�����̶��
        {
            //1, 10, 100, 1000, 10000���ڸ� �� ���� ǥ��
            sum_1.text = (int.Parse(sum_doing) % 10).ToString();//�׳� '0'�̶� �ص� ��
            sum_10.text = ((int.Parse(sum_doing) % 100) / 10).ToString();
            sum_100.text = ((int.Parse(sum_doing) % 1000) / 100).ToString();
            sum_1000.text = ((int.Parse(sum_doing) % 10000) / 1000).ToString();
            if (int.Parse(sum_doing) >= 10000)
            {
                sum_10000.text = (int.Parse(sum_doing) / 10000).ToString();
            }

            //sum_Result.text = sum_doing;
            sign_yes.SetActive(true);
            //StartCoroutine(WaitForYes());

            audioSrc.PlayOneShot(correct, 0.5f);
            black_screen.SetActive(true);
        }
        else//Ʋ�ȴٸ�
        {
            cal.InputField.text = "0";//�ؽ�Ʈ �ʵ� 0����
            wrong_count++;//Ʋ�� �� ����
            if (wrong_count == 1)//�ѹ� Ʋ���� �׳� �ٽ��϶�� ��
            {
                sign_no_[0].SetActive(true);//�ѹ� Ʋ�� �˾�
                MoveLevel.wrongCount += 1;
                //StartCoroutine(WaitForNo(0));
            }
            else if (wrong_count == 2)//�ι� Ʋ���� 1000�� �ڸ��� �˷���
            {
                sign_no_[1].SetActive(true);//�ι� Ʋ�� �˾�
                //StartCoroutine(WaitForNo(1));
                sum_1000.text = ((int.Parse(sum_doing) % 10000) / 1000).ToString();
            }
            else if (wrong_count == 3)//���� Ʋ���� 100���ڸ� �� �˷���
            {
                sign_no_[2].SetActive(true);//3, 4�� Ʋ�� �˾�
                //StartCoroutine(WaitForNo(2));
                sum_100.text = ((int.Parse(sum_doing) % 1000) / 100).ToString();
            }
            else if (wrong_count == 4)//�׹� Ʋ���� 10���ڸ� �� �˷���
            {
                sign_no_[2].SetActive(true);//3, 4�� Ʋ�� �˾�
                //StartCoroutine(WaitForNo(2));
                sum_10.text = ((int.Parse(sum_doing) % 100) / 10).ToString();
            }
            else if (wrong_count == 5)//�ټ��� Ʋ���� 1���ڸ� ��, 10000���� Ŭ �� 10000���ڸ� �� ���� �˷���
            {
                sign_no_[3].SetActive(true);//�ټ��� �̻� Ʋ�� �˾�
                //StartCoroutine(WaitForNo(3));
                sum_1.text = (int.Parse(sum_doing) % 10).ToString();
                if (int.Parse(sum_doing) >= 10000)
                {
                    sum_10000.text = (int.Parse(sum_doing) / 10000).ToString();
                }

            }
            else//�ټ��� �Ѱ� Ʋ���� ���� ���������� ������
            {
                sign_no_[3].SetActive(true);//�ټ��� �̻� Ʋ�� �˾�
                //StartCoroutine(WaitForNo(3));
                sum_1.text = "<color=#D85B00>" + sum_1.text + "</color>";
                sum_10.text = "<color=#D85B00>" + sum_10.text + "</color>";
                sum_100.text = "<color=#D85B00>" + sum_100.text + "</color>";
                sum_1000.text = "<color=#D85B00>" + sum_1000.text + "</color>";
                sum_10000.text = "<color=#D85B00>" + sum_10000.text + "</color>";
            }

            audioSrc.PlayOneShot(wrong, 0.5f);
            black_screen.SetActive(true);
        }

    }

    //�ݱ� ��ư ���� ��
    public void Close_No(int num)
    {
        sign_no_[num].SetActive(false);
        audioSrc.PlayOneShot(click, 0.5f);
        black_screen.SetActive(false);
    }

    public void NextScene()
    {
        //�� �Ѿ�� �ڵ�
    }
    /*
    IEnumerator WaitForYes()
    {
        yield return new WaitForSeconds(3.0f);
        //�� �Ѿ�� �ڵ�

    }
    
    IEnumerator WaitForNo(int num)
    {
        yield return new WaitForSeconds(3.0f);
        sign_no_[num].SetActive(false);
    }
    */



    // Update is called once per frame
    void Update()
    {

    }
}
