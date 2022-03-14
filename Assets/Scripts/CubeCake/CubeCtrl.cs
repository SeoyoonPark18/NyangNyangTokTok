using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    //ť������ũ�� �ؽ�ó�� ������ �迭
    public Texture[] textures;
    //meshRenderer ������Ʈ�� ������ ����
    private MeshRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        //MeshRenderer ������Ʈ�� ������ ����
        _renderer = GetComponent<MeshRenderer>();
        //������ �߻����� �ұ�Ģ���� �ؽ�ó�� ����
        _renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
