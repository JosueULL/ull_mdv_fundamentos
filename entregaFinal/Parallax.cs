using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayerConfig
    {
        public Transform Layer;
        [FormerlySerializedAs("Strength")]
        public float StrengthX;
        public float StrengthY;
    }

    public Camera Camera;
    public List<ParallaxLayerConfig> Layers;
    public bool X;
    public bool Y;

    // --------------------------------------------------------------------

    void Update()
    {
        Vector3 camPos = Camera.transform.position;
        foreach (ParallaxLayerConfig layer in Layers)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(pos.x, camPos.x, layer.StrengthX);
            pos.y = Mathf.Lerp(pos.y, camPos.y, layer.StrengthY);
            layer.Layer.position = pos;
        }
    }
}
