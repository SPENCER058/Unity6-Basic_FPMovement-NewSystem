using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private InputSystem_Actions m_InputActionMap;

	private void Awake ()
	{
		if (m_InputActionMap == null) m_InputActionMap = new InputSystem_Actions();
	}

	private void OnEnable ()
	{
		m_InputActionMap.Enable();
	}

	private void OnDisable ()
	{
		m_InputActionMap.Disable();
	}

	public Vector2 GetMovementInput ()
	{
		return m_InputActionMap.Player.Move.ReadValue<Vector2>();
	}
}
