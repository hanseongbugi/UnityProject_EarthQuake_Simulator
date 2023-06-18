using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class cshSceneToEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 20f; // 이동을 지연할 시간 (초)
    public string sceneName = "EndScene"; // 이동할 Scene의 이름
    public Slider speedSlider;
    static public float timer = 0f;
    private bool timerStarted = false;
	private void Start()
	{
        StartTimer();
	}
	private void Update()
    {
        if (timerStarted&&speedSlider)
        {
            if (speedSlider.value > 0)
            {
                timer += Time.deltaTime*(speedSlider.value+1/11);
                //Debug.Log(timer);
                if (timer >= delay)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }

    public void StartTimer()
    {
        timer = 0f;
        timerStarted = true;
    }
}
