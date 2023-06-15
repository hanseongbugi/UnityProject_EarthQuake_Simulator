using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cshSceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public string sceneName;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
