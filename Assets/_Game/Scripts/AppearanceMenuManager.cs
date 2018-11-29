using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppearanceMenuManager : MonoBehaviour {

    [SerializeField]
    GameObject[] menuThemes;

    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    Mesh[] sprites;

    [SerializeField]
    AudioClip startGameClip;

    AudioSource audioSource;

    GameObject player;
    GameObject body;

    int startingChoosenTheme;

    void Awake()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        body = player.transform.GetChild(0).gameObject;
        audioSource = player.GetComponentInChildren<AudioSource>();

        startingChoosenTheme = PlayerPrefsManager.GetChoosenEnvNumber();
        Instantiate(menuThemes[startingChoosenTheme], transform.position, Quaternion.identity);
    }

    private void Start()
    {
        body.transform.GetChild(0).GetComponent<MeshFilter>().mesh = sprites[PlayerPrefsManager.GetChoosenCarNumber()];
    }

    void OnChooseCar(int choosenCar)
    {
        body.transform.GetChild(0).GetComponent<MeshFilter>().mesh = sprites[choosenCar];
    }

    public void CheckForDifferentEnvironment()
    {
        if(startingChoosenTheme != PlayerPrefsManager.GetChoosenEnvNumber())
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void ClearEvent()
    {
        EventManager.EventChooseCar -= OnChooseCar;
    }

    public void AddEvent()
    {
        EventManager.EventChooseCar += OnChooseCar;
    }

    public void PlayStartAnimation()
    {
        StartCoroutine(StartAnimationRoutine());
    }

    public void PlayStartGameVoice()
    {
        audioSource.clip = startGameClip;
        audioSource.volume = 1f;
        audioSource.loop = false;
        audioSource.Play();
    }

    private IEnumerator StartAnimationRoutine()
    {
        yield return new WaitForSeconds(0.35f);
        Animator animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        animator.SetTrigger("StartGame");
    }
}
