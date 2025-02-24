using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed; // ȸ������ - ȸ���ӵ�
    float tempX; // ȸ������ - ��������
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveY = Input.GetAxis("Mouse Y"); // ȸ������ - ���Ʒ� ������ ���ڷ� ����
        transform.Rotate(-mouseMoveY * rotateSpeed * Time.deltaTime, 0, 0); // ȸ������ - ���콺�� ������ ��ŭ x�� ȸ��
        if (transform.eulerAngles.x > 180) // ȸ������ - ���� x�� ������ 180�� �Ѵ´ٸ�
        {
            tempX = transform.eulerAngles.x - 360; // ȸ������ - 360�� ���� ������ ����
        }
        else // ȸ������ x�� ������ 180�� ���� �ʴ´ٸ�
        {
            tempX = transform.eulerAngles.x; // ȸ������ - �״�� ����
        }
        tempX = Mathf.Clamp(tempX, -30, 30); // ȸ������ - ������ ������ x�� ������ -30 ~ 30���� ����
        transform.eulerAngles = new Vector3(tempX, transform.eulerAngles.y, transform.eulerAngles.z); // ȸ������ - ���ѵ� ���� eulerAngles.x�� ���� 
    }
}