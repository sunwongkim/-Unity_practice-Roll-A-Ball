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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube"){
            // myMat.color = new Color(0, 0, 0);
            if (myMat.color == Color.red){
                myMat.color = Color.blue;
            }
            else myMat.color = Color.red;
        }
    }
}
