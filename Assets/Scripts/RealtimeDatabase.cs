using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;
using Firebase.Auth;

public class RealtimeDatabase : MonoBehaviour
{
    FirebaseApp firebaseApp;
    DatabaseReference databaseReference;

    // Start is called before the first frame update
    void Awake()
    {
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        firebaseApp.SetEditorDatabaseUrl("https://nyangnyang-2b3a0-default-rtdb.firebaseio.com/");
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;


        //FirebaseApp.DefaultInstance.SetEditorFileName("NyangNyang.p12");

        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
    }


    public void InitDatabase()
    {
        if (Login.user != null)
        {
            WriteNewUser(Login.user.UserId, Login.user.Email);
        }
    }
    
    private void WriteNewUser(string uid, string email)
    {
        User user = new User(email);
        string json = JsonUtility.ToJson(user);
        databaseReference.Child("users").Child(uid).SetRawJsonValueAsync(json);

        
    }



    public void LoadLevel()
    {
        //��״� �߰��ϴ� �ڵ�
        //string key = databaseReference.Child("level").Push().Key;
        //databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(level);

        //DB �������� 
        var DBTask1 = databaseReference.Child("users").Child(Login.user.UserId).OrderByChild("level").GetValueAsync();
        var DBTask2 = databaseReference.Child("users").Child(Login.user.UserId).OrderByChild("count").GetValueAsync();
        databaseReference.GetValueAsync().ContinueWith(task => {

            if (task.IsCompleted)
            { // ���������� �����͸� ����������
                DataSnapshot snapshot1 = DBTask1.Result;
                DataSnapshot snapshot2 = DBTask2.Result;
                // �����͸� ����ϰ��� �Ҷ��� Snapshot ��ü �����

                foreach (DataSnapshot childSnapshot in snapshot1.Children)
                {
                    //�����̶� ī��Ʈ snapshot���� �������� ������
                    int level = int.Parse(childSnapshot.Child("level").Value.ToString());
                    Debug.Log("���� ������");
                    GameManager.currentLevel = level;//������ ���� ���Ӹ޴��� ���� ������ ����
                    Debug.Log("���� ����");
                }
                foreach (DataSnapshot childSnapshot in snapshot2.Children)
                {
                    //�����̶� ī��Ʈ snapshot���� �������� ������
                    int count = int.Parse(childSnapshot.Child("count").Value.ToString());
                    Debug.Log("ī��Ʈ ������");
                    GameManager.currentCount = count;//������ ī��Ʈ ���Ӹ޴��� ���� ī��Ʈ�� ����
                    Debug.Log("ī��Ʈ ����");
                }
            }
        });
    }

    /*
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
    }*/

    public class User
    {
        //public string name;
        public string email;
        public int level;
        public int count;

        public User()
        {
        }

        public User(string email)
        {
            //this.name = name;
            this.email = email;
            this.level = 1;
            this.count = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
