using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCar : MonoBehaviour {

    [SerializeField] int carCost = 200;
    [SerializeField] int carNumber = 0;

    Text text;
    Button button;

    void Start()
    {
        PlayerPrefsManager.UnlockCar(0);
        text = GetComponentInChildren<Text>();
        text.text = carCost.ToString();

        button = GetComponent<Button>();

        if (PlayerPrefsManager.IsCarUnlocked(carNumber))
        {
            text.enabled = false;
        }
    }

    private void Update()
    {
        if (PlayerPrefsManager.GetChoosenCarNumber() != carNumber)
        {
            button.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void OnClick()
    {
        if (carCost <= PlayerPrefsManager.GetNumberOfCoins() && !PlayerPrefsManager.IsCarUnlocked(carNumber))
        {
            text.enabled = false;
            PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() - carCost);
            PlayerPrefsManager.UnlockCar(carNumber);

            EventManager.RaiseEventCoinSubstracted();
        }
        else if(PlayerPrefsManager.IsCarUnlocked(carNumber))
        {
            PlayerPrefsManager.ChooseCar(carNumber);
            button.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.7f);

            EventManager.RaiseEventChooseCar(carNumber);
        }
    }
}
