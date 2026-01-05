using UnityEngine;

public class DistortionActivation : MonoBehaviour
{
    [SerializeField] private Material distortionMaterial;
    private Material runtimeMaterial;
    private static readonly int noiseID = Shader.PropertyToID("NoiseScale");

    private void Awake()
    {
        runtimeMaterial = new Material(distortionMaterial);
    }

    public Material GetRuntimeMaterial()
    {
        return runtimeMaterial;
    }

    public void EnableDistortion(float noise = 10f)
    {
        runtimeMaterial.SetFloat(noiseID, noise);
    }

    public void DisableDistortion()
    {
        runtimeMaterial.SetFloat(noiseID, 0f);
    }
}
