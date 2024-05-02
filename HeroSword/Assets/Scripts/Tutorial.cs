using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogBoxText;
    private float destroyTime = 8f;

    void Start()
    {
        Destroy(dialogBox, destroyTime);
    }
}
