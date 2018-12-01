using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class LevelManager : MonoBehaviour 
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void QuitRequest()
	{
		Application.Quit ();

	}
	public void LoadLevel()
	{
        Invoke("LoadWithDelay", 0.7f);
	}
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadWithDelay()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(CrossPlatformInputManager.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }

}
