using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{

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
