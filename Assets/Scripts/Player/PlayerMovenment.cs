using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovenment : MonoBehaviour
{
    [Tooltip("Character settings")]
    public float MoveSpeed = 5f, RunSpeed = 10f, SeetSpeed = 2f, JumpForce = 10f, Sensitivity = 120f, StandHeight = 1.7f, SeetHeight = .9f;
    public bool HideCursor = true;
    public Transform CamEmpty;

    bool isGround = false;
    float xmouse, ymouse, gravityVector = -1f;
    CharacterController character;
    [HideInInspector]
    public Vector3 moveVector;
    float yRotation;

    void Start()
    {
        character = GetComponent<CharacterController>();

        if (HideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked; // freeze cursor on screen centre
            Cursor.visible = false; // invisible cursor
        }
    }

    void Update()
    {
        #region imnput
        xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;

        float speed = MoveSpeed;
        if (Input.GetKey(KeyCode.LeftControl)) // seeting
        {
            speed = SeetSpeed;

            character.height = SeetHeight;
        }
        else // standing
        {
            if (Input.GetKey(KeyCode.LeftShift) && isGround) speed = RunSpeed;

            character.height = StandHeight;
        }
        #endregion

        #region rotation
        if (!Cursor.visible)
        {
            transform.Rotate(Vector3.up * xmouse);
            yRotation -= ymouse;
            yRotation = Mathf.Clamp(yRotation, -85f, 60f);
            CamEmpty.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
        }
        #endregion

        #region jump
        if (Physics.CheckSphere(transform.position - transform.up * 1.3f, .2f) && gravityVector < -1f) isGround = true;
        if (gravityVector > -8f) gravityVector -= Time.deltaTime * 10;
        if (Input.GetButtonDown("Jump") && isGround)
        {
            gravityVector = JumpForce;
            isGround = false;
        }
        #endregion

        #region moving result
        if (!Cursor.visible)
        {
            moveVector = transform.forward * speed * Input.GetAxis("Vertical") +
                transform.right * speed * Input.GetAxis("Horizontal") +
                transform.up * gravityVector;
            character.Move(moveVector * Time.deltaTime);
        }
        #endregion
    }
}
