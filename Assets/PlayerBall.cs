using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody myRigid;
    AudioSource myAudio;
    public GameManagerLogic manager;

    public int itemCount = 0;
    public float jumpPower = 5;
    bool isJump;
    
    void Awake()
    {
        myRigid = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
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
        myRigid.AddForce(new Vector3(side, 0, -front), ForceMode.Impulse);

        // 점프
        // if(Input.GetKey(KeyCode.Space) && !isJump){ // 1단 점프
        if(Input.GetKey(KeyCode.Space)){
            isJump = true;
            myRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
    
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Floor")   
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item"){
            itemCount++;
            Debug.Log("itemCount: " + itemCount);
            myAudio.Play();
            other.gameObject.SetActive(false);
        } else if (other.tag == "Finish"){
            if (itemCount == manager.totalItemCount){ // Game Clear
                SceneManager.LoadScene("SampleScene2");
                // SceneManager.LoadScene("SampleScene" + manager.stage);
            } else { // Restart
                SceneManager.LoadScene("SampleScene1");
            }
        }
    }
}
