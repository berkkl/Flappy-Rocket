using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("Friendly Object");
                break;
            case "Fuel":
                Debug.Log("Fuelled up!");
                break;
            case "Finish":
                Debug.Log("You succesfully finish the game!");
                break;
            default:
                ReloadScreen();
                break;
        }
    }

    void ReloadScreen()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
