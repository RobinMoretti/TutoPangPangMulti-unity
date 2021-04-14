using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MouseController : NetworkBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    public GameObject childCamera;

    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) { return; }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            print(mouseY);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        childCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        this.transform.Rotate(Vector3.up * mouseX);
    }


    public override void OnStartAuthority()
    {
        childCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
