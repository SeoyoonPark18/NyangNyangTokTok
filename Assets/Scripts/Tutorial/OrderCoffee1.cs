using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OrderCoffee1 : MonoBehaviour
{
    string ClickedMenu;
    public List<string> _list = new List<string>();
    public GameObject[] Slot = new GameObject[4];
    public GameObject[] cancleBtn = new GameObject[4];

    public GameObject popupCorrect;
    public GameObject popupWrong;

    public AudioClip click;
    public AudioClip popup;
    public AudioClip correct;
    public AudioClip wrong;
    AudioSource audioSrc;

    public Text bossText;
    public GameObject bossPanel;
    public GameObject boss;
    private string m_text;
    public GameObject focus_hint;
    public GameObject focus_c;
    int i = 0;
    int cnt = 0;

    void Start()
    {
        ClickedMenu = "";
        audioSrc = GetComponent<AudioSource>();
        Invoke("BossTalk", 1f);
    }
    public void BossTalk()
    {
        if (i == 0)
        {
            m_text = "���� ��� �ܿ� �޴����� �����⿡ ��� �´��� Ȯ���� �� �ſ���~";
            StartCoroutine(_typing());
            i++;
        }
        else if (i == 1)
        {
            m_text = "��� �ܿ� �޴� �� 'Ŀ��' �޴��� ���� ����ּ���!";
            StartCoroutine(_typing());
            i++;
        }
        else if (i == 2)
        {
            boss.SetActive(false);
            focus_hint.SetActive(true);
            m_text = "����� �� ���� �ʴ´ٸ� '����' ��ư�� ���� �ʼ� ��Ʈ�� Ȯ���� �� �־��";
            StartCoroutine(_typing());
            i++;
        }
        else if (i == 3)
        {
            bossPanel.SetActive(false);
            focus_hint.SetActive(false);
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

    void Update()
    {

    }


    public void MenuClickedBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        ClickedMenu = clickObject.GetComponentInChildren<Text>().text;

        if (_list.Count < 4)
        {
            _list.Add(ClickedMenu); //����Ʈ�� string Ÿ��
            FreshSlot();
        }
        if (cnt == 0)
        {
            focus_c.SetActive(true);
            cnt++;
        }
    }
    public void CancledBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);

        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject.tag == "slot1")
        {
            _list.RemoveAt(0);
            FreshSlot();
        }
        else if (clickObject.tag == "slot2")
        {
            _list.RemoveAt(1);
            FreshSlot();
        }
        else if (clickObject.tag == "slot3")
        {
            _list.RemoveAt(2);
            FreshSlot();
        }
        else if (clickObject.tag == "slot4")
        {
            _list.RemoveAt(3);
            FreshSlot();
        }

    }
    void FreshSlot()
    {
        int i = 0;
        for (; i < _list.Count && i < 4; i++)
        {
            Slot[i].GetComponentInChildren<Text>().text = _list[i];
            cancleBtn[i].SetActive(true);
        }
        for (; i < 4; i++)
        {
            Slot[i].GetComponentInChildren<Text>().text = null;
            cancleBtn[i].SetActive(false);
        }
    }

    public void ConfirmMenu()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        focus_c.SetActive(false);

        if(_list.Count == 0)
        {
            popupWrong.SetActive(true);
            audioSrc.PlayOneShot(wrong, 0.5f);
        }
        if (_list.Count == 1 && _list.Contains(GameManager1.OrderMenu1))
        {
            //�����̶��
            popupCorrect.SetActive(true);
            audioSrc.PlayOneShot(correct, 0.5f);
        }
        else if (_list.Contains(GameManager1.OrderMenu1))
        {
            int idxCoffee = _list.FindIndex(coffee => coffee.Contains(GameManager1.OrderMenu1));
            for (int i = 0; i < _list.Count; i++)
            {
                if (i != idxCoffee)
                {
                    //������ �ִٸ�
                    popupWrong.SetActive(true);
                    audioSrc.PlayOneShot(wrong, 0.5f);
                    Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                    //�������� �߰� �ʿ�
                }
            }
        }
        else
        {
            for (int i = 0; i < _list.Count; i++)
            {
                popupWrong.SetActive(true);
                audioSrc.PlayOneShot(wrong, 0.5f);
                Slot[i].GetComponentInChildren<Text>().text = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                _list[i] = "<color=#ff0000>" + Slot[i].GetComponentInChildren<Text>().text + "</color>";
                //�������� �߰� �ʿ�
            }
        }
        

    }
    public void NextBtn()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("T_OrderCube");
    }

    public void ClickSound()
    {
        audioSrc.PlayOneShot(click, 0.5f);
    }
    public void PopupSound()
    {
        audioSrc.PlayOneShot(popup, 0.5f);
    }
    public void CorretSound()
    {
        audioSrc.PlayOneShot(correct, 0.5f);
    }
    public void WrongSound()
    {
        audioSrc.PlayOneShot(wrong, 0.5f);
    }
}