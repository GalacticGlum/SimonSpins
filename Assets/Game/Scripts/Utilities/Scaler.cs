using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class Scaler : MonoBehaviour
{
    [SerializeField]
    private ScaleMode scaleMode;

    private new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (scaleMode)
        {   
            case ScaleMode.Screen:
                {
                    Vector3 localScale = Vector3.one;

                    float width = renderer.sprite.bounds.size.x;
                    float height = renderer.sprite.bounds.size.y;

                    float screenHeight = Camera.main.orthographicSize * 2f;
                    float screenWidth = screenHeight / Screen.height * Screen.width;

                    localScale.x = screenWidth / width;
                    localScale.y = screenHeight / height;
                    transform.localScale = localScale;
                }
                break;
        }
    }
}
