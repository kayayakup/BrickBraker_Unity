using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    public Rigidbody controller_rigi;

    float speed=10.0f;
    float horizontal_button;

    private void FixedUpdate() {
        controller_movement();
    }

    void controller_movement(){
        horizontal_button=Input.GetAxis("Horizontal");
        controller_rigi.velocity=(Vector3.right*speed)*horizontal_button;
    }
}
