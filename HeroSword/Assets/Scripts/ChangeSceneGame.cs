using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneGame : MonoBehaviour
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
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput > 0)
        {
            PlayerChangeScenePosition.SetEntranceDirection("Derecha");
            SceneManager.LoadScene("Dungeon");
        }
        else if (horizontalInput < 0)
        {
            PlayerChangeScenePosition.SetEntranceDirection("Izquierda");
            SceneManager.LoadScene("Aldea");
        }
        else if (verticalInput > 0)
        {
            PlayerChangeScenePosition.SetEntranceDirection("Arriba");
            SceneManager.LoadScene("Dungeon");
        }
    }
}
