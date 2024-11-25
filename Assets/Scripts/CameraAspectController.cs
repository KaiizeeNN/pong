using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectController : MonoBehaviour
{
    public float targetAspect = 1.75f; // Hedef g�r�nt� oran� (�rnek: 3:2)

    void Start()
    {
        // Hedef g�r�nt� oran�
        float targetAspectRatio = targetAspect;

        // Ekran g�r�nt� oran�
        float windowAspectRatio = (float)Screen.width / (float)Screen.height;

        // Oran fark�
        float scaleHeight = windowAspectRatio / targetAspectRatio;

        // Kameray� ayarla
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // Ekran y�ksekli�i daha b�y�kse, dikey kenarlar� k�salt
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            // Ekran geni�li�i daha b�y�kse, yatay kenarlar� k�salt
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
