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
    public void PopUp2() //����� ��ŸƮ��
    {
        popup.SetActive(true);
        animator.SetTrigger("spop");
    }
    public void PopUp3() //�ܿ�� ��ŸƮ
    {
        popup.SetActive(true);
        animator.SetTrigger("mpop");
    }
    public void PopUp4() //�޴����� ����
    {
        popup.SetActive(true);
        animator.SetTrigger("opop");
    }
    public void PopUp5() //ť�� ����
    {
        popup.SetActive(true);
        animator.SetTrigger("chpop");
    }

}
