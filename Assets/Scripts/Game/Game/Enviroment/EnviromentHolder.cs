using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] backGrounds = null;
    // Start is called before the first frame update
    void Start()
    {
        ActiveRandomBackground();
    }

    public void ActiveRandomBackground()
    {
        int random = Random.Range(0, backGrounds.Length);
        for (int i = 0; i < backGrounds.Length; i++)
        {
            backGrounds[i].SetActive(random == i);
        }
    }
    void Update()
    {
        
    }
}
