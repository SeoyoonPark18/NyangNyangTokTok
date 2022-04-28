using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour
{
    [SerializeField] string email;
    [SerializeField] string password;
    //private int level;

    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public Text loginResult;

    //�˾�â
    public GameObject popup_board;
    public GameObject popup_board_join;
    //�˾� �޽���
    public Text popup_message;
    public Text popup_message_join;
    //���� ȭ��
    public GameObject black_screen;
    //���� ���� ��ư
    public GameObject gamestart_btn;

    //AudioClip �Ҹ�
    public AudioClip click;
    public AudioClip popup;
    AudioSource audioSrc;

    //private bool ok = true;

    //private bool yes_or_no;

    public static FirebaseAuth auth;//���������� �ٸ� ��ũ��Ʈ���� �������� ���� ������ public static���� ����

    public static FirebaseUser user;

    //��������
     bool startBtnDown;
     bool loginBtnDown;
    

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);

        //����� ������Ʈ ��������
        audioSrc = GetComponent<AudioSource>();

        


    }


    public int count = 1; //����

    private void Update()
    {
        //����
        if (startBtnDown)
        {
            SceneManager.LoadScene("IceCafeMocha");
        }


    }
    //����
    public void gameStartPressed()
    {
        startBtnDown = true;
    }



    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.Email);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.Email);
            }
        }
    }


    //ȸ������ ��ư�� ������ ������ �Լ�.
    public void JoinBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;
        //level = 1;

        Debug.Log("email: " + email + ", password: " + password);
        popup_message_join.text = email + "�� \n ȸ������ ����~!\n�α��� �� ������ �̿����ּ���";
        CreateUser();
        //1�� �ڿ� �˾�â ����(CreateUser() �� �ð� ����... �߸� ����...)
        StartCoroutine(WaitForJoin());

    }

    //ȸ������
    void CreateUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                popup_message_join.text = "�α��� ������ �߸��Ǿ��ų� \n �̹� ������ �̸����Դϴ�";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                popup_message_join.text = "�α��� ������ �߸��Ǿ��ų� \n �̹� ������ �̸����Դϴ�";
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }


    

    //�α��� ��ư�� ������ ������ �Լ�.
    public void LoginBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;

        Debug.Log("email: " + email + ", password: " + password);
        popup_message.text = "�α��� ����~! \n��ſ� ���� �Ǽ����";//23����
        LoginUser();
        //1�� �ڿ� �˾�â ����(LoginUser() �� �ð� ����)
        StartCoroutine(WaitForSeconds());
        
    }

    //�α���
    void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                popup_message.text = "��й�ȣ�� �߸��Ǿ��ų� \n���Ե��� ���� �̸����Դϴ�";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                popup_message.text = "��й�ȣ�� �߸��Ǿ��ų� \n���Ե��� ���� �̸����Դϴ�";
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    IEnumerator WaitForSeconds()
    {
        //audioSrc.PlayOneShot(popup, 0.5f);
        yield return new WaitForSeconds(1.0f);
        popup_board.SetActive(true);
        black_screen.SetActive(true);
        if (popup_message.text.Length < 24)
        {
            gamestart_btn.SetActive(true);
        }

    }

    IEnumerator WaitForJoin()
    {
        audioSrc.PlayOneShot(popup, 0.5f);
        yield return new WaitForSeconds(1.0f);
        popup_board_join.SetActive(true);
        black_screen.SetActive(true);
    }

    public void ClosePopup()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        popup_board.SetActive(false);
        black_screen.SetActive(false);
    }

    public void ClosePopupJoin()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        popup_board_join.SetActive(false);
        black_screen.SetActive(false);
    }

    public void GameStart()
    {
        audioSrc.PlayOneShot(click, 0.5f);
        SceneManager.LoadScene("Start");
    }

}


