using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    private static TimeManager _instance;
    public int TimeScale { get; set; }

    public static TimeManager Instance {
        get
        {
            if (_instance == null) _instance = new TimeManager() { TimeScale = 1 };
            return _instance;
        } 
    }
    
}
