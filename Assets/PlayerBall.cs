using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    Rigidbody myRigid;
    public float jumpPower = 10;
    bool isJump;  
    
    void Awake()
    {
        myRigid = GetComponent<Rigidbody>();
        isJump = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // 위치 초기화
            transform.position = new Vector3(0, 3, 0);
    }

    void FixedUpdate()
    {
        // W,A,S,D 이동
        float front = Input.GetAxisRaw("Horizontal");
        float side = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(side, 0, front);
        myRigid.AddForce(vec, ForceMode.Impulse);

        // 점프
        // if(Input.GetKey(KeyCode.Space) && !isJump){ // 1단 점프
        if(Input.GetKey(KeyCode.Space)){
            isJump = true;
            myRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
    
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.name == "Floor")   
            isJump = false;
    }
}
