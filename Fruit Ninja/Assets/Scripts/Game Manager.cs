using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;// importing a Text Mesh Pro
using UnityEngine.SceneManagement; //this will let us manage our scene and load them in (this counts as a library)
using UnityEngine.UI; // this will make us able to interact with the buttons

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public GameObject titleScreen;
    public List<GameObject> targets; //similar to pubic GameObject[] targets;
                                     //List<>: we can pass in the type of thing that we want.
                                     //Array[]: we have to tell the array what the thing is before we make the array itself.

    public Button restartButton; // the type is Button
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive) // isGameActive = true
        { //while() loop: will keep on doing it until we give it a condition to stop.
          //for() loop: will iterate over smth a certain number of times.
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count); //getting a random object. Count is because we used List.
            Instantiate(targets[index]);// actually create our random object.
            //UpdateScore(5); // every time we spawn a new object, the score would add 5 points to it.
        }
        
    }
    public void UpdateScore(int scoreToAdd)// scoreToAdd: the score that we add into our current score every time.
    {
        score+= scoreToAdd; // updating the score.
        scoreText.text = "Score: " + score; // ":" = colon
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true); // we want our restart button to pop up when the game is over, if we put this line down in our RestartGame() method, the button wouldn't appear because we can't restart the game if there's no button.
        gameOverText.gameObject.SetActive(true); // testing it out to see if Game Over pops up on the screen.
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //getting the scene manager class (because we have the "UnityEngine.SceneManagement" library),
                                                                    // the class lets us use the LoadScene() method, which in our case is using a string to find our name of the scene that we want to load,
                                                                    // our SceneManager knows which scene is active right now(GetActiveScene()), and then we grab the name of our scene.
                                                                    // in our Hirearchy, you have to use the on click() list, add a new event when the button is clicked, place your Game Manager in, on the right box, you'll find all the methods and variables that you can use.
                                                                    // and in our case we need to use the RestartGame() method to restart our game when the button is clikced.
    }

    public void StartGame(int difficulty) // we put all that was in our Start() method here, so DifficultyButton.cs can find it and set it to when we press any button on the screen to start game.
    {                                     // adding difficulty to the StartGame() will take all of our button's difficulties to matter. (Easy: 1, Medium: 2, Hard: 3)
        titleScreen.gameObject.SetActive(false); // setting this to false would make our Title Screen go away.
        isGameActive = true; // setting the isGameActive to true when we first start the game.
        score = 0 ;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);// first time it's running so we put 0.
        spawnRate /= difficulty; // spawnRate = spawnRate / difficulty. making the objects spawn faster.
                                 /*
                                 easy: 1 / 1 = 1sec.
                                 medium: 1 / 2 = 0.5sec.
                                 hard: 1 / 3 = 0.33sec.
                                 */
    }
}
