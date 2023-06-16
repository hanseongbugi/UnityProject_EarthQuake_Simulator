using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cshTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = Mathf.Floor(20-cshSceneToEnd.timer).ToString();
    }
}
