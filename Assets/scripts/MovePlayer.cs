using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController characterController;
    public float gravity = -9.8f;
    public float speed;
    public float JumpForce;
    private float JumpSpeed;

    private float mouseX;
    private float mouseY;

    [Header("Чувствительность мыши")]
    public float sensitivtyMouse = 200f;

    public GameObject Player;
    public Camera Camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivtyMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivtyMouse * Time.deltaTime;

        Player.transform.Rotate(new Vector3(0, mouseX, 0));
        Camera.transform.Rotate(new Vector3(-mouseY, 0, 0));

        float horizontal = 0;
        float vertical = 0;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (characterController.isGrounded)
        {
            JumpSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpSpeed = JumpForce;
            }
        }
        JumpSpeed += gravity * Time.deltaTime * 3f;
        Vector3 dir = new(vertical * speed * Time.deltaTime, JumpSpeed * Time.deltaTime, -horizontal * speed * Time.deltaTime);
        characterController.Move(dir);
    }
}