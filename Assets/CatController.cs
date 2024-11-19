using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    // Components for animation
    private Animator catAnimator;

    // Component to move the cat
    private Rigidbody catRigidBody;

    // Forward velocity
    private float velocityZ = 4f;
    // Sideways velocity
    private float velocityX = 3f;
    // Range of sideways movement
    private float movableRange = 1.5f;
    // Upward velocity
    private float velocityY = 3f;

    // Coefficient to decelerate movement
    private float coefficient = 0.995f;
    // Game end flag
    private bool isEnd = false;

    // AudioSource variable
    AudioSource audioSource;
    // Audio clips
    public AudioClip Success;
    public AudioClip Fail;
    public AudioClip Goal;

    // Numbers of each item obtained
    private int getFruitsNumber = 0;
    private int getFishNumber = 0;
    private int touchHurdleNumber = 0;
    // Texts to display numbers of obtained items
    private GameObject getFruitsNumberText;
    private GameObject getFishNumberText;
    private GameObject touchHurdleNumberText;

    // Final scores of each item
    private int fruitsScore = 0;
    private int fishScore = 0;
    private int hurdleScore = 0;
    private int totalScore = 0;

    // Scoreboards that are updated continuously while the cat is running
    private GameObject fruitScoreBoard;
    private GameObject fishScoreBoard;
    private GameObject hurdleScoreBoard;

    // Screen displayed upon reaching the goal
    private GameObject finalScoreBoardImage;
    private GameObject fruitsImage;
    private GameObject fishImage;
    private GameObject hurdleImage;
    private GameObject finalFruitsScoreText;
    private GameObject finalFishScoreText;
    private GameObject finalHurdleScoreText;
    private GameObject finalTotalScoreText;
    public GameObject retryButton;
    public GameObject homeButton;

    // Status of arrow button presses
    private bool isRightButtonDown = false;
    private bool isLeftButtonDown = false;
    private bool isJumpButtonDown = false;

    void Start()
    {
        // Get Animator component
        this.catAnimator = GetComponent<Animator>();

        // Start running animation
        GetComponent<Animator>().Play("Run");

        // Get Rigidbody component
        this.catRigidBody = GetComponent<Rigidbody>();

        // Get AudioSource component
        this.audioSource = GetComponent<AudioSource>();

        // Get the Scoreboard objects
        this.fruitScoreBoard = GameObject.Find("FruitScoreBoard");
        this.fishScoreBoard = GameObject.Find("FishScoreBoard");
        this.hurdleScoreBoard = GameObject.Find("HurdleScoreBoard");

        // Get Text objects for numbers of obtained items
        this.getFruitsNumberText = GameObject.Find("GetFruitsNumberText");
        this.getFishNumberText = GameObject.Find("GetFishNumberText");
        this.touchHurdleNumberText = GameObject.Find("TouchHurdleNumberText");

        // Get objects for displaying scores upon reaching the goal
        // Scoreboard
        this.finalScoreBoardImage = GameObject.Find("FinalScoreBoardImage");
        this.finalScoreBoardImage.GetComponent<Image>().enabled = false;
        // Icons for each item
        this.fruitsImage = GameObject.Find("FruitsImage");
        this.fruitsImage.GetComponent<Image>().enabled = false;
        this.fishImage = GameObject.Find("FishImage");
        this.fishImage.GetComponent<Image>().enabled = false;
        this.hurdleImage = GameObject.Find("HurdleImage");
        this.hurdleImage.GetComponent<Image>().enabled = false;
        // Scores for each item
        this.finalFruitsScoreText = GameObject.Find("FinalFruitsScoreText");
        this.finalFishScoreText = GameObject.Find("FinalFishScoreText");
        this.finalHurdleScoreText = GameObject.Find("FinalHurdleScoreText");
        // Total score
        this.finalTotalScoreText = GameObject.Find("FinalTotalScoreText");
        // Retry button
        this.retryButton.SetActive(false);
        // Home button
        this.homeButton.SetActive(false);
    }

    void Update()
    {
        // Decelerate cat's movement if game is over
        if (this.isEnd == true)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.catAnimator.speed *= coefficient;
        }

        // Sideways velocity based on input
        float inputVelocityX = 0;
        // Upward velocity based on input
        float inputVelocityY = 0;

        // Move left or right when corresponding arrow key is pressed
        if ((Input.GetKey(KeyCode.RightArrow) || this.isRightButtonDown) && this.transform.position.x < this.movableRange)
        {
            // Assign velocity to move right
            inputVelocityX = this.velocityX;
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || this.isLeftButtonDown) && -this.movableRange < this.transform.position.x)
        {
            // Assign velocity to move left
            inputVelocityX = -this.velocityX;
        }

        // Jump when spacebar is pressed
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJumpButtonDown) && this.transform.position.y < 0.5f)
        {
            this.catAnimator.SetBool("Jump", true);
            inputVelocityY = this.velocityY;
        }
        else
        {
            // Assign current Y-axis velocity
            inputVelocityY = this.catRigidBody.velocity.y;
        }

        // Set Jump to false if currently jumping
        if (this.catAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.catAnimator.SetBool("Jump", false);
        }
        // Apply velocity to the cat
        this.catRigidBody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);
    }

    // Execute processing when colliding with objects in Trigger mode
    void OnTriggerEnter(Collider other)
    {
        // If colliding with fruits
        if (other.gameObject.tag == "FruitsTag")
        {
            // Play particle effect
            GetComponent<ParticleSystem>().Play();
            // Play success sound
            audioSource.PlayOneShot(Success);
            // Increment obtained item count
            this.getFruitsNumber += 1;
            // Display obtained item count on Text
            this.getFruitsNumberText.GetComponent<Text>().text = "× " + this.getFruitsNumber;
            // Destroy collided item
            Destroy(other.gameObject);
        }

        // If colliding with fish
        if (other.gameObject.tag == "FishTag")
        {
            // Play particle effect
            GetComponent<ParticleSystem>().Play();
            // Play success sound
            audioSource.PlayOneShot(Success);
            // Increment obtained item count
            this.getFishNumber += 1;
            // Display obtained item count on Text
            this.getFishNumberText.GetComponent<Text>().text = "× " + this.getFishNumber;
            // Destroy collided item
            Destroy(other.gameObject);
        }

        // If reaching the goal
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            // Play goal sound
            audioSource.PlayOneShot(Goal);

            // Hide the scoreboards when the cat reaches the goal
            fruitScoreBoard.SetActive(false);
            fishScoreBoard.SetActive(false);
            hurdleScoreBoard.SetActive(false);
        }

        // Display score screen when reaching the goal + 5f
        if (other.gameObject.tag == "ScoreAppearTag")
        {
            // Calculate final scores
            this.fruitsScore = 10 * this.getFruitsNumber;
            this.fishScore = 30 * this.getFishNumber;
            this.hurdleScore = -20 * this.touchHurdleNumber;
            this.totalScore = this.fruitsScore + this.fishScore + this.hurdleScore;

            // Display score screen
            // Scoreboard
            this.finalScoreBoardImage.GetComponent<Image>().enabled = true;
            // Icons for each item
            this.fruitsImage.GetComponent<Image>().enabled = true;
            this.fishImage.GetComponent<Image>().enabled = true;
            this.hurdleImage.GetComponent<Image>().enabled = true;
            // Scores for each item
            this.finalFruitsScoreText.GetComponent<Text>().text = "10pt × " + this.getFruitsNumber + " = " + this.fruitsScore + "pt";
            this.finalFishScoreText.GetComponent<Text>().text = "30pt × " + this.getFishNumber + " = " + this.fishScore + "pt";
            this.finalHurdleScoreText.GetComponent<Text>().text = "<color=#ff0000>-20pt</color> × " + this.touchHurdleNumber + " = " + "<color=#ff0000>" + this.hurdleScore + "pt</color>";
            // Total score
            if (totalScore < 0)
            {
                this.finalTotalScoreText.GetComponent<Text>().text = "YOUR SCORE  " + "<color=#ff0000>" + this.totalScore + "pt</color>";
            }
            else
            {
                this.finalTotalScoreText.GetComponent<Text>().text = "YOUR SCORE  " + this.totalScore + "pt";
            }
            // Retry button
            this.retryButton.SetActive(true);
            // Home button
            this.homeButton.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // If colliding with hurdles
        if (other.gameObject.tag == "HurdleTag")
        {
            // Play failure sound
            audioSource.PlayOneShot(Fail);
            // Increment hurdle collision count
            this.touchHurdleNumber += 1;
            // Display collision count on Text
            this.touchHurdleNumberText.GetComponent<Text>().text = "× " + this.touchHurdleNumber;
        }
    }

    // Process when right arrow button is pressed
    public void GetRightButtonDown()
    {
        this.isRightButtonDown = true;
    }

    // Process when right arrow button is released
    public void GetRightButtonUp()
    {
        this.isRightButtonDown = false;
    }

    // Process when left arrow button is pressed
    public void GetLeftButtonDown()
    {
        this.isLeftButtonDown = true;
    }

    // Process when left arrow button is released
    public void GetLeftButtonUp()
    {
        this.isLeftButtonDown = false;
    }

    // Process when jump button is pressed
    public void GetJumpButtonDown()
    {
        this.isJumpButtonDown = true;
    }

    // Process when jump button is released
    public void GetJumpButtonUp()
    {
        this.isJumpButtonDown = false;
    }
}
