using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI coinSave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinSave.text = "coin : " + PlayerMove.saveCoin;
    }
}
