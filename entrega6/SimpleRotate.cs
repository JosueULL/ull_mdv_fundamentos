using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public float Speed = 10;

    // --------------------------------------------------------------------

    private void Update()
    {
        transform.Rotate(Vector3.up * Speed * Time.deltaTime);
    }
}