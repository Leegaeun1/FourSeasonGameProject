using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 10.0f;     // �����̴� �ӵ�. public���� �����Ͽ� ����Ƽ ȭ�鿡�� ������ �� �ִ�.
    float ry;
    float h, v;
    public float rotateSpeed=100.0f;
    bool isWalking = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ry=transform.eulerAngles.y;
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        

    }


    void FixedUpdate()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0, 0, v) * Speed * Time.deltaTime);
        ry += h * rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, ry, 0));

        colliderObject();
        Walking();

        // Point 2.
        //transform.position += new Vector3(-h, 0, -v) * Speed * Time.deltaTime;
    }
    void colliderObject()
    {
        Vector3 startPosition = transform.position + Vector3.up * 5f;
        Debug.DrawRay(startPosition, transform.forward * 10, Color.red);
        RaycastHit rayHit;

        if (Physics.Raycast(startPosition, transform.forward, out rayHit, 10, LayerMask.GetMask("Walls")))
        {
            print("�浹!");
            v = 0;
        }
    }
    void Walking()
    {
        if (h != 0 || v != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        anim.SetBool("isWalk", isWalking);
    }
}
