using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderHelp : MonoBehaviour
{
    public GameObject popupHelp;
    public Text helpText;
    //string menu = "";

    string hint = "";
    string hint1;
    string hint2;
    string hint3;
    string hint4;

    void Start()
    {
        hint1 = "";
        hint2 = "";
        hint3 = "";
        hint4 = "";

        //���ڿ� ���̷� �޴����� �Ǵ�
        if (GameManager.OrderMenu3.Length > 2 && GameManager.OrderMenu4.Length < 2) //�޴� 3��
        {
            FindHint(GameManager.OrderMenu1);
            hint1 = hint;
            FindHint(GameManager.OrderMenu2);
            hint2 = hint;
            FindHint(GameManager.OrderMenu3);
            hint3 = hint;
        }
        else if (GameManager.OrderMenu4.Length > 2) //�޴� 4��
        {
            FindHint(GameManager.OrderMenu1);
            hint1 = hint;
            FindHint(GameManager.OrderMenu2);
            hint2 = hint;
            FindHint(GameManager.OrderMenu3);
            hint3 = hint;
            FindHint(GameManager.OrderMenu4);
            hint4 = hint;
        }
        else //�޴� 2��
        {
            FindHint(GameManager.OrderMenu1);
            hint1 = hint;
            FindHint(GameManager.OrderMenu2);
            hint2 = hint;
        }

        helpText.text += hint1 + "\n" + hint2 + "\n" + hint3 + "\n" + hint4;
    }
    
    void Update()
    {
        
    }

    void FindHint(string menu)
    {
        switch (menu)
        {
            case "������ �Ƹ޸�ī��":
                hint = "������ ����������";
                break;
            case "���̽� �Ƹ޸�ī��":
                hint = "������ ����������";
                break;
            case "������ ī���":
                hint = "������ ��������";
                break;
            case "���̽� ī���":
                hint = "������ ��������";
                break;
            case "������ �ٴҶ��":
                hint = "������ ����������";
                break;
            case "���̽� �ٴҶ��":
                hint = "������ ����������";
                break;
            case "������ ī���ī":
                hint = "������ ��������";
                break;
            case "���̽� ī���ī":
                hint = "������ ��������";
                break;

            case "�⺻ �佺Ʈ":
                hint = "���� ������";
                break;
            case "���� �佺Ʈ":
                hint = "���� ������";
                break;
            case "���� �佺Ʈ":
                hint = "���� ������";
                break;
            case "��纣�� �佺Ʈ":
                hint = "�������� ������";
                break;
            case "���� ��纣�� �佺Ʈ":
                hint = "���� �������� ������";
                break;
            case "�ɳ� �佺Ʈ":
                hint = "���� ������";
                break;

            case "3�� ť������ũ":
                hint = "3�� ����������";
                break;
            case "4�� ť������ũ":
                hint = "4�� ����������";
                break;
            case "5�� ť������ũ":
                hint = "5�� ����������";
                break;
            case "6�� ť������ũ":
                hint = "6�� ����������";
                break;
            case "7�� ť������ũ":
                hint = "7�� ����������";
                break;
            case "8�� ť������ũ":
                hint = "8�� ����������";
                break;
        }
    }
}
