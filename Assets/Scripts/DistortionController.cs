using UnityEngine;

public class DistortionController : MonoBehaviour
{
    [SerializeField] private Material distortionMaterial;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (distortionMaterial != null)
            Graphics.Blit(src, dest, distortionMaterial);
        else
            Graphics.Blit(src, dest);
    }
}
