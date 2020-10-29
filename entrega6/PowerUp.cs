using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private static readonly float sConsumedThreshold = 0.1f;
    private static readonly int sColorPropID = Shader.PropertyToID("_Color");

    public GameObject Visuals;
    public float ScorePerSecond = 1f;
    public float ConsumeSpeed = 1f;
    public float FullRotateSpeed = 100;
    public float ConsumedRotateSpeed = 500;

    private Material mMaterial;
    private SimpleRotate mRotate;
    private float mState = 1f;
    private Color mInitialColor;

    // --------------------------------------------------------------------

    private void Start()
    {
        mRotate = Visuals.GetComponent<SimpleRotate>();

        // Duplicate the material so it doesn't affect all instances
        MeshRenderer meshRend = Visuals.GetComponentInChildren<MeshRenderer>();
        mMaterial = Instantiate(meshRend.material);
        meshRend.material = mMaterial;
        mInitialColor = mMaterial.GetColor(sColorPropID);

        UpdateState();
    }

    // --------------------------------------------------------------------

    public void Consume(out bool consumed)
    {
        mState = Mathf.Clamp01(mState - ConsumeSpeed * Time.deltaTime);
        UpdateState();
        consumed = mState <= sConsumedThreshold;
    }

    // --------------------------------------------------------------------

    private void UpdateState()
    {
        Visuals.transform.localScale = Vector3.one * mState;
        Color c = mInitialColor;
        c.a = mState;
        mMaterial.SetColor(sColorPropID, c);
        mRotate.Speed = Mathf.Lerp(ConsumedRotateSpeed, FullRotateSpeed, mState);
    }
}