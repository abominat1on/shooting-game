using System.Collections;
using System.Collections.Generic;
using Core.State;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private TMP_Text ammoText = null;
    private int ammoCount;

    void Update()
    {
        var levelController = GameObject.FindObjectOfType<LevelController>();
        ammoCount = levelController.ammo;
        ammoText.text = "x" + ammoCount;
        if (Input.GetMouseButtonDown(0))
        {
            ammoCount--;
            ammoText.text = "x" + ammoCount;
            if (ammoCount <= 0)
            {
                ammoCount = 0;
            }
        }
    }
}
