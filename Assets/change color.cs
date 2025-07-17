using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Define colors for each key
    public Color color1 = Color.red;
    public Color color2 = Color.green;
    public Color color3 = Color.blue;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteRenderer.color = color1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteRenderer.color = color2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteRenderer.color = color3;
        }
    }
}