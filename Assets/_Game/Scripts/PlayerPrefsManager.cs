using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    const string CAR_KEY = "car_unlocked_";
    const string CHOSEN_CAR_KEY = "chosen_car_key_";

    const string ENV_KEY = "env_unlocked_";
    const string CHOSEN_ENV_KEY = "chosen_env_key_";

    const string NUMBER_COINS = "number of coins";
    const string HIGH_SCORE = "high score";
    const string GAMES_PLAYED = "games played";

    const string SOUND_ON = "sound_on";

    public static void SetNumberOfCoins(int value)
    {
        PlayerPrefs.SetInt(NUMBER_COINS, value);
    }

    public static int GetNumberOfCoins()
    {
        return PlayerPrefs.GetInt(NUMBER_COINS);
    }

    public static void SetHighScore(float value)
    {
        PlayerPrefs.SetFloat(HIGH_SCORE, value);
    }

    public static float GetHighScore()
    {
        return PlayerPrefs.GetFloat(HIGH_SCORE);
    }
    public static void SetGamesPlayed(int value)
    {
        PlayerPrefs.SetInt(GAMES_PLAYED, value);
    }

    public static int GetGamesPlayed()
    {
        return PlayerPrefs.GetInt(GAMES_PLAYED);
    }

    public static bool IsCarUnlocked(int carNumber)
    {
        int carValue = PlayerPrefs.GetInt(CAR_KEY + carNumber.ToString());
        bool isCarUnlocked = (carValue == 1);

        return isCarUnlocked;
    }

    public static void UnlockCar(int carNumber)
    {
        PlayerPrefs.SetInt(CAR_KEY + carNumber.ToString(), 1);
    }

    public static void ChooseCar(int carNumber)
    {
        PlayerPrefs.SetInt(CHOSEN_CAR_KEY, carNumber);
    }

    public static int GetChoosenCarNumber()
    {
        return PlayerPrefs.GetInt(CHOSEN_CAR_KEY);
    }

    public static void LockAllCars()
    {
        for (int i = 0; i < 30; i++)
            PlayerPrefs.SetInt(CAR_KEY + i.ToString(), 0);
    }

    public static bool IsEnvUnlocked(int envNumber)
    {
        int envValue = PlayerPrefs.GetInt(ENV_KEY + envNumber.ToString());
        bool isEnvUnlocked = (envValue == 1);

        return isEnvUnlocked;
    }

    public static void UnlockEnv(int envNumber)
    {
        PlayerPrefs.SetInt(ENV_KEY + envNumber.ToString(), 1);
    }

    public static void ChooseEnv(int envNumber)
    {
        PlayerPrefs.SetInt(CHOSEN_ENV_KEY, envNumber);
    }

    public static int GetChoosenEnvNumber()
    {
        return PlayerPrefs.GetInt(CHOSEN_ENV_KEY);
    }

    public static void LockAllEnvs()
    {
        for (int i = 0; i < 30; i++)
            PlayerPrefs.SetInt(ENV_KEY + i.ToString(), 0);
    }

    //public static void SetSoundOn()
    //{
    //    PlayerPrefs.SetInt(SOUND_ON, 1);

    //}
    //public static void SetSoundOff()
    //{
    //    PlayerPrefs.SetInt(SOUND_ON, 0);

    //}
    //public static bool IsSoundOn()
    //{
    //    int get = PlayerPrefs.GetInt(SOUND_ON);
    //    bool isSoundOn = (get == 1);

    //    return isSoundOn;

    //}
}
