
import os
from FieldFormat import FieldFormat
from Config import KEY_MODIFIER_NAME
from Config import EXCEL_DIR
from Config import UnityCodeDir

class UnityCodeGen:

    @staticmethod
    def Tab(count):
        return "    " * count;

    # 代码生成函数
    @staticmethod
    def Process(filepath, fields, table):

        # -----------------------table cfg class-----------------------
        filecontent = "\n"
        filecontent += "using System.Collections.Generic;\n"
        filecontent += "using System.IO;\n"
        filecontent += "using System.Text;\n"
        filecontent += "using UnityEngine;\n"
        filecontent += "\n"

        tablebasename = os.path.basename(filepath)
        tablebasename = tablebasename.split(".")[0]
        tableclassname = tablebasename + "Cfg"
        filecontent += "public class " + tableclassname + "\n"
        filecontent += "{\n"

        for index in fields:
            fielddesc = table.cell(0, index).value
            fieldtype = table.cell(2, index).value
            fieldname = table.cell(3, index).value
            fieldvar = FieldFormat.Type2format[fieldtype][1]
            filecontent += UnityCodeGen.Tab(1) + "public " + fieldvar + " " + fieldname + ";"
            filecontent += UnityCodeGen.Tab(1) + "//		" + fielddesc + "\n"

        # Deserialize函数
        filecontent += "\n"
        filecontent += UnityCodeGen.Tab(1) + "public void Deserialize (DynamicPacket packet)\n"
        filecontent += UnityCodeGen.Tab(1) + "{\n"

        for index in fields:
            fielddesc = table.cell(0, index).value
            fieldtype = table.cell(2, index).value
            fieldname = table.cell(3, index).value
            fieldfunc = FieldFormat.Type2format[fieldtype][2]
            filecontent += UnityCodeGen.Tab(2) + fieldname + " = " + fieldfunc + ";\n"

        filecontent += UnityCodeGen.Tab(1) + "}\n"
        filecontent += "}\n"

        # -----------------------table cfg manager class-----------------------
        filecontent += "\n"
        tableclassmgrname = tablebasename + "CfgMgr"
        filecontent += "public class " + tableclassmgrname + "\n"
        filecontent += "{\n"

        filecontent += UnityCodeGen.Tab(1) + "private static " + tableclassmgrname + " mInstance;\n"
        filecontent += UnityCodeGen.Tab(1) + "\n"
        filecontent += UnityCodeGen.Tab(1) + "public static " + tableclassmgrname + " Instance\n"
        filecontent += UnityCodeGen.Tab(1) + "{\n"
        filecontent += UnityCodeGen.Tab(2) + "get\n"
        filecontent += UnityCodeGen.Tab(2) + "{\n"
        filecontent += UnityCodeGen.Tab(3) + "if (mInstance == null)\n"
        filecontent += UnityCodeGen.Tab(3) + "{\n"
        filecontent += UnityCodeGen.Tab(4) + "mInstance = new " + tableclassmgrname + "();\n"
        filecontent += UnityCodeGen.Tab(3) + "}\n"
        filecontent += UnityCodeGen.Tab(3) + "\n"
        filecontent += UnityCodeGen.Tab(3) + "return mInstance;\n"
        filecontent += UnityCodeGen.Tab(2) + "}\n"
        filecontent += UnityCodeGen.Tab(1) + "}\n"

        # 获得keylist
        keylist = []
        for index in fields:
            value = table.cell(4, index).value
            if value == KEY_MODIFIER_NAME:
                keylist.append(index)

        # 根据keylist判断
        keylen = keylist.__len__()
        uselist = (keylen != 1)
        filecontent += "\n"
        if uselist:
            filecontent += UnityCodeGen.Tab(1) + "private List<{0}> mList = new List<{0}>();\n".format(tableclassname)
        else:
            fieldtype = table.cell(2, keylist[0]).value
            keytype = FieldFormat.Type2format[fieldtype][1]
            filecontent += UnityCodeGen.Tab(1) + "private Dictionary<{0}, {1}> mDict = new Dictionary<{0}, {1}>();\n".format(keytype, tableclassname)

        filecontent += UnityCodeGen.Tab(1) + "\n"
        if uselist:
            filecontent += UnityCodeGen.Tab(1) + "public List<{0}> List\n".format(tableclassname)
        else:
            filecontent += UnityCodeGen.Tab(1) + "public Dictionary<{0}, {1}> Dict\n".format(keytype, tableclassname)
        filecontent += UnityCodeGen.Tab(1) + "{\n"
        if uselist:
            filecontent += UnityCodeGen.Tab(2) + "get {return mList;}\n"
        else:
            filecontent += UnityCodeGen.Tab(2) + "get {return mDict;}\n"
        filecontent += UnityCodeGen.Tab(1) + "}\n"

        # Deserialize函数
        filecontent += "\n"
        filecontent += UnityCodeGen.Tab(1) + "public void Deserialize (DynamicPacket packet)\n"
        filecontent += UnityCodeGen.Tab(1) + "{\n"
        filecontent += UnityCodeGen.Tab(2) + "int num = (int)packet.PackReadInt32();\n"
        filecontent += UnityCodeGen.Tab(2) + "for (int i = 0; i < num; i++)\n"
        filecontent += UnityCodeGen.Tab(2) + "{\n"
        filecontent += UnityCodeGen.Tab(3) + tableclassname + " item = new " + tableclassname + "();\n"
        filecontent += UnityCodeGen.Tab(3) +  "item.Deserialize(packet);\n"
        if uselist:
            filecontent += UnityCodeGen.Tab(3) + "mList.Add(item);\n"
        else:
            keyname = table.cell(3, keylist[0]).value
            filecontent += UnityCodeGen.Tab(3) + "if (mDict.ContainsKey(item.{0}))\n".format(keyname)
            filecontent += UnityCodeGen.Tab(3) + "{\n"
            filecontent += UnityCodeGen.Tab(4) + "mDict[item.{0}] = item;\n".format(keyname)
            filecontent += UnityCodeGen.Tab(3) + "}\n"
            filecontent += UnityCodeGen.Tab(3) + "else\n"
            filecontent += UnityCodeGen.Tab(3) + "{\n"
            filecontent += UnityCodeGen.Tab(4) + "mDict.Add(item.{0}, item);\n".format(keyname)
            filecontent += UnityCodeGen.Tab(3) + "}\n"
        filecontent += UnityCodeGen.Tab(2) + "}\n"
        filecontent += UnityCodeGen.Tab(1) + "}\n"

        #  GetData函数
        if keylen == 1:     # 有一个key值使用dict取值
            fieldtype = table.cell(2, keylist[0]).value
            keytype = FieldFormat.Type2format[fieldtype][1]
            keyname = table.cell(3, keylist[0]).value
            filecontent += UnityCodeGen.Tab(1) + "\n"
            filecontent += UnityCodeGen.Tab(1) + "public {0} GetDataBy{1}({2} {3})\n".format(tableclassname, keyname, keytype, keyname.lower())
            filecontent += UnityCodeGen.Tab(1) + "{\n"
            filecontent += UnityCodeGen.Tab(2) + "if(mDict.ContainsKey({0}))\n".format(keyname.lower())
            filecontent += UnityCodeGen.Tab(2) + "{\n"
            filecontent += UnityCodeGen.Tab(3) + "return mDict[{0}];\n".format(keyname.lower())
            filecontent += UnityCodeGen.Tab(2) + "}\n"
            filecontent += UnityCodeGen.Tab(2) + "\n"
            filecontent += UnityCodeGen.Tab(2) + "return null;\n"
            filecontent += UnityCodeGen.Tab(1) + "}\n"
        elif keylen > 1:    # 有多个key值
            filecontent += UnityCodeGen.Tab(1) + "\n"
            filecontent += UnityCodeGen.Tab(1) + "public " + tableclassname + " GetDataBy"

            keycount = 0
            for keyindex in keylist:
                keyval = table.cell(3, keyindex).value
                filecontent += keyval
                if keycount < (keylen - 1):
                    filecontent += "And"
                keycount += 1

            filecontent += "("

            keycount = 0
            for keyindex in keylist:
                keytype = table.cell(2, keyindex).value
                keytype = FieldFormat.Type2format[keytype][1]
                keyval = table.cell(3, keyindex).value
                keyval = keyval.lower()
                filecontent += keytype + " " + keyval
                if keycount < (keylen - 1):
                    filecontent += ", "
                keycount += 1
            filecontent += ")\n"

            filecontent += UnityCodeGen.Tab(1) + "{\n"
            filecontent += UnityCodeGen.Tab(2) + "foreach (" + tableclassname + " data in mList)\n"
            filecontent += UnityCodeGen.Tab(2) + "{\n"

            filecontent += UnityCodeGen.Tab(3) + "if ("
            keycount = 0
            for keyindex in keylist:
                keyval1 = table.cell(3, keyindex).value
                keyval2 = keyval1.lower()
                filecontent += "data." + keyval1 + " == " + keyval2
                if keycount < (keylen - 1):
                    filecontent += " && "
                keycount += 1
            filecontent += ")\n"

            filecontent += UnityCodeGen.Tab(3) + "{\n"
            filecontent += UnityCodeGen.Tab(4) + "return data;\n"
            filecontent += UnityCodeGen.Tab(3) + "}\n"
            filecontent += UnityCodeGen.Tab(2) + "}\n"
            filecontent += UnityCodeGen.Tab(2) + "\n"
            filecontent += UnityCodeGen.Tab(2) + "return null;\n"
            filecontent += UnityCodeGen.Tab(1) + "}\n"

        filecontent += "}\n"

        # 保存
        path = filepath.replace(EXCEL_DIR, "")
        path = UnityCodeDir + path
        path = os.path.splitext(path)[0]
        path = path + ".cs"

        # 生成文件目录, 不重复创建目录
        filedir = os.path.dirname(path)
        if os.path.exists(filedir) == False:
            os.makedirs(filedir)

        file = open(path, "wb")
        file.write(filecontent.encode())
        file.close()

    # 生成配置管理类
    @staticmethod
    def GenConfigMangerCode(files):
        path = UnityCodeDir + "ConfigManager.cs"

        filecontent = "\n"
        filecontent += "using System.Collections;\n"
        filecontent += "using System.Collections.Generic;\n"
        filecontent += "using UnityEngine;\n"
        filecontent += "using System.IO;\n"
        filecontent += "\n"
        filecontent += "public class ConfigManager\n"
        filecontent += "{\n"

        # Deserialize函数
        filecontent += UnityCodeGen.Tab(1) + "private static void Deserialize(DynamicPacket dynamicPacket)\n"
        filecontent += UnityCodeGen.Tab(1) + "{\n"
        for file in files:
            tablebasename = os.path.basename(file)
            tablebasename = tablebasename.split(".")[0]
            filecontent += UnityCodeGen.Tab(2) + tablebasename + "CfgMgr.Instance.Deserialize(dynamicPacket);\n"
        filecontent += UnityCodeGen.Tab(1) + "}\n"

        # LoadCsv函数
        filecontent += UnityCodeGen.Tab(1) + "\n"
        filecontent += UnityCodeGen.Tab(1) + "public static void LoadConfig(string cfgdatapath)\n"
        filecontent += UnityCodeGen.Tab(1) + "{\n"
        filecontent += UnityCodeGen.Tab(2) + "FileStream fileStream = new FileStream(cfgdatapath, FileMode.Open, FileAccess.Read);\n"
        filecontent += UnityCodeGen.Tab(2) + "BinaryReader binaryReader = new BinaryReader(fileStream);\n"
        filecontent += UnityCodeGen.Tab(2) + "int cnt = binaryReader.ReadInt32();\n"
        filecontent += UnityCodeGen.Tab(2) + "byte[] bytes = binaryReader.ReadBytes(cnt);\n"
        filecontent += UnityCodeGen.Tab(2) + "DynamicPacket dynamicPacket = new DynamicPacket(bytes);\n"
        filecontent += UnityCodeGen.Tab(2) + "Deserialize(dynamicPacket);\n"
        filecontent += UnityCodeGen.Tab(2) + "binaryReader.Close();\n"
        filecontent += UnityCodeGen.Tab(2) + "fileStream.Close();\n"
        filecontent += UnityCodeGen.Tab(1) + "}\n"

        filecontent += "}\n"

        # 保存
        file = open(path, "wb")
        file.write(filecontent.encode())
        file.close()
