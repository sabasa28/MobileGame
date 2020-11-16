package com.diez.megaloader;

import android.util.Log;
import android.app.Activity;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Loader {
    private static Loader _instance = null;
    public static Activity mainActivity;

    public static Loader getInstance()
    {
        if (_instance == null) {
            _instance = new Loader();
        }
        return _instance;
    }

    public void saveMaxLevel(int maxLvl)
    {
        File path = mainActivity.getFilesDir();
        //File path = context.getFilesDir();
        File file = new File(path, "maxlvl.txt");

        try
        {
            FileOutputStream stream = new FileOutputStream(file);
            try
            {
                stream.write(Integer.toString(maxLvl).getBytes());
            }
            finally
            {
                stream.close();
            }
        }
        catch (IOException e)
        {
            Log.e("Exception", "File write failed: " + e.toString());
        }
    }

    public int getMaxLevel()
    {
        File path = mainActivity.getFilesDir();

        File file = new File(path, "maxlvl.txt");
        if (!file.exists()) return 0;

        int length = (int) file.length();
        byte[] bytes = new byte[length];

        try
        {
            FileInputStream stream = new FileInputStream(file);
            try
            {
                stream.read(bytes);
            }
            finally
            {
                stream.close();
            }
        }
        catch (IOException e)
        {
            Log.e("Exception", "File write failed: " + e.toString());
        }

        String maxLvl = new String(bytes);
        return Integer.parseInt(maxLvl);
    }
}
