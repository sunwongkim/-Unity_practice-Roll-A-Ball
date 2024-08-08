using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Scene1");
    }
}
