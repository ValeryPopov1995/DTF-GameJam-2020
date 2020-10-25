using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovenment : MonoBehaviour
{
    [Tooltip("Character settings")]
    public float MoveSpeed = 10f, JumpForce = 10f, Sensitivity = 120f;
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
        Debug.Log("screen width " + Screen.width);
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
        #endregion

        #region rotation
        transform.Rotate(Vector3.up * xmouse);
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        CamEmpty.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
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
        moveVector = transform.forward * MoveSpeed * Input.GetAxis("Vertical") +
            transform.right * MoveSpeed * Input.GetAxis("Horizontal") +
            transform.up * gravityVector;
        character.Move(moveVector * Time.deltaTime);
        #endregion
    }
}
