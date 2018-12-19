
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager
{
    private static void Deserialize(DynamicPacket dynamicPacket)
    {
        Test1CfgMgr.Instance.Deserialize(dynamicPacket);
        Test2CfgMgr.Instance.Deserialize(dynamicPacket);
        Test3CfgMgr.Instance.Deserialize(dynamicPacket);
    }
    
    public static void LoadConfig(string cfgdatapath)
    {
        FileStream fileStream = new FileStream(cfgdatapath, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new BinaryReader(fileStream);
        int cnt = binaryReader.ReadInt32();
        byte[] bytes = binaryReader.ReadBytes(cnt);
        DynamicPacket dynamicPacket = new DynamicPacket(bytes);
        Deserialize(dynamicPacket);
        binaryReader.Close();
        fileStream.Close();
    }
}
