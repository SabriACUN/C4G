using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNum;

    private void OnTriggerEnter(Collider other)
    {
        LoadScene(sceneNum);
    }
    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
