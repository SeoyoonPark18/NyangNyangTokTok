using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifyNumber : MonoBehaviour
{
    public static int[] MakingMenu;//OrderMenu1234�� �ϳ��� MakingMenu �迭�� �޴� ���� ���ڷ� ����
    public static bool[] MenuNumber;//���� ��ȣ�� �޴��� �ֹ��� �ƴ��� �ȵƴ��� ����, ���� ��ȣ�� �� �Ʒ� �ּ�



    // Start is called before the first frame update
    void Start()
    {
        //OrderMenu1 ����
        if (GameManager.OrderMenu1 == "������ �Ƹ޸�ī��")
        {
            MenuNumber[0] = true;
            MakingMenu[0] = 0;
        }
        else if (GameManager.OrderMenu1 == "���̽� �Ƹ޸�ī��")
        {
            MenuNumber[1] = true;
            MakingMenu[0] = 1;
        }
        else if (GameManager.OrderMenu1 == "������ ī���")
        {
            MenuNumber[2] = true;
            MakingMenu[0] = 2;
        }
        else if (GameManager.OrderMenu1 == "���̽� ī���")
        {
            MenuNumber[3] = true;
            MakingMenu[0] = 3;
        }
        else if (GameManager.OrderMenu1 == "������ �ٴҶ��")
        {
            MenuNumber[4] = true;
            MakingMenu[0] = 4;
        }
        else if (GameManager.OrderMenu1 == "���̽� �ٴҶ��")
        {
            MenuNumber[5] = true;
            MakingMenu[0] = 5;
        }
        else if (GameManager.OrderMenu1 == "������ ī���ī")
        {
            MenuNumber[6] = true;
            MakingMenu[0] = 6;
        }
        else if (GameManager.OrderMenu1 == "���̽� ī���ī")
        {
            MenuNumber[7] = true;
            MakingMenu[0] = 7;
        }
        else if (GameManager.OrderMenu1 == "�⺻ �佺Ʈ")
        {
            MenuNumber[8] = true;
            MakingMenu[0] = 8;
        }
        else if (GameManager.OrderMenu1 == "���� �佺Ʈ")//
        {
            MenuNumber[9] = true;
            MakingMenu[0] = 9;
        }
        else if (GameManager.OrderMenu1 == "���� �佺Ʈ")
        {
            MenuNumber[10] = true;
            MakingMenu[0] = 10;
        }
        else if (GameManager.OrderMenu1 == "��纣�� �佺Ʈ")
        {
            MenuNumber[11] = true;
            MakingMenu[0] = 11;
        }
        else if (GameManager.OrderMenu1 == "���� ���� �佺Ʈ")
        {
            MenuNumber[12] = true;
            MakingMenu[0] = 12;
        }
        else if (GameManager.OrderMenu1 == "�ɳ� �佺Ʈ")
        {
            MenuNumber[13] = true;
            MakingMenu[0] = 13;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



/*
0: ������ �Ƹ޸�ī��
1: ���̽� �Ƹ޸�ī��
2: ������ ī���
3: ���̽� ī���
4: ������ �ٴҶ��
5: ���̽� �ٴҶ��
6: ������ ī���ī
7: ���̽� ī���ī

8: �⺻ �佺Ʈ
9: ���� �佺Ʈ
10: ���� �佺Ʈ
11: ��纣�� �佺Ʈ
12: ���� ���� �佺Ʈ
13: �ɳ� �佺Ʈ

14: 3�� ť������ũ
15: 4�� ť������ũ
16: 5�� ť������ũ
17: 6�� ť������ũ
18: 7�� ť������ũ
19: 8�� ť������ũ
*/
