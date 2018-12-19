
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Test3Cfg
{
    public int ID;    //		int类型
    public float HP;    //		float类型
    public bool HasUse;    //		bool类型
    public string Name1;    //		string类型
    public string Name2;    //		string类型
    public List<int> Vec1;    //		int数组
    public List<float> Vec2;    //		float数组
    public List<string> Vec4;    //		string数组
    public Dictionary<int, int> Map1;    //		intint字典
    public Dictionary<int, float> Map2;    //		intfloat字典
    public Dictionary<int, string> Map4;    //		intstring字典
    public Dictionary<string, int> Map5;    //		stringint字典
    public Dictionary<string, float> Map6;    //		stringfloat字典
    public Dictionary<string, string> Map8;    //		stringstring字典

    public void Deserialize (DynamicPacket packet)
    {
        ID = packet.PackReadInt32();
        HP = packet.PackReadFloat();
        HasUse = packet.PackReadBoolean();
        Name1 = packet.PackReadString();
        Name2 = packet.PackReadString();
        Vec1 = SheetGenCommonFunc.GetListInt(packet.PackReadString());
        Vec2 = SheetGenCommonFunc.GetListFloat(packet.PackReadString());
        Vec4 = SheetGenCommonFunc.GetListString(packet.PackReadString());
        Map1 = SheetGenCommonFunc.GetDictIntInt(packet.PackReadString());
        Map2 = SheetGenCommonFunc.GetDictIntFloat(packet.PackReadString());
        Map4 = SheetGenCommonFunc.GetDictIntString(packet.PackReadString());
        Map5 = SheetGenCommonFunc.GetDictStringInt(packet.PackReadString());
        Map6 = SheetGenCommonFunc.GetDictStringFloat(packet.PackReadString());
        Map8 = SheetGenCommonFunc.GetDictStringString(packet.PackReadString());
    }
}

public class Test3CfgMgr
{
    private static Test3CfgMgr mInstance;
    
    public static Test3CfgMgr Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new Test3CfgMgr();
            }
            
            return mInstance;
        }
    }

    private List<Test3Cfg> mList = new List<Test3Cfg>();
    
    public List<Test3Cfg> List
    {
        get {return mList;}
    }

    public void Deserialize (DynamicPacket packet)
    {
        int num = (int)packet.PackReadInt32();
        for (int i = 0; i < num; i++)
        {
            Test3Cfg item = new Test3Cfg();
            item.Deserialize(packet);
            mList.Add(item);
        }
    }
    
    public Test3Cfg GetDataByIDAndName1(int id, string name1)
    {
        foreach (Test3Cfg data in mList)
        {
            if (data.ID == id && data.Name1 == name1)
            {
                return data;
            }
        }
        
        return null;
    }
}
