using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            transform.position += direction * Time.deltaTime * 5;
            float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg;
            var rot = Quaternion.Euler(new Vector3(0, angle, 0));
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.2f);

        }
    }
}