using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score;
    public MovementController movementController;
    public Image fingerPointer;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();

    }

    private void Update()
    {
        scoreText.text = score.ToString();
        if (movementController.swipeRight)
        {
            fingerPointer.gameObject.SetActive(false);
        }
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    

}
