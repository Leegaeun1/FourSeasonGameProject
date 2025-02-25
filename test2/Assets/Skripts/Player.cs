using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 20.0f;     // �����̴� �ӵ�
    float ry;
    float h, v;
    public float rotateSpeed=100.0f;

    bool isWalking = false;
    bool isJump = false;
    bool isGround = true;
    bool isRun = false;

    public float jumpForce = 5f;
    private Rigidbody rb;
    Animator anim;

    void Start()
    {
        ry=transform.eulerAngles.y;
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        
        Walking();
        Jump();
        colliderObject();
        GroundCheck();
    }

    void FixedUpdate()
    {
        
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

    void GroundCheck()
    {
        Vector3 startPosition = transform.position + Vector3.up;
        Debug.DrawRay(startPosition, -transform.up*5f , Color.red);
        RaycastHit rayHit;

        if (Physics.Raycast(startPosition, -transform.up*3f, out rayHit, 1, LayerMask.GetMask("Ground")))
        {
            print("�ٴ�!");
            isGround = true;
        }
        else
        {
            print("�ٴھƴ�");
            isGround = false;
        }

        anim.SetBool("isGround", isGround);
    }

    private void Jump() // �����ϱ�
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            print("�����̽� ����");

            isJump = true;
            isGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        anim.SetBool("isJump", isJump);
    }

    void Walking()
    {
        
        if (Input.GetButton("Sprint")) // Run
        {
            Run();
        }
        else
        {
            isRun = false;
            Speed = 20.0f;
        }
        transform.Translate(new Vector3(0, 0, v) * Speed * Time.deltaTime);
        ry += h * rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, ry, 0));

        if (h != 0 || v != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        isJump = false;
        anim.SetBool("isWalk", isWalking);
        anim.SetBool("isRun", isRun);
    }
    void Run()
    {
        Speed=50.0f;
        isRun = true;
    }
}
