using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifyNumber : MonoBehaviour
{
    //OrderMenu1234�� �ϳ��� MakingMenu �迭�� �޴� ���� ���ڷ� ����(�ʱ�ȭ ���� 20�� ���� ������ȣ)
    public static int[] MakingMenu = { 20, 20, 20, 20 };
    //���� ��ȣ�� �޴��� �ֹ��� �ƴ��� �ȵƴ��� ����, ���� ��ȣ�� �� �Ʒ� �ּ�(�ϴ��� ��� �ȵ����� �ʱ�ȭ)
    public static bool[] MenuNumber = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};//���� ��ȣ�� �޴��� �ֹ��� �ƴ��� �ȵƴ��� ����, ���� ��ȣ�� �� �Ʒ� �ּ�



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

        //OrderMenu2 ����
        if (GameManager.OrderMenu2 == "������ �Ƹ޸�ī��")
        {
            MenuNumber[0] = true;
            MakingMenu[1] = 0;
        }
        else if (GameManager.OrderMenu2 == "���̽� �Ƹ޸�ī��")
        {
            MenuNumber[1] = true;
            MakingMenu[1] = 1;
        }
        else if (GameManager.OrderMenu2 == "������ ī���")
        {
            MenuNumber[2] = true;
            MakingMenu[1] = 2;
        }
        else if (GameManager.OrderMenu2 == "���̽� ī���")
        {
            MenuNumber[3] = true;
            MakingMenu[1] = 3;
        }
        else if (GameManager.OrderMenu2 == "������ �ٴҶ��")
        {
            MenuNumber[4] = true;
            MakingMenu[1] = 4;
        }
        else if (GameManager.OrderMenu2 == "���̽� �ٴҶ��")
        {
            MenuNumber[5] = true;
            MakingMenu[1] = 5;
        }
        else if (GameManager.OrderMenu2 == "������ ī���ī")
        {
            MenuNumber[6] = true;
            MakingMenu[1] = 6;
        }
        else if (GameManager.OrderMenu2 == "���̽� ī���ī")
        {
            MenuNumber[7] = true;
            MakingMenu[1] = 7;
        }
        else if (GameManager.OrderMenu2 == "�⺻ �佺Ʈ")
        {
            MenuNumber[8] = true;
            MakingMenu[1] = 8;
        }
        else if (GameManager.OrderMenu2 == "���� �佺Ʈ")//
        {
            MenuNumber[9] = true;
            MakingMenu[1] = 9;
        }
        else if (GameManager.OrderMenu2 == "���� �佺Ʈ")
        {
            MenuNumber[10] = true;
            MakingMenu[1] = 10;
        }
        else if (GameManager.OrderMenu2 == "��纣�� �佺Ʈ")
        {
            MenuNumber[11] = true;
            MakingMenu[1] = 11;
        }
        else if (GameManager.OrderMenu2 == "���� ���� �佺Ʈ")
        {
            MenuNumber[12] = true;
            MakingMenu[1] = 12;
        }
        else if (GameManager.OrderMenu2 == "�ɳ� �佺Ʈ")
        {
            MenuNumber[13] = true;
            MakingMenu[1] = 13;
        }
        else if (GameManager.OrderMenu2 == "3�� ť������ũ")
        {
            MenuNumber[14] = true;
            MakingMenu[1] = 14;
        }
        else if (GameManager.OrderMenu2 == "4�� ť������ũ")
        {
            MenuNumber[15] = true;
            MakingMenu[1] = 15;
        }
        else if (GameManager.OrderMenu2 == "5�� ť������ũ")
        {
            MenuNumber[16] = true;
            MakingMenu[1] = 16;
        }
        else if (GameManager.OrderMenu2 == "6�� ť������ũ")
        {
            MenuNumber[17] = true;
            MakingMenu[1] = 17;
        }
        else if (GameManager.OrderMenu2 == "7�� ť������ũ")
        {
            MenuNumber[18] = true;
            MakingMenu[1] = 18;
        }
        else if (GameManager.OrderMenu2 == "8�� ť������ũ")
        {
            MenuNumber[19] = true;
            MakingMenu[1] = 19;
        }

        //OrderMenu3 ����
        if (GameManager.OrderMenu3 == "������ �Ƹ޸�ī��")
        {
            MenuNumber[0] = true;
            MakingMenu[2] = 0;
        }
        else if (GameManager.OrderMenu3 == "���̽� �Ƹ޸�ī��")
        {
            MenuNumber[1] = true;
            MakingMenu[2] = 1;
        }
        else if (GameManager.OrderMenu3 == "������ ī���")
        {
            MenuNumber[2] = true;
            MakingMenu[2] = 2;
        }
        else if (GameManager.OrderMenu3 == "���̽� ī���")
        {
            MenuNumber[3] = true;
            MakingMenu[2] = 3;
        }
        else if (GameManager.OrderMenu3 == "������ �ٴҶ��")
        {
            MenuNumber[4] = true;
            MakingMenu[2] = 4;
        }
        else if (GameManager.OrderMenu3 == "���̽� �ٴҶ��")
        {
            MenuNumber[5] = true;
            MakingMenu[2] = 5;
        }
        else if (GameManager.OrderMenu3 == "������ ī���ī")
        {
            MenuNumber[6] = true;
            MakingMenu[2] = 6;
        }
        else if (GameManager.OrderMenu3 == "���̽� ī���ī")
        {
            MenuNumber[7] = true;
            MakingMenu[2] = 7;
        }
        else if (GameManager.OrderMenu3 == "�⺻ �佺Ʈ")
        {
            MenuNumber[8] = true;
            MakingMenu[2] = 8;
        }
        else if (GameManager.OrderMenu3 == "���� �佺Ʈ")//
        {
            MenuNumber[9] = true;
            MakingMenu[2] = 9;
        }
        else if (GameManager.OrderMenu3 == "���� �佺Ʈ")
        {
            MenuNumber[10] = true;
            MakingMenu[2] = 10;
        }
        else if (GameManager.OrderMenu3 == "��纣�� �佺Ʈ")
        {
            MenuNumber[11] = true;
            MakingMenu[2] = 11;
        }
        else if (GameManager.OrderMenu3 == "���� ���� �佺Ʈ")
        {
            MenuNumber[12] = true;
            MakingMenu[2] = 12;
        }
        else if (GameManager.OrderMenu3 == "�ɳ� �佺Ʈ")
        {
            MenuNumber[13] = true;
            MakingMenu[2] = 13;
        }
        else if (GameManager.OrderMenu3 == "3�� ť������ũ")
        {
            MenuNumber[14] = true;
            MakingMenu[2] = 14;
        }
        else if (GameManager.OrderMenu3 == "4�� ť������ũ")
        {
            MenuNumber[15] = true;
            MakingMenu[2] = 15;
        }
        else if (GameManager.OrderMenu3 == "5�� ť������ũ")
        {
            MenuNumber[16] = true;
            MakingMenu[2] = 16;
        }
        else if (GameManager.OrderMenu3 == "6�� ť������ũ")
        {
            MenuNumber[17] = true;
            MakingMenu[2] = 17;
        }
        else if (GameManager.OrderMenu3 == "7�� ť������ũ")
        {
            MenuNumber[18] = true;
            MakingMenu[2] = 18;
        }
        else if (GameManager.OrderMenu3 == "8�� ť������ũ")
        {
            MenuNumber[19] = true;
            MakingMenu[2] = 19;
        }

        //OrderMenu4 ����
        if (GameManager.OrderMenu4 == "������ �Ƹ޸�ī��")
        {
            MenuNumber[0] = true;
            MakingMenu[3] = 0;
        }
        else if (GameManager.OrderMenu4 == "���̽� �Ƹ޸�ī��")
        {
            MenuNumber[1] = true;
            MakingMenu[3] = 1;
        }
        else if (GameManager.OrderMenu4 == "������ ī���")
        {
            MenuNumber[2] = true;
            MakingMenu[3] = 2;
        }
        else if (GameManager.OrderMenu4 == "���̽� ī���")
        {
            MenuNumber[3] = true;
            MakingMenu[3] = 3;
        }
        else if (GameManager.OrderMenu4 == "������ �ٴҶ��")
        {
            MenuNumber[4] = true;
            MakingMenu[3] = 4;
        }
        else if (GameManager.OrderMenu4 == "���̽� �ٴҶ��")
        {
            MenuNumber[5] = true;
            MakingMenu[3] = 5;
        }
        else if (GameManager.OrderMenu4 == "������ ī���ī")
        {
            MenuNumber[6] = true;
            MakingMenu[3] = 6;
        }
        else if (GameManager.OrderMenu4 == "���̽� ī���ī")
        {
            MenuNumber[7] = true;
            MakingMenu[3] = 7;
        }
        else if (GameManager.OrderMenu4 == "�⺻ �佺Ʈ")
        {
            MenuNumber[8] = true;
            MakingMenu[3] = 8;
        }
        else if (GameManager.OrderMenu4 == "���� �佺Ʈ")//
        {
            MenuNumber[9] = true;
            MakingMenu[3] = 9;
        }
        else if (GameManager.OrderMenu4 == "���� �佺Ʈ")
        {
            MenuNumber[10] = true;
            MakingMenu[3] = 10;
        }
        else if (GameManager.OrderMenu4 == "��纣�� �佺Ʈ")
        {
            MenuNumber[11] = true;
            MakingMenu[3] = 11;
        }
        else if (GameManager.OrderMenu4 == "���� ���� �佺Ʈ")
        {
            MenuNumber[12] = true;
            MakingMenu[3] = 12;
        }
        else if (GameManager.OrderMenu4 == "�ɳ� �佺Ʈ")
        {
            MenuNumber[13] = true;
            MakingMenu[3] = 13;
        }
        else if (GameManager.OrderMenu4 == "3�� ť������ũ")
        {
            MenuNumber[14] = true;
            MakingMenu[3] = 14;
        }
        else if (GameManager.OrderMenu4 == "4�� ť������ũ")
        {
            MenuNumber[15] = true;
            MakingMenu[3] = 15;
        }
        else if (GameManager.OrderMenu4 == "5�� ť������ũ")
        {
            MenuNumber[16] = true;
            MakingMenu[3] = 16;
        }
        else if (GameManager.OrderMenu4 == "6�� ť������ũ")
        {
            MenuNumber[17] = true;
            MakingMenu[3] = 17;
        }
        else if (GameManager.OrderMenu4 == "7�� ť������ũ")
        {
            MenuNumber[18] = true;
            MakingMenu[3] = 18;
        }
        else if (GameManager.OrderMenu4 == "8�� ť������ũ")
        {
            MenuNumber[19] = true;
            MakingMenu[3] = 19;
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
