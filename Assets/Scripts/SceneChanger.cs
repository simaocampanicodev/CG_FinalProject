using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string NoDistortion;
    [SerializeField] private DistortionActivation distortionActivation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            distortionActivation.DisableDistortion();
            SceneManager.LoadScene(NoDistortion);
        }
    }
}
