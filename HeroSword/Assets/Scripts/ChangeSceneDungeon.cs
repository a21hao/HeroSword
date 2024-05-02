using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDungeon : MonoBehaviour
{
    public string upSceneName = "SceneAbove";
    public string downSceneName = "SceneBelow";

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
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            SceneManager.LoadScene(upSceneName);
        }
        else if (verticalInput < 0)
        {
            PlayerChangeScenePosition.SetEntranceDirection("Abajo");
            SceneManager.LoadScene("Game");
        }
    }
}
