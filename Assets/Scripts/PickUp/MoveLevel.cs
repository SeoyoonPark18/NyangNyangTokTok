using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase;
using Firebase.Auth;

public class MoveLevel : MonoBehaviour
{
    DatabaseReference databaseReference;

    public static int wrongCount = 0;

    public void MovingLevel()
    {
        if(wrongCount == 0)//�ѹ��� Ʋ���� �ʾ��� ��
        {
            GameManager.currentCount += 1;//ī��Ʈ �ø���
            if (GameManager.currentCount == 3)//ī��Ʈ�� 3 ä������ �� ���� �÷��� ��
            {
                if(GameManager.currentLevel < 5)//���� 5�� �ƴ� ��
                {
                    GameManager.currentLevel += 1;//���� ������ �ø���!
                    LevelUp(GameManager.currentLevel);//������ ���� ������Ʈ!
                    CountUp(0);//������ ī��Ʈ 0���� ������Ʈ! 3���� ���� ������ �� �ٽ� 0�� �Ǳ� ����
                    
                    //�˾� ����
                    
                }else if (GameManager.currentLevel == 5){//����5�ε� �� 3�� ī��Ʈ ä�� ���
                    //����� ��Ÿ���� ���ٴ� �λ�� �Բ� ����ش޶�� �޽��� ���ϱ�
                }
            }
            else//ī��Ʈ�� 1�̳� 2�� ä������ ��
            {
                CountUp(GameManager.currentCount);//������ ī��Ʈ ������Ʈ
                //�˾� ����
            }
        }
        else//�ѹ��̶� Ʋ���� ���ڱ�, ������ ����. ������̶� �λ��ϰ� ����ϱ⤡��
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //�����ϱ� ������ �������ϴ� �κп��� ������ ī��Ʈ �ø� �ڵ�
    public void CountUp(int count)
    {
        var DBTask = databaseReference.Child("users").Child("count").SetValueAsync(count);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //count is now updated
        }
    }

    //�����ϱ� ������ �������ϴ� �κп��� ������ ���� �ø� �ڵ�
    public void LevelUp(int level)
    {
        var DBTask = databaseReference.Child("users").Child("level").SetValueAsync(level);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //level is now updated
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
