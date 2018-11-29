using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockEnvironment : MonoBehaviour {


    [SerializeField]
    int environmentCost = 5000;
    [SerializeField]
    int environmentNumber = 0;

    Text text;
    Button button;

    void Start () {
        PlayerPrefsManager.UnlockEnv(0);
        text = GetComponentInChildren<Text>();
        text.text = environmentCost.ToString();

        button = GetComponent<Button>();

        if (PlayerPrefsManager.IsEnvUnlocked(environmentNumber))
        {
            text.enabled = false;
        }
    }
	
	void Update () {
        if (PlayerPrefsManager.GetChoosenEnvNumber() != environmentNumber)
        {
            button.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void OnClick()
    {
        if (environmentCost <= PlayerPrefsManager.GetNumberOfCoins() && !PlayerPrefsManager.IsEnvUnlocked(environmentNumber))
        {
            PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() - environmentCost);
            PlayerPrefsManager.UnlockEnv(environmentNumber);

            EventManager.RaiseEventCoinSubstracted();

            text.enabled = false;
        }
        else if (PlayerPrefsManager.IsEnvUnlocked(environmentNumber))
        {
            PlayerPrefsManager.ChooseEnv(environmentNumber);
            button.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.7f);

            //EventManager.RaiseEventChooseCar(carNumber);
        }
    }
}
