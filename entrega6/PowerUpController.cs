using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public List<GameObject> StaticPrefabs;
    public List<GameObject> DynamicPrefabs;
    public List<Transform> SpawnPositions;
    public List<Transform> MovementPath;
    public float StaticShuffleInterval = 10;

    private List<GameObject> mStaticInstances = new List<GameObject>();
    private List<Transform> mAvailablePositions = new List<Transform>();
    private float mCurrentInterval;

    // --------------------------------------------------------------------

    private void Start()
    {
        // Instantiate static objects
        foreach (GameObject go in StaticPrefabs)
        {
            GameObject goInstance = Instantiate(go);
            mStaticInstances.Add(goInstance);
        }

        // Instantiate dynamic objects
        foreach (GameObject go in DynamicPrefabs)
        {
            GameObject goInstance = Instantiate(go);
            LinearPathFollower pathFollower = goInstance.GetComponent<LinearPathFollower>();
            pathFollower.Path = MovementPath;
            if (MovementPath.Count > 0)
                pathFollower.transform.position = MovementPath[0].position;
        }
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        mCurrentInterval -= Time.deltaTime;
        if (mCurrentInterval <= 0)
            Shuffle();
    }

    // --------------------------------------------------------------------

    private void Shuffle()
    {
        mAvailablePositions.Clear();
        mAvailablePositions.AddRange(SpawnPositions);

        mCurrentInterval = StaticShuffleInterval;
        foreach (GameObject go in mStaticInstances)
        {
            if (go.gameObject.activeSelf)
            {
                int randomIndex = Random.Range(0, mAvailablePositions.Count);
                Vector3 randomPos = mAvailablePositions[randomIndex].position;
                mAvailablePositions.RemoveAt(randomIndex);
                go.transform.position = randomPos;
            }
        }
    }
}