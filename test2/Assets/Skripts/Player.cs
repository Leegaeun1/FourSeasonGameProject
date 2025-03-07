using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 10.0f;     // 움직이는 속도. public으로 설정하여 유니티 화면에서 조정할 수 있다.
    float ry;
    float h, v;
    public float rotateSpeed=100.0f;
    bool isWalking = false;
    public float jumpForce = 5f;
    private Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ry=transform.eulerAngles.y;
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }
    void FixedUpdate()
    {
        colliderObject();
        Walking();
    }
    void colliderObject()
    {
        Vector3 startPosition = transform.position + Vector3.up * 5f;
        Debug.DrawRay(startPosition, transform.forward * 10, Color.red);
        RaycastHit rayHit;

        if (Physics.Raycast(startPosition, transform.forward, out rayHit, 10, LayerMask.GetMask("Walls")))
        {
            print("충돌!");
            v = 0;
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void Walking()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
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
        anim.SetBool("isWalk", isWalking);
    }
}
