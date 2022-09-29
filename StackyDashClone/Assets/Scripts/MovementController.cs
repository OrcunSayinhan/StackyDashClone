using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MovementController : MonoBehaviour
{
    //[HideInInspector]
    public bool swipeUp, swipeDown, swipeLeft, swipeRight, isCollision, isMove;

    GameObject chestAndCube;

        [HideInInspector]
    public Vector3 startTouch, distance, currentPosition, firstPos;

    private const float deadZone = 50;
    public float speed;
    public LayerMask layer;
    public bool secondCameraPos;
    public bool thirdCameraPos;
    public bool finishCameraPos;


    private void Start()
    {
        secondCameraPos = false;
        isMove = true;
        chestAndCube = GameObject.Find("ChestAndCube");
    }


    public void SwipeControl()
    {

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouch = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentPosition = Input.GetTouch(0).position;
                distance = currentPosition - startTouch;


                if (isCollision)
                {
                    if (distance.x > deadZone)
                    {
                        isMove = true;
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        swipeRight = true;
                        swipeUp = false;
                        swipeDown = false;
                        swipeLeft = false;
                    }

                    else if (distance.x < -deadZone)
                    {
                        isMove = true;
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        swipeLeft = true;
                        swipeRight = false;
                        swipeUp = false;
                        swipeDown = false;
                    }

                    else if (distance.y > deadZone)
                    {
                        isMove = true;
                        transform.rotation = Quaternion.Euler(0, 360, 0);
                        swipeUp = true;
                        swipeLeft = false;
                        swipeRight = false;
                        swipeDown = false;
                    }
                    else if (distance.y < -deadZone)
                    {
                        isMove = true;
                        transform.rotation = Quaternion.Euler(0, 180, 0);

                        swipeDown = true;
                        swipeUp = false;
                        swipeLeft = false;
                        swipeRight = false;
                    }
                }
            }
            //if (Input.GetTouch(0).phase == TouchPhase.Ended)
            //{
            //    //startTouch = Vector3.zero;

            //}
        }


    }
    public void SwipeMovement()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.49f, layer))
        {

            isMove = false;
            isCollision = true;


            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
        else
        {
            isCollision = false;
        }


        if (isMove)
        {
            if (swipeLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (swipeRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (swipeUp)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            if (swipeDown)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }
    }


    private void Update()
    {
        SwipeControl();
        SwipeMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        #region CameraTriggers

        if (other.gameObject.CompareTag("CameraTrigger1"))
        {
            if (swipeUp)
            {
                secondCameraPos = true;
            }
            //else if (swipeDown)
            //{
            //    secondCameraPos = false;

            //}

        }
        if (other.gameObject.CompareTag("CameraTrigger2"))
        {
            if (swipeUp)
            {
                thirdCameraPos = true;
            }
            else if (swipeDown)
            {
                thirdCameraPos = false;

            }

        }

        if (other.gameObject.CompareTag("CameraTrigger3"))
        {
            if (swipeUp)
            {
                finishCameraPos = true;
            }
            

        }


        #endregion


        #region FirstPath
        if (other.gameObject.CompareTag("PathTrigger"))
        {
            if (swipeUp == true)
            {
                TravelController.instance.isTravel = true;
                firstPos = transform.position;
            }

            if (swipeDown == true)
            {
                TravelController.instance.isTravelNegative = false;
                transform.position = firstPos;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));

            }
        }
        if (other.gameObject.CompareTag("PathTriggerEnd"))
        {

            if (swipeUp == true)
            {
                
                TravelController.instance.isTravel = false;
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }

            if (swipeDown == true)
            {
                secondCameraPos = false;
                TravelController.instance.isTravelNegative = true;
            }
        }
        #endregion

        #region SecondPath
        if (other.gameObject.CompareTag("PathTrigger2"))
        {
            if (swipeUp == true)
            {
                TravelController.instance.isSecondTravel = true;
                // firstPos = transform.position;
            }

            if (swipeDown == true)
            {
                TravelController.instance.isSecondTravelNegative = false;
                //transform.position = firstPos;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            }
        }

        if (other.gameObject.CompareTag("PathTriggerEnd2"))
        {
            if (swipeUp == true)
            {
                TravelController.instance.isSecondTravel = false;
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }

            if (swipeDown == true)
            {

                TravelController.instance.isSecondTravelNegative = true;
            }
        }
        #endregion

        #region GameOver

        if (other.gameObject.CompareTag("ChestTrigger"))
        {
            isMove = false;
            isCollision = false;
            chestAndCube.transform.GetChild(0).transform.GetComponent<Animator>().Play("Chest");
            chestAndCube.transform.GetChild(1).transform.GetComponent<Animator>().Play("Cube");

            this.transform.GetChild(1).GetComponent<Animator>().Play("Victory");

        }


        #endregion


    }


}
