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
            new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        myRigid.AddForce(vec, ForceMode.Impulse); // obj mass = 5
        
        // jump(점프하는 대표적인 코드)
        if(Input.GetKeyDown("Jump"))
        // if(Input.GetKey(KeyCode.Space))
            myRigid.AddForce(Vector3.up *0.1f, ForceMode.Impulse);
    }
    void Update()
    {
    }
}