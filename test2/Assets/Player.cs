using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 10.0f;     // 움직이는 속도. public으로 설정하여 유니티 화면에서 조정할 수 있다.

    float h, v;                     // 가로축과 세로축을 담을 변수를 전역변수로 생성. FixedUpdate에서 직접 생성하지 않은 이유는
                                    // 이후 다른 함수에서도 접근할 것이기 때문.
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

    // 이동 관련 함수를 짤 때는 Update보다 FixedUpdate가 더 효율이 좋다고 한다. 그래서 사용했다.
    void FixedUpdate()
    {
        // Point 1.
        h = Input.GetAxis("Horizontal");        // 가로축
        v = Input.GetAxis("Vertical");          // 세로축

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
