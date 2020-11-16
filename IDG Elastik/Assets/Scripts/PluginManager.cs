using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginManager : MonoBehaviour
{
    private static PluginManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static PluginManager Get()
    {
        return instance;
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    const string PLUGIN_NAME = "com.diez.megaloader.Loader";
    static AndroidJavaClass _pluginClass = null;

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(PLUGIN_NAME);
                AndroidJavaClass unityJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityJC.GetStatic<AndroidJavaObject>("currentActivity");
                _pluginClass.SetStatic("mainActivity", activity);
            }
            return _pluginClass;
        }
    }
    static AndroidJavaObject _pluginInstance = null;
    public AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }

    public int GetLvlsPassed()
    {
        return PluginInstance.Call<int>("getMaxLevel");
    }

    public void SaveLvlsPassed(int maxLvl)
    {
        PluginInstance.Call("saveMaxLevel", maxLvl);
    }

}
