using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public int sceneId;
    public Slider slider;
    public Sprite[] sprites;
    public Image background;

    void Start()
    {
        int item = Random.Range(0, sprites.Length-1);
        background.sprite = sprites[item];
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    public IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }

    
}
