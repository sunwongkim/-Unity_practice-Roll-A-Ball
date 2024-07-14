using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer myMesh;
    Material myMat;
    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        myMat = myMesh.material;
    }
    private void OnCollisionEnter(Collision other) {
    // private void OnCollisionEnter(Collision collision) {
        myMat.color = new Color(0, 0, 0);
    }
}
