using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset, offset2;
    public MovementController movementController;



    private void LateUpdate()
    {

        if (movementController.finishCameraPos == false)
        {
            if (movementController.thirdCameraPos == false)
            {
                if (movementController.secondCameraPos == false)
                {
                    transform.position = Vector3.Lerp(transform.position, (new Vector3(1, player.position.y + offset.y, player.position.z + offset.z)), Time.deltaTime * 6);
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, (new Vector3(7.2f, player.position.y + offset2.y, player.position.z + offset2.z)), Time.deltaTime * 3);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, (new Vector3(7.8f, player.position.y + offset2.y, player.position.z + offset2.z + 7f)), Time.deltaTime * 4);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, (new Vector3(16f,  6.5f, player.position.z - 2f )), Time.deltaTime * 7);
            transform.rotation = Quaternion.Euler(35, -60, 5);

        }
    }

}
