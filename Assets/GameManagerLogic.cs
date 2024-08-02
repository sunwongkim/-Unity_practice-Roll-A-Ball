using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount = 0;
    public int stage = 0;

    void Start()
    {

        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        totalItemCount = items.Length;
        
        stage = SceneManager.GetActiveScene().buildIndex; // Scene index
    }
}
