using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera Camera;
    public ParallaxLayer[] Layers;

    void Update()
    {
        foreach(ParallaxLayer layer in Layers)
        {
            layer.UpdateState(Camera);
        }
    }
}
