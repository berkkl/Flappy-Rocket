using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 3f;
    [SerializeField] AudioClip crashClip;
    [SerializeField] AudioClip successClip;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;


    bool isTransitioning = false;

    AudioSource audioSource;
    ParticleSystem particleSystem;

    void Start()    
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
        {
            return;
        }   

        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("Friendly Object");
                break;
            case "Fuel":
                Debug.Log("Fuelled up!");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;

        isTransitioning = true;
        audioSource.PlayOneShot(successClip);

        successParticle.Play();

        Debug.Log("success");

        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;

        isTransitioning = true;
        audioSource.PlayOneShot(crashClip);

        crashParticle.Play();

        Invoke("ReloadCurrentLevel", levelLoadDelay);
    }

    void ReloadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
