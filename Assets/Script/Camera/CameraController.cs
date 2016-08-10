using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player;
    public float rotateSpeed = 5;

    private float targetFov;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        #region Camera Rotation
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        Vector3 targetEulerAngles = transform.eulerAngles + new Vector3(-vertical, horizontal, 0);


        targetEulerAngles.x = Mathf.Clamp(targetEulerAngles.x, 0, 90);


        transform.eulerAngles = targetEulerAngles;

        #endregion

        #region Camera Movement
        Vector3 targetPos = player.position;
        targetPos.y = 2;
        transform.position = targetPos;

        #endregion

        #region Mouse Zoom
        //Mousewheel zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            targetFov -= Input.GetAxis("Mouse ScrollWheel") * 100;
        }

        targetFov = Mathf.Clamp(targetFov, 50, 100);

        Debug.Log(targetFov);

        float fov = Camera.main.fieldOfView;

        fov = Mathf.Lerp(fov, targetFov, Time.deltaTime * 10);

        Camera.main.fieldOfView = fov;
        #endregion
    }

}
