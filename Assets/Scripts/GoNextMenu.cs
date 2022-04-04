using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextMenu : MonoBehaviour
{

    public int now = 0;//���� ����� �ִ� �޴��� ���° �޴�����
    //�� ������ ���� �޴� ������ �Ѿ�� �Լ�
    public void MoveNextMenuScene()
    {
        if (SpecifyNumber.MakingMenu[now] > 19)//���� �޴��� ������ȣ�� ���� ���ߴٸ�
        {
            SceneManager.LoadScene("PickUpScene");//�����ϱ� ȭ������ �̵�
        }
        else//������ȣ�� �޾Ҵٸ�
        {
            for (int i = 0; i < 20; i++)//i�� �޴��� ������ȣ
            {
                if (SpecifyNumber.MakingMenu[now] == i)//now+1��° �޴��� ������ȣ i �޴��� �޾Ҵٸ�
                {
                    if (i > 13)//14���� ť�� �޴� ������ȣ�̴�.
                    {
                        int[] randomList = { i, i + 6 };//ť��� ���� 2���̱� ������ �������� ������ ���� ����Ʈ
                        int rand = Random.Range(0, 2);
                        now++;//���� �̵������� ���� ����� �ִ� �޴� ��ȣ�� +���ش�
                        SceneManager.LoadScene(randomList[rand + 9]);//�� ��ȣ�� ������ȣ + 9 �� �����ص״�.

                    }
                    else
                    {
                        now++;
                        SceneManager.LoadScene(i + 9);

                    }
                }
            }
        }
    }


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
