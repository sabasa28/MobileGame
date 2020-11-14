using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginManager : MonoBehaviour
{
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

    public int TestPlugin(int maxLvl)
    {

        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("You are not in android platform");
            return 9;//test
        }
        Save(maxLvl);
        return Load();
    }

    int Load()
    {
        AndroidJavaObject context = PluginClass.CallStatic<AndroidJavaObject>("mainActivity");
        return PluginInstance.Call<int>("getMaxLvl", context);
    }

    void Save(int maxLvl)
    {
        AndroidJavaObject activity = PluginClass.GetStatic<AndroidJavaObject>("mainActivity");
        PluginInstance.Call<int>("saveMaxLevel", new object[] { maxLvl,activity });
    }

}
