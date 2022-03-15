using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCtrl : MonoBehaviour
{
    //���� ��� �� ����� ������
    public Text question;
    //���� ������ ���� ����
    private int random;

    //ī�޶� ����Ʈ(��������)
    public List<Camera> CameraList = new List<Camera>();
    //��ư ����Ʈ(��������)
    public List<Button> ButtonList = new List<Button>();
    //Ʋ���� �� �������� ȸ�� �̹��� ����Ʈ(��������)
    public List<Image> NoneList = new List<Image>();

    //ī�޶� ��ġ ����Ʈ
    public List<Rect> RectList = new List<Rect>() {
        new Rect(0.5f, 0.5f, 0.25f, 0.5f), new Rect(0.5f, 0, 0.25f, 0.5f), new Rect(0.75f, 0, 0.25f, 0.5f), new Rect(0.75f, 0.5f, 0.25f, 0.5f)};

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<4; i++)
        {
            int rand = Random.Range(0, RectList.Count);
            CameraList[i].rect = RectList[rand];
            RectList.RemoveAt(rand);
        }
        random = Random.Range(0, 4);
        RandAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandAnswer()
    {
        if(random == 0)
        {
            question.text = "�տ��� �� ����� ������.";
        }else if(random == 1)
        {
            question.text = "���ʿ��� �� ����� ������.";
        }
        else if (random == 2)
        {
            question.text = "�����ʿ��� �� ����� ������.";
        }
        else if (random == 3)
        {
            question.text = "������ �� ����� ������.";
        }
    }
}
