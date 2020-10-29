using System.Collections.Generic;
using UnityEngine;

public class LinearPathFollower : MonoBehaviour
{
    public float Speed;
    public List<Transform> Path;
    public float TargetReachedDistance = 0.1f;

    private int mCurrentIndex;

    // --------------------------------------------------------------------

    private void Start()
    {
        mCurrentIndex = 0;
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        Vector3 target = Path[mCurrentIndex].position;
        Vector3 dirToTarget = Vector3.Normalize(target - transform.position);
        transform.position += dirToTarget * Speed * Time.deltaTime;

        if (Vector3.Distance(target, transform.position) < TargetReachedDistance)
        {
            ++mCurrentIndex;
            if (mCurrentIndex >= Path.Count)
                mCurrentIndex = 0;
        }
    }
}