using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    public Animator animator;
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public void PopUp() //�Ϲ��˾���
    {
        popup.SetActive(true);
        animator.SetTrigger("pop");
    }
    public void PopUp2() //�����ǿ�(Ÿ�̸�����)
    {
        popup.SetActive(true);
        animator.SetTrigger("pop2");
    }


}
