using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // �Ω󤣦P�������e������, �z�L�I���S�w���~�Ӥ����ҹw�]�������s��

    // �Ψ��ಾ�Ϊ����X(�O�o���N�Q�����ܪ�������JBulid Setting)
    public int SceneNumber;
    void Start()
    {
        
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �I���쪺�Otag��Player�� 2D���󪺸�
        if (other.CompareTag("Player"))
        {
            // SceneManager.LoadScene("�����W��"); ���O����K�������٬O��SceneNumber
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
