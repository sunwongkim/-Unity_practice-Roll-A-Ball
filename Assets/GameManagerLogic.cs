using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public Text CountText;
    public int totalItemCount = 0;
    public int stage = 0;

    void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        totalItemCount = items.Length;

        CountText.text = "0 / " + totalItemCount; // UI
        
        stage = SceneManager.GetActiveScene().buildIndex; // Scene index
    }

    public void GetItemCount(int count){
        CountText.text = count + " / " + totalItemCount;
    }
}
