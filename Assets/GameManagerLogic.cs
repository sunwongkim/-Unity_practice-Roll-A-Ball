using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount = 0;
    public int stage;

    void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        totalItemCount = items.Length;
        Debug.Log("totalItemCount: " + totalItemCount);
    }

}
