using UnityEngine;

public class PlayerModeController : MonoBehaviour
{
    public enum PlayerMode
    {
        Driving,
        Fishing
    }

    [Header("Mode Settings")]
    public PlayerMode currentMode = PlayerMode.Driving;

    [Header("References")]
    public MonoBehaviour boatController;     // Script that handles boat movement
    public MonoBehaviour fishingController;  // Script that handles fishing logic
    public Camera drivingCamera;
    public Camera fishingCamera;

    [Header("Input")]
    public KeyCode toggleKey = KeyCode.F;

    void Start()
    {
        UpdateMode(currentMode);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleMode();
        }
    }

    void ToggleMode()
    {
        currentMode = (currentMode == PlayerMode.Driving) ? PlayerMode.Fishing : PlayerMode.Driving;
        UpdateMode(currentMode);
    }

    void UpdateMode(PlayerMode mode)
    {
        // Enable/disable movement scripts
        if (boatController != null) boatController.enabled = (mode == PlayerMode.Driving);
        if (fishingController != null) fishingController.enabled = (mode == PlayerMode.Fishing);

        // Switch cameras
        if (drivingCamera != null) drivingCamera.enabled = (mode == PlayerMode.Driving);
        if (fishingCamera != null) fishingCamera.enabled = (mode == PlayerMode.Fishing);

        Debug.Log("Switched to " + mode.ToString() + " mode.");
    }
}
