using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPopup : MonoBehaviour
{
    //���� ���ô� �˾�
    //public GameObject BringUpPopup;
    //�������ִ� �˾�
    //public GameObject ExplainPopup;
    public GameObject popupStart;

    public void ShowExplainPopup()
    {
        //BringUpPopup.SetActive(false);
        //ExplainPopup.SetActive(true);
    }
    public void CloseExplainPopup()
    {
        //ExplainPopup.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowStartPopup", 0.5f);
    }
    void ShowStartPopup()
    {
        Popup pop = popupStart.GetComponent<Popup>();
        pop.PopUp2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
