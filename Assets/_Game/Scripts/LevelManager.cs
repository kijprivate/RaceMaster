using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    [SerializeField]
    GameObject player;

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
        player.GetComponent<Animator>().SetTrigger("StartGame");
        Invoke("LoadWithDelay", 0.7f);
	}
    public void LoadWithDelay()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
