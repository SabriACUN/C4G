using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationTimer());
    }

    public IEnumerator AnimationTimer()
    {
        yield return new WaitForSecondsRealtime(25);
        SceneManager.LoadScene(1);
    }
}
