using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }
    void LateUpdate() // Uadate가 끝난 다음. 카메라, UI에 씀
    {
        transform.position = playerTransform.position + Offset;
    }
}
