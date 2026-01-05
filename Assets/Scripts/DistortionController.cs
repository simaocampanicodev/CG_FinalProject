using UnityEngine;

public class DistortionController : MonoBehaviour
{
    [SerializeField] private Material distortionMaterial;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, distortionMaterial);
    }
}
