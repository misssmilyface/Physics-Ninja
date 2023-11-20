using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // add this so you can actually use the buttons

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager; // get GameManager script.
    public int difficulty; // setting the difficulty range.
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty); // the button has an onClick() method that will listen (AddListener()) when it gets clicked.
                                                   // when clicked the listener will go straight to our SetDifficulty() method.
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // get GameManager script.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was clicked"); // when you click a button, the name of the button + "was clicked" will appear in the console area.
        gameManager.StartGame(difficulty); // we want our game to start when we click a button.
                                           // we add difficulty in because when one of the buttons is pressed, it'll send in that difficulty to StartGame(), then to GameManager, then to use the updated spawnRate to spawn objects faster or slower.
    }
}
