using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement Setting")]
	[SerializeField] private float m_MoveSpeed = 5f;

	[Header("Movement Setting")]
	[SerializeField] private float m_JumpHeight = 1.5f;
	[SerializeField] private float m_MaxFallingSpeed = 2f;

	[Header("World Behaviour")]
	[SerializeField] private float m_Gravity = -9.8f;

	[Header("Components")]
    [SerializeField] private CharacterController m_Controller;

	public Vector2 MovementDirection { get; set; }

	private bool m_IsGrounded;

	private Vector3 m_PlayerVelocity;

	#region Unity Life Cycles

	private void Update ()
	{
		m_IsGrounded = m_Controller.isGrounded;
		CalculateMoveDirection();
	}

	private void FixedUpdate ()
	{
		ApplyGravity();
		MovePlayer();
	}

	#endregion

	#region Movement

	private void CalculateMoveDirection ()
	{
		Vector3 newMoveDir = Vector3.zero;
		newMoveDir.x = MovementDirection.x;
		newMoveDir.z = MovementDirection.y;

		newMoveDir = transform.TransformDirection(newMoveDir) * m_MoveSpeed;

		m_PlayerVelocity.x = newMoveDir.x;
		m_PlayerVelocity.z = newMoveDir.z;
	}

	private void MovePlayer ()
	{
		m_Controller.Move(m_PlayerVelocity * Time.fixedDeltaTime);
	}

	#endregion

	#region Jump and Gravity

	private void ApplyGravity ()
	{
		// Gravity Accumulation
		m_PlayerVelocity.y += m_Gravity * Time.fixedDeltaTime;

		// Ground Check && Velocity Check
		if (!m_IsGrounded && m_PlayerVelocity.y < -m_MaxFallingSpeed)
		{
			// Clamp velocity to prevent falling through the ground
			m_PlayerVelocity.y = -m_MaxFallingSpeed;
		}
	}

	public void Jump ()
	{
		if (m_IsGrounded)
		{
			// Standart Character Controller Jump By Unity Documentation
			m_PlayerVelocity.y = Mathf.Sqrt(m_JumpHeight * -3.0f * m_Gravity);
		}
	}

	#endregion
}
