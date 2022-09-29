using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{

   // public static StackController instance;


    public Vector3 stackPos, characterPos;

    
    GameObject parentCube;
    GameObject gameManager;
    
    


    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        parentCube = GameObject.Find("MyParentCube");
        stackPos = Vector3.zero;
        characterPos = new Vector3(-0.0189999994f, 1.79999995f, -0.0329999998f);
    }

     

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            gameManager.GetComponent<GameManager>().score++;
            StackList.instance.stack.Add(other.gameObject);
            other.gameObject.tag = "Collected";
            other.gameObject.transform.parent = parentCube.gameObject.transform.GetChild(0).transform;
            characterPos += new Vector3(0, .5f, 0);
            parentCube.gameObject.transform.GetChild(1).transform.DOLocalMove(characterPos, 0f);
            other.gameObject.transform.DOLocalMove(stackPos, 0f);
            stackPos += new Vector3(0, .5f, 0);



        }
    }
}
