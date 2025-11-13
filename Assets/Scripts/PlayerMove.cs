using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;       // 移动速度
    public float lookSensitivity = 2f; // 鼠标灵敏度
    public float verticalSpeed = 3f;   // 上下移动速度

    private float rotationX = 0f;      // 用于垂直旋转

    void Update()
    {
        // 获取键盘输入
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // 基础移动（前后左右）
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // 上下移动（Q/E）
        if (Input.GetKey(KeyCode.Q))
            move += Vector3.down * verticalSpeed;
        if (Input.GetKey(KeyCode.E))
            move += Vector3.up * verticalSpeed;

        transform.position += move * moveSpeed * Time.deltaTime;

        // 鼠标控制视角
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // 限制垂直角度

        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + mouseX, 0f);
    }
}
