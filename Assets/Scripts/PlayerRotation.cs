using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform m_PlayerCamera;

	private void Update ()
	{
		RotatePlayerBasedOnCamera();
	}

	private void RotatePlayerBasedOnCamera ()
	{
		// Get the forward direction of the camera, ignoring the y component
		Vector3 cameraForward = m_PlayerCamera.forward;

		// Keep only horizontal direction
		cameraForward.y = 0;

		// Ensure the forward vector is normalized
		cameraForward.Normalize();

		// Set the player's rotation to match the camera's direction
		transform.forward = cameraForward;
	}
}
