using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextMenu : MonoBehaviour
{

    public int now = 0;//���� ����� �ִ� �޴��� ���° �޴�����
    public static List<int> num = new List<int>() { 0, 1, 2, 3 };
    //�� ������ ���� �޴� ������ �Ѿ�� �Լ�
    public void MoveNextMenuScene()
    {
        Debug.Log(num[0]);
        if (SpecifyNumber.MakingMenu[num[0]] > 19)//���� �޴��� ������ȣ�� ���� ���ߴٸ�
        {
            SceneManager.LoadScene("PickUpScene");//�����ϱ� ȭ������ �̵�
        }
        else//������ȣ�� �޾Ҵٸ�
        {
            for (int i = 0; i < 20; i++)//i�� �޴��� ������ȣ
            {
                if (SpecifyNumber.MakingMenu[num[0]] == i)//now+1��° �޴��� ������ȣ i �޴��� �޾Ҵٸ�
                {
                    if (i > 13)//14���� ť�� �޴� ������ȣ�̴�.
                    {
                        int[] randomList = { i, i + 6 };//ť��� ���� 2���̱� ������ �������� ������ ���� ����Ʈ
                        int rand = Random.Range(0, 2);
                        SceneManager.LoadScene(randomList[rand]+9);//�� ��ȣ�� ������ȣ + 9 �� �����ص״�.

                    }
                    else
                    {
                        SceneManager.LoadScene(i + 9);

                    }
                    
                }
            }
            Debug.Log(num[0]);
            num.RemoveAt(0);
            Debug.Log(num[0]);
            //Debug.Log(now);
            //now++;//���� �̵������� ���� ����� �ִ� �޴� ��ȣ�� +���ش�
            //Debug.Log(now);
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
