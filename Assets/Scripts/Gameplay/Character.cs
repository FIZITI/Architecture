using UnityEngine;

public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _groundChecker;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private SphereCollider _groundCheckerSphereCollider;
    private Vector2 _moveDirection;
    private bool onGround;

    public void Move(Vector2 direction) => _moveDirection = direction;
    public void Jump() => JumpInternal();

    private void FixedUpdate()
    {
        MoveIntrernal();
        GroundCheck();
    }

    private void MoveIntrernal()
    {
        float verticalVelocity = _rigidbody.velocity.y;
        Vector3 direction = new Vector3(_moveDirection.x, 0f, _moveDirection.y).normalized;
        _rigidbody.velocity = direction * _speed + Vector3.up * verticalVelocity;
    }

    private void JumpInternal()
    {
        if (onGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void GroundCheck()
    {
        onGround = Physics.OverlapSphere(_groundChecker.transform.position, _groundCheckerSphereCollider.radius, _groundLayerMask).Length > 0;
    }
}