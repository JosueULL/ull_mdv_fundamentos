using UnityEngine;

public class PhysicsDebugInfo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter, receiver:" + gameObject.name + ", other:" + other.name);
    }

    // --------------------------------------------------------------------

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("TriggerExit, receiver:" + gameObject.name + ", other:" + other.name);
    }

    // --------------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter, receiver:" + gameObject.name + ", other:" + collision.collider.name);
    }

    // --------------------------------------------------------------------

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit, receiver:" + gameObject.name + ", other:" + collision.collider.name);
    }
}