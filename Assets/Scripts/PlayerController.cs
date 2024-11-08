using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerInput m_PlayerInput;
    [SerializeField] private PlayerMovement m_Movement;

	private void OnEnable ()
	{
		m_PlayerInput.OnJumpInput += m_Movement.Jump;
	}

	private void Update ()
	{
		HandleMoveInput();
	}

	private void OnDisable ()
	{
		m_PlayerInput.OnJumpInput -= m_Movement.Jump;
	}

	private void HandleMoveInput ()
	{
		m_Movement.MovementDirection = m_PlayerInput.GetMovementInput();
	}
}
