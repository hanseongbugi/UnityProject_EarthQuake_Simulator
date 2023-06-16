using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cshSceneToEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 20f; // �̵��� ������ �ð� (��)
    public string sceneName = "EndScene"; // �̵��� Scene�� �̸�
   
    static public float timer = 0f;
    private bool timerStarted = false;
	private void Start()
	{
        StartTimer();
	}
	private void Update()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= delay)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void StartTimer()
    {
        timer = 0f;
        timerStarted = true;
    }
}
