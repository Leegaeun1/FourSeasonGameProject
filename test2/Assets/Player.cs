using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 10.0f;     // �����̴� �ӵ�. public���� �����Ͽ� ����Ƽ ȭ�鿡�� ������ �� �ִ�.

    float h, v;                     // ������� �������� ���� ������ ���������� ����. FixedUpdate���� ���� �������� ���� ������
                                    // ���� �ٸ� �Լ������� ������ ���̱� ����.
    bool isWalking = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �̵� ���� �Լ��� © ���� Update���� FixedUpdate�� �� ȿ���� ���ٰ� �Ѵ�. �׷��� ����ߴ�.
    void FixedUpdate()
    {
        // Point 1.
        h = Input.GetAxis("Horizontal");        // ������
        v = Input.GetAxis("Vertical");          // ������

        if (h != 0 || v != 0)
        {
            isWalking= true; 
        }
        else
        {
            isWalking = false;
        }

        anim.SetBool("isWalk", isWalking);
        // Point 2.
        transform.position += new Vector3(h, 0, v) * Speed * Time.deltaTime;
    }
}
