using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private InputSystem_Actions m_InputActionMap;

	public System.Action OnJumpInput;

	private void Awake ()
	{
		if (m_InputActionMap == null) m_InputActionMap = new InputSystem_Actions();
	}

	private void OnEnable ()
	{
		m_InputActionMap.Enable();

		m_InputActionMap.Player.Jump.performed += ctx => OnJumpInput?.Invoke();
	}

	private void OnDisable ()
	{
		m_InputActionMap.Disable();

		m_InputActionMap.Player.Jump.performed -= ctx => OnJumpInput?.Invoke();
	}

	public Vector2 GetMovementInput ()
	{
		return m_InputActionMap.Player.Move.ReadValue<Vector2>();
	}
}
