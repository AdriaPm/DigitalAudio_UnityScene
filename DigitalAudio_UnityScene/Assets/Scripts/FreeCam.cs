using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public float mouseSensibility = 4f;

    float yaw = 0f;
    float pitch = 0f;

    public float moveSpeed = 5.0f; // Speed of camera movement
    public float rotationSpeed = 2.0f; // Speed of camera rotation
    public float riseSpeed = 5.0f; // Speed of camera rising
    public float descendSpeed = 5.0f; // Speed of camera descending

    public float maxY = -65; // For some reason, the signs are strange.
    public float minY = 50;

    private bool isCursorLocked = false;

    private void Start()
    {
        Cursor.visible = true; // Show the cursor initially
        yaw = 0;
        pitch = 90;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        yaw += mouseSensibility * Input.GetAxis("Mouse X");
        pitch -= mouseSensibility * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, maxY, minY); // Clamp viewing up and down

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Lock or unlock cursor when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;
            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorLocked;
        }

        // Camera rising (Shift key)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float riseInput = 1.0f;
            Vector3 riseVector = Vector3.up * riseInput * riseSpeed * Time.deltaTime;
            transform.Translate(riseVector);
        }

        // Camera descending (Ctrl key)
        if (Input.GetKey(KeyCode.LeftControl))
        {
            float descendInput = -1.0f;
            Vector3 descendVector = Vector3.up * descendInput * descendSpeed * Time.deltaTime;
            transform.Translate(descendVector);
        }
    }
}
