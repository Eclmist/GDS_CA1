using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player;
    public float rotateSpeed = 5;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        transform.eulerAngles += new Vector3(-vertical, horizontal, 0);

        float fov = Camera.main.fieldOfView;
        float newFov = Input.GetAxis("Mouse ScrollWheel") * 30;
        newFov = Mathf.Clamp(fov, 50, 80);

        fov = Mathf.Lerp(fov, newFov, Time.deltaTime);

        Camera.main.fieldOfView = fov;
    }

}
