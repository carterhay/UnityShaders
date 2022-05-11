using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWater()
    {
        SceneManager.LoadScene("Water");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void OnCar()
    {
        SceneManager.LoadScene("CarPaint");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
