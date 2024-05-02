using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChangeScenePosition : MonoBehaviour
{
    public static string entranceDirection;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Aldea")
        {
            if (entranceDirection == "Derecha")
            {
                transform.position = new Vector3(4.19f, 0f, 0f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Game")
        {
            if (entranceDirection == "Abajo")
            {
                transform.position = new Vector3(7.33f, 0f, 0f);
            }
        }
    }

    public static void SetEntranceDirection(string direction)
    {
        entranceDirection = direction;
    }
}
