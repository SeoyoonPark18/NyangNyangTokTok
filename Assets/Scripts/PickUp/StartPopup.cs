using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPopup : MonoBehaviour
{
    //���� ���ô� �˾�
    public GameObject BringUpPopup;
    //�������ִ� �˾�
    public GameObject ExplainPopup;


    public void ShowExplainPopup()
    {
        BringUpPopup.SetActive(false);
        ExplainPopup.SetActive(true);
    }
    public void CloseExplainPopup()
    {
        ExplainPopup.SetActive(false);
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
