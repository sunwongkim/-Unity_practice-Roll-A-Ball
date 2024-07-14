using UnityEngine;

public class Physics : MonoBehaviour
{
    private Rigidbody myRigid;
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // W,A,S,D 이동
        Vector3 vec =
            new Vector3(Input.GetAxisRaw("Horizontal"),
                                        0,
                                        Input.GetAxisRaw("Vertical"));
        myRigid.AddForce(vec, ForceMode.Impulse); // obj mass = 5
        
        // 점프 기본 예제
        // if(Input.GetKeyDown("Jump")) // Jump(space)를 인식못함.
        if(Input.GetKey(KeyCode.Space))
            myRigid.AddForce(Vector3.up * 1, ForceMode.Impulse);
    }
}