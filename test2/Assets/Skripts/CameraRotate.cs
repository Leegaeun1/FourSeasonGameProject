using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed; // 회전구현 - 회전속도
    float tempX; // 회전구현 - 변수생성
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveY = Input.GetAxis("Mouse Y"); // 회전구현 - 위아래 움직임 숫자로 저장
        transform.Rotate(-mouseMoveY * rotateSpeed * Time.deltaTime, 0, 0); // 회전구현 - 마우스가 움직인 만큼 x축 회전
        if (transform.eulerAngles.x > 180) // 회전구현 - 만약 x의 각도가 180을 넘는다면
        {
            tempX = transform.eulerAngles.x - 360; // 회전구현 - 360을 빼서 음수로 저장
        }
        else // 회전구현 x의 각도가 180을 넘지 않는다면
        {
            tempX = transform.eulerAngles.x; // 회전구현 - 그대로 저장
        }
        tempX = Mathf.Clamp(tempX, -30, 30); // 회전구현 - 음수를 포함한 x의 각도를 -30 ~ 30도로 제한
        transform.eulerAngles = new Vector3(tempX, transform.eulerAngles.y, transform.eulerAngles.z); // 회전구현 - 제한된 값을 eulerAngles.x에 적용 
    }
}