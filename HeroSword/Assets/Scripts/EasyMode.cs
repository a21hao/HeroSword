using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyMode : MonoBehaviour
{
    public void SetDamageTo100()
    {
        DamageManager.Damage = 100;
    }
}
