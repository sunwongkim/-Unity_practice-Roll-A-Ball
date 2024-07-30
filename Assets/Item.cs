using UnityEngine;

public class Item : MonoBehaviour
{
    public float rptateSpeed = 30;
    void Update()
    {
        transform.Rotate(Vector3.up * rptateSpeed * Time.deltaTime, Space.World);
    }
}
