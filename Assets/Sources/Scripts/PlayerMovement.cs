using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField]private bool canMove = false, canJump = true, SpeedUp = false;
    private bool Moving = false;
    private float _controllerOriginalHeight;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _runSpeed = 8f;
    [SerializeField] private float _gravity = -30f;
    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private Animator _cameraAnimator;
    private AudioSource audioSource;
    public AudioClip walkSound;
    [SerializeField] private float Timer;
    Vector3 velocity;
    public bool isGrounded = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = walkSound;
        _cameraAnimator.SetBool("IsWalk", false);
        _controllerOriginalHeight = controller.height;
        StartCoroutine(MoveAfter());
    }

    void Update()
    {

        isGrounded = controller.isGrounded;
        if (canMove == true)
        {
            Move();
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        if (Input.GetButton("Jump") && isGrounded && canJump == true)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.C))
        {
            controller.height = 0.7f;
            _speed = 3f;
        }
        else if (CanStandUp())
        {
            controller.height = 1.73f;
            _speed = 6f;
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravity);
    }

    private void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        if (move == Vector3.zero || isGrounded == false)
        {
            audioSource.Stop();
            Moving = false;
        } else if (!audioSource.isPlaying)
        {
            audioSource.Play();
            Moving = true;
        }

        if (move == Vector3.zero)
        {
            _cameraAnimator.SetBool("IsWalk", false);
        }
        else
        {
           _cameraAnimator.SetBool("IsWalk", true);
        }

        if (Input.GetKey(KeyCode.LeftShift) && SpeedUp == true)
        {
            controller.Move(_runSpeed * Time.deltaTime * move);
        }
        else
        {
            controller.Move(_speed * Time.deltaTime * move);
        }


        velocity.y += _gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //Проверка препятствия над персонажем
    private bool CanStandUp()
    {
        Vector3 upRayStart = transform.position + Vector3.up * (_controllerOriginalHeight / 2f);
        if (Physics.Raycast(upRayStart, Vector3.up, out RaycastHit hit, _controllerOriginalHeight))
        {
            return false;
        }
        return true;
    }
    private IEnumerator MoveAfter()
    {
        yield return new WaitForSeconds(Timer);
        canMove = true;
    }
}