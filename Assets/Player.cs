// 할거: snapX,Y , 바닥 큐브로 대체, 프리펩

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody myRigid;
    AudioSource myAudio;
    public GameManagerLogic manager;
    public FixedJoystick joy;
    public int itemCount = 0;
    public float movePower;
    public float jumpPower;
    bool isJump;
    
    void Awake()
    {
        myRigid = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        isJump = false;
    }
    
    void Start()
    {
        if (joy != null){
            joy.SnapX = true;
            joy.SnapY = true;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // 위치 초기화
            transform.position = new Vector3(0, 3, 0);
    
        if (Input.GetKeyDown(KeyCode.G)) // 처음 스크린으로 이동
            SceneManager.LoadScene("Scene1");
    }

    void FixedUpdate()
    {
        // W,A,S,D 이동
        float front = Input.GetAxisRaw("Horizontal");
        float side = Input.GetAxisRaw("Vertical");
        myRigid.AddForce(new Vector3(front, 0, side) * movePower, ForceMode.Impulse);
        
        if (joy != null) // 조이스틱
            myRigid.AddForce(new Vector3(joy.Horizontal, 0, joy.Vertical) * movePower, ForceMode.Impulse);

        // 점프
        // if(Input.GetKey(KeyCode.Space)){
        if(Input.GetKey(KeyCode.Space) && !isJump){ // 1단 점프
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
        Scene currentScene = SceneManager.GetActiveScene();
        if (other.tag == "Item"){
            itemCount++;
            Debug.Log("itemCount: " + itemCount);
            myAudio.Play();
            other.gameObject.SetActive(false);
            manager.GetItemCount(itemCount);
        } else if (other.tag == "GameManager"){ // 공 추락
            SceneManager.LoadScene(currentScene.name);
        } else if (other.tag == "Flag"){
            if (itemCount == manager.totalItemCount){ // Game Clear
                SceneManager.LoadScene("Scene2");
            } else { // Restart
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }

    public void Jump()
    {
        if (!isJump){
            isJump = true;
            myRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
