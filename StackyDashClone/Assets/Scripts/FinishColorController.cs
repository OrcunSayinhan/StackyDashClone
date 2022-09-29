using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishColorController : MonoBehaviour
{
    public List<Material> changeColors = new List<Material>();
    public List<GameObject> leftPipes = new List<GameObject>();
    public List<GameObject> rightPipes = new List<GameObject>();

    public UnstackController unstackController;

    private void Start()
    {
        unstackController = GetComponent<UnstackController>();
    }

    int numberOfList = 0;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColorChanger"))
        {
            if (unstackController.isFinishLine == false)
            {
                unstackController.isFinishLine = true;
            }
            leftPipes[numberOfList].GetComponent<MeshRenderer>().material = changeColors[numberOfList];
            rightPipes[numberOfList].GetComponent<MeshRenderer>().material =changeColors[numberOfList];
            numberOfList++;
        }
    }



}
