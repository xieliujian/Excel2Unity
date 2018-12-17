
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 表格生成公共函数
/// </summary>
public class SheetGenCommonFunc
{
    public static List<int> GetListInt(string str, char split = ';')
    {
        List<int> templist = new List<int>();
        if (str == "NULL")
        {
            return templist;
        }
        string[] strs = str.Split(split);
        foreach (var i in strs)
        {
            templist.Add(int.Parse(i));
        }

        return templist;
    }

    public static List<float> GetListFloat(string str, char split = ';')
    {
        List<float> templist = new List<float>();
        string[] strs = str.Split(split);
        foreach (var i in strs)
        {
            templist.Add(float.Parse(i));
        }

        return templist;
    }

    public static List<string> GetListString(string str, char split = ';')
    {
        List<string> templist = new List<string>();
        string[] strs = str.Split(split);
        foreach (var i in strs)
        {
            templist.Add(i);
        }

        return templist;
    }

    public static Dictionary<int, int> GetDictIntInt(string str, char split1 = '|', char split2 = ';')
    {
        Dictionary<int, int> tempdict = new Dictionary<int, int>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            string[] strs1 = i.Split(split2);
            int id = 0;
            if (!string.IsNullOrEmpty(strs1[0]))
            {
                id = int.Parse(strs1[0]);
            }
            int value = 0;
            if (strs1.Length > 1)
            {
                value = int.Parse(strs1[1]);
            }
            tempdict.Add(id, value);
        }

        return tempdict;
    }

    public static Dictionary<int, float> GetDictIntFloat(string str, char split1 = '|', char split2 = ';')
    {
        Dictionary<int, float> tempdict = new Dictionary<int, float>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            string[] strs1 = i.Split(split2);
            int id = 0;
            if (!string.IsNullOrEmpty(strs1[0]))
            {
                id = int.Parse(strs1[0]);
            }
            float value = 0f;
            if (strs1.Length > 1)
            {
                value = float.Parse(strs1[1]);
            }
            tempdict.Add(id, value);
        }

        return tempdict;
    }

    public static Dictionary<int, string> GetDictIntString(string str, char split1 = '|', char split2 = ';')
    {
        Dictionary<int, string> tempdict = new Dictionary<int, string>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            string[] strs1 = i.Split(split2);
            int id = 0;
            if (!string.IsNullOrEmpty(strs1[0]))
            {
                id = int.Parse(strs1[0]);
            }
            string value = string.Empty;
            if (strs1.Length > 1)
            {
                value = strs1[1];
            }
            tempdict.Add(id, value);
        }

        return tempdict;
    }

    public static Dictionary<string, int> GetDictStringInt(string str, char split1 = '|', char split2 = ';')
    {
        Dictionary<string, int> tempdict = new Dictionary<string, int>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            string[] strs1 = i.Split(split2);
            string id = strs1[0];
            int value = 0;
            if (strs1.Length > 1)
            {
                value = int.Parse(strs1[1]);
            }
            tempdict.Add(id, value);
        }

        return tempdict;
    }

    public static Dictionary<string, float> GetDictStringFloat(string str, char split1 = '|', char split2 = ';')
    {
        Dictionary<string, float> tempdict = new Dictionary<string, float>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            string[] strs1 = i.Split(split2);
            string id = strs1[0];
            float value = 0f;
            if (strs1.Length > 1)
            {
                value = float.Parse(strs1[1]);
            }
            tempdict.Add(id, value);
        }

        return tempdict;
    }

    public static Dictionary<string, string> GetDictStringString(string str, char split1 = '|', char split2 = ';')
    {
        Dictionary<string, string> tempdict = new Dictionary<string, string>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            string[] strs1 = i.Split(split2);
            string id = strs1[0];
            string value = string.Empty;
            if (strs1.Length > 1)
            {
                value = strs1[1];
            }
            tempdict.Add(id, value);
        }

        return tempdict;
    }

    public static Vector2 GetVector2(string str, char split = ';')
    {
        string[] strs = str.Split(split);
        return new Vector2(float.Parse(strs[0]), float.Parse(strs[1]));
    }

    public static Vector3 GetVector3(string str, char split = ';')
    {
        string[] strs = str.Split(split);
        return new Vector3(float.Parse(strs[0]), float.Parse(strs[1]), float.Parse(strs[2]));
    }

    public static Vector4 GetVector4(string str, char split = ';')
    {
        string[] strs = str.Split(split);
        return new Vector4(float.Parse(strs[0]), float.Parse(strs[1]), float.Parse(strs[2]), float.Parse(strs[3]));
    }

    public static List<Vector2> GetListVector2(string str, char split1 = '|', char split2 = ';')
    {
        List<Vector2> templist = new List<Vector2>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            if (i.Length <= 0)
                continue;

            templist.Add(GetVector2(i, split2));
        }

        return templist;
    }

    public static List<Vector3> GetListVector3(string str, char split1 = '|', char split2 = ';')
    {
        List<Vector3> templist = new List<Vector3>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            templist.Add(GetVector3(i, split2));
        }

        return templist;
    }

    public static List<Vector4> GetListVector4(string str, char split1 = '|', char split2 = ';')
    {
        List<Vector4> templist = new List<Vector4>();
        string[] strs = str.Split(split1);
        foreach (var i in strs)
        {
            templist.Add(GetVector4(i, split2));
        }

        return templist;
    }
}
