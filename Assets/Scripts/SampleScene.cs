using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SampleScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button button3 = root.Q<Button>("Button3");
        Button button5 = root.Q<Button>("Button5");
        Button button10 = root.Q<Button>("Button10");

        button3.clicked += () => SceneManager.LoadScene(sceneName: "Scene3");
        button5.clicked += () => SceneManager.LoadScene(sceneName: "Scene5");
        button10.clicked += () => SceneManager.LoadScene(sceneName: "Scene10");
    }
}
