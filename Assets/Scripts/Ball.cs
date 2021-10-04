
using UnityEngine;




public class Ball : MonoBehaviour
{

    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2;
    [SerializeField] float yPush = 15;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        
       
    }
       


    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }
        
        
      

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {


        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {


            // 1. At first we creata a variable at the top of this Script -->   [SerializeField] AudioClip[] ballSounds;
            // 2. Cache or save AudioSource Component --> AudioSource = myAudioSource; and in Start function --> myAudioSource = GetComponent<AudioSource>();
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip, 1);
            rb.velocity += velocityTweak;
        }
        
    }
}
