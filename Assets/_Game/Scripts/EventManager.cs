using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{

    public delegate void Event();
    public delegate void Event<A>(A arg1);

    // Two examples how to add new events:
    //
    //public static Event NewEvent;
    //public static void RaiseEventNewEvent()
    //{
    //    if (NewEvent != null) NewEvent();
    //}
    //
    //public static Event<int, bool> NewEvent;
    //public static void RaiseEventNewEvent(int howMany, bool isFinal)
    //{
    //    if (NewEvent != null) NewEvent(howMany, isFinal);
    //}

    public static Event EventMenuLoaded;
    public static void RaiseEventMenuLoaded()
    {
        if (EventMenuLoaded != null) EventMenuLoaded();
    }

    public static Event EventGameplayLoaded;
    public static void RaiseEventGameplayLoaded()
    {
        if (EventGameplayLoaded != null) EventGameplayLoaded();
    }

    public static Event EventGameStarted;
    public static void RaiseEventGameStarted()
    {
        if (EventGameStarted != null) EventGameStarted();
    }

    public static Event EventGameOver;
    public static void RaiseEventGameOver()
    {
        if (EventGameOver != null) EventGameOver();
    }

    public static Event EventCoinCollected;
    public static void RaiseEventCoinCollected()
    {
        if (EventCoinCollected != null) EventCoinCollected();
    }

    public static Event EventCoinSubstracted;
    public static void RaiseEventCoinSubstracted()
    {
        if (EventCoinSubstracted != null) EventCoinSubstracted();
    }

    public static Event<int> EventChooseCar;
    public static void RaiseEventChooseCar(int carNumber)
    {
        if (EventChooseCar != null) EventChooseCar(carNumber);
    }
}
