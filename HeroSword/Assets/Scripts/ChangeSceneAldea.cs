using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAldea : MonoBehaviour
{
    public string leftSceneName = "SceneOnLeft";
    public string rightSceneName = "SceneOnRight";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            PlayerChangeScenePosition.SetEntranceDirection("Derecha");
            SceneManager.LoadScene("Game");
        }
        else if (horizontalInput < 0)
        {
            PlayerChangeScenePosition.SetEntranceDirection("Izquierda");
            SceneManager.LoadScene("Game");
        }
    }
}
