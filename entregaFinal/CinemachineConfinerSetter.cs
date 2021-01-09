using UnityEngine;
using Cinemachine;

public class CinemachineConfinerSetter : MonoBehaviour
{
    public CinemachineConfiner CameraConfiner;

    // --------------------------------------------------------------------

    public void SetDamping(float val)
    {
        CameraConfiner.m_Damping = val;
    }

    // --------------------------------------------------------------------

    public void SetConfiner(CompositeCollider2D confiner)
    {
        CameraConfiner.enabled = true;
        CameraConfiner.m_BoundingShape2D = confiner;
    }

    // --------------------------------------------------------------------

    public void ClearConfiner()
    {
        CameraConfiner.enabled = false;
        CameraConfiner.m_BoundingShape2D = null;
    }
}
