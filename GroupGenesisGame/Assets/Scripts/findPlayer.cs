using UnityEngine;

public class VirtualCameraPersistence : MonoBehaviour
{
    private void Awake()
    {
        // Make sure the camera is not destroyed when switching scenes
        DontDestroyOnLoad(gameObject);
    }
}
