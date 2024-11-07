using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Stats")]
	[SerializeField] private float m_MoveSpeed = 5f;

    [Header("Components")]
    [SerializeField] private CharacterController m_Controller;

	public Vector2 MovementDirection { get; set; }

	private void FixedUpdate ()
	{
		MovePlayer();
	}

	private void MovePlayer ()
	{
		Vector3 newMoveDir = Vector3.zero;
		newMoveDir.x = MovementDirection.x;
		newMoveDir.z = MovementDirection.y;

		m_Controller.Move(transform.TransformDirection(newMoveDir) * m_MoveSpeed * Time.fixedDeltaTime);
	}
}
