using UnityEngine;

public class Physics : MonoBehaviour
{
    private Rigidbody myRigid;
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // W,A,S,D 이동
        float side = Input.GetAxisRaw("Horizontal");
        float front = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(side, 0, front);

        myRigid.AddForce(vec, ForceMode.Impulse); // obj mass = 5
        
        // 점프 기본 예제
        // if(Input.GetKeyDown("Jump")) // Jump(space)를 인식못함.
        if(Input.GetKey(KeyCode.Space))
            myRigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) // 위치 초기화
            transform.position = new Vector3(0, 3, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "JumpZone")
            myRigid.AddForce(Vector3.up, ForceMode.Impulse);
    }
    public void ResetPosition(){
        Debug.Log("print");
        transform.position = new Vector3(0, 3, 0);
    }
}