using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level // Single level
{
    public List<string> m_Rows = new List<string>(); // Rows of text define level

    public int Height
    {
        get
        {
            return m_Rows.Count; // Height of Level is defined by number of rows of text file
        }
    }

    public int Width
    {
        get
        {
            int maxLength = 0;
            foreach (var row in m_Rows)
            {
                if (row.Length > maxLength)
                {
                    maxLength = row.Length; // Longest line defines width of level so we need to find the max and return it
                }
            }
            return maxLength;
        }
    }
}


public class Levels : MonoBehaviour
{
    public string filename;
    public List<Level> m_Levels;

    void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(filename);
        if (!textAsset)
        {
            Debug.Log("Levels: " + filename + ".txt does not exist!");
            return;
        }
        else
        {
            Debug.Log("Levels imported");
        }

        string completeText = textAsset.text;
        string[] lines = completeText.Split(new string[] { "\n" }, System.StringSplitOptions.None);

        m_Levels = new List<Level>();
        m_Levels.Add(new Level());

        for (long i = 0; i < lines.LongLength; i++)
        {
            string line = lines[i];
            if (line.StartsWith(";"))
            {
                Debug.Log("New level added");
                m_Levels.Add(new Level());
                continue;
            }
            m_Levels[m_Levels.Count - 1].m_Rows.Add(line);
        }
    }
}