using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float Speed;

    private SpriteRenderer[] mSprites;

    private void Awake()
    {
        mSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void UpdateState(Camera cam)
    {
        float endX = FindEndPosition();

        foreach (SpriteRenderer rnd in mSprites)
        {
            rnd.transform.position -= Vector3.right * Speed * Time.deltaTime;

            float w = rnd.sprite.bounds.size.x * rnd.transform.lossyScale.x;
            float halfW = w * 0.5f;

            float camH = cam.orthographicSize * 2f;
            float camW = camH / Screen.height * Screen.width;
            float halfScreenW = camW * 0.5f;
            float spriteEndX = rnd.transform.position.x + halfW;
            
            if (spriteEndX < -halfScreenW) // Sprite is offscreen
            {
                Vector3 newPos = rnd.transform.position;
                newPos.x = endX + halfW;
                rnd.transform.position = newPos;
            }
        }
    }

    private float FindEndPosition()
    {
        float maxX = -Mathf.Infinity;
        foreach (SpriteRenderer rnd in mSprites)
        {
            float w = rnd.sprite.bounds.size.x * rnd.transform.lossyScale.x;
            float halfW = w * 0.5f;
            float spriteEndX = rnd.transform.position.x + halfW;
            if (spriteEndX > maxX)
                maxX = spriteEndX;
        }
        return maxX;
    }
}
