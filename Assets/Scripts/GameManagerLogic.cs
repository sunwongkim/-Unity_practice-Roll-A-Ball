using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public Text CountText;
    public int totalItemCount;
    public int stage;

    void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        totalItemCount = items.Length;

        if (CountText != null) // UI
            CountText.text = "0 / " + totalItemCount; 
        
        stage = SceneManager.GetActiveScene().buildIndex; // Scene index
    }

    public void GetItemCount(int count){
        CountText.text = count + " / " + totalItemCount;
    }
}
