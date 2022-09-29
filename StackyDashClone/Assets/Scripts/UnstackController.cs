using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnstackController : MonoBehaviour
{
    public Material whiteColor;
    GameObject parentCube;
    GameObject gameManager;
    int numberOfList;
    public bool isFinishLine;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        parentCube = GameObject.Find("MyParentCube");
        numberOfList = 0;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Unstack"))
        {

            other.gameObject.tag = "Usable";
            this.transform.GetComponent<StackController>().characterPos -= new Vector3(0, .5f, 0);
            parentCube.gameObject.transform.GetChild(1).transform.DOLocalMove(this.transform.GetComponent<StackController>().characterPos, 0f);

            this.transform.GetComponent<StackController>().stackPos -= new Vector3(0, .5f, 0);

            Destroy(StackList.instance.stack[StackList.instance.stack.Count - 1].gameObject);
            StackList.instance.stack.RemoveAt(StackList.instance.stack.Count - 1);

            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
            if (isFinishLine)
            {
                gameManager.GetComponent<GameManager>().score++;
            }
            

        }


    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Usable"))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().material = whiteColor;
            other.gameObject.transform.GetComponent<BoxCollider>().enabled = false;

        }

    }







}
