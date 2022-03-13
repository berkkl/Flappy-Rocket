using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Object");
                break;
            case "Obstacle":
                Debug.Log("You hit the obstacle!");
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
