using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Bill1 : MonoBehaviour
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
    //string menu_price = "";

    //AudioClip �Ҹ�
    public AudioClip click;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public GameObject black_screen;//���� ȭ��

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus1;
    public GameObject focus2;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BossTalk", 1f);

        cal = GameObject.Find("Calculator").GetComponent<Calculator>();

        //����� ������Ʈ ��������
        audioSrc = GetComponent<AudioSource>();

        //���ڿ� ���̷� �޴����� �Ǵ��ؼ� �޴� �̸� �� ���� ������ �ִ� ����
        menu_price_[0].text = "2000";
        menu_[0].text = GameManager1.OrderMenu1; //�ƾ�

        menu_price_[1].text = "5000";
        menu_[1].text = GameManager1.OrderMenu2;//3��


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
    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "���� �ֹ� ���� �޴����� �� ������ ����� �� �ſ���!";
            StartMethod();
            i++;
        }
        else if (i == 1)
        {
            StopMethod();
            boss.SetActive(false);
            focus1.SetActive(true); //��꼭
            m_text = "��꼭�� ���� �޴��� ������ ��� ���ؼ� ���ڸ� �Է����ּ���~";
            StartMethod();
            i++;
        }
        else if (i == 2)
        {
            
            focus1.SetActive(false);
            bossPanel.SetActive(false);
        }
    }
    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            bossText.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator coroutine;
    void StartMethod()
    {
        coroutine = _typing();
        StartCoroutine(coroutine);
    }
    void StopMethod()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
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
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_IceAmericano");
    }

}
