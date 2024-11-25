using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectController : MonoBehaviour
{
    public float targetAspect = 1.75f; // Hedef görüntü oraný (örnek: 3:2)

    void Start()
    {
        // Hedef görüntü oraný
        float targetAspectRatio = targetAspect;

        // Ekran görüntü oraný
        float windowAspectRatio = (float)Screen.width / (float)Screen.height;

        // Oran farký
        float scaleHeight = windowAspectRatio / targetAspectRatio;

        // Kamerayý ayarla
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // Ekran yüksekliði daha büyükse, dikey kenarlarý kýsalt
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            // Ekran geniþliði daha büyükse, yatay kenarlarý kýsalt
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
