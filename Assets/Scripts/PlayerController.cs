using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerInput m_PlayerInput;
    [SerializeField] private PlayerMovement m_Movement;

	private void Update ()
	{
		m_Movement.MovementDirection = m_PlayerInput.GetMovementInput();
	}
}
