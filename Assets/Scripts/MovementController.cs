using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MovementController : NetworkBehaviour
{
    CharacterController controller;

    public float speed = 12f;

    public override void OnStartAuthority()
    {
        controller = this.GetComponent<CharacterController>();
    }

    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) { return; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
