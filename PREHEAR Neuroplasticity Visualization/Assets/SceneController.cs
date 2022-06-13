using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public enum SceneName { ItemsScene, BrainScene}
    public SceneName sceneName;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}