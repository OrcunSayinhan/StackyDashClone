using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TravelController : MonoBehaviour
{
    public static TravelController instance;


    private void Awake()
    {
        instance = this;
    }
    public PathCreator pathCreator;
    public PathCreator secondPathCreator;
    public float pathCreatorSpeed;
    public float distanceTravelled;
    public float secondDistanceTravelled;
    public bool isTravel , isTravelNegative , isSecondTravel,  isSecondTravelNegative;

    private void Update()
    {
        if (isTravel)
        {
            distanceTravelled += pathCreatorSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }
        if (isSecondTravel)
        {
            secondDistanceTravelled += pathCreatorSpeed * Time.deltaTime;
            transform.position = secondPathCreator.path.GetPointAtDistance(secondDistanceTravelled);
            transform.rotation = secondPathCreator.path.GetRotationAtDistance(secondDistanceTravelled);
        }


        if (isTravelNegative)
        {
            distanceTravelled -= pathCreatorSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }

        if (isSecondTravelNegative)
        {
            secondDistanceTravelled -= pathCreatorSpeed * Time.deltaTime;
            transform.position = secondPathCreator.path.GetPointAtDistance(secondDistanceTravelled);
            transform.rotation = secondPathCreator.path.GetRotationAtDistance(secondDistanceTravelled);
        }

    }





}
