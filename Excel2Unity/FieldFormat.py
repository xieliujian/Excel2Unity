
class FieldFormat:
    Type2format = {
        "int": ("i", "int", "packet.PackReadInt32()"),
        "float": ("f", "float", "packet.PackReadFloat()"),
        "bool": ("?", "bool", "packet.PackReadBoolean()"),
        "string": ("s", "string", "packet.PackReadString()"),

        "list[int]": ("s", "List<int>", "SheetGenCommonFunc.GetListInt(packet.PackReadString())"),
        "list[float]": ("s", "List<float>", "SheetGenCommonFunc.GetListFloat(packet.PackReadString())"),
        "list[string]": ("s", "List<string>", "SheetGenCommonFunc.GetListString(packet.PackReadString())"),

        "map[int|int]": ("s", "Dictionary<int, int>", "SheetGenCommonFunc.GetDictIntInt(packet.PackReadString())"),
        "map[int|float]": ("s", "Dictionary<int, float>", "SheetGenCommonFunc.GetDictIntFloat(packet.PackReadString())"),
        "map[int|string]": ("s", "Dictionary<int, string>", "SheetGenCommonFunc.GetDictIntString(packet.PackReadString())"),

        "map[string|int]": ("s", "Dictionary<string, int>", "SheetGenCommonFunc.GetDictStringInt(packet.PackReadString())"),
        "map[string|float]": ("s", "Dictionary<string, float>", "SheetGenCommonFunc.GetDictStringFloat(packet.PackReadString())"),
        "map[string|string]": ("s", "Dictionary<string, string>", "SheetGenCommonFunc.GetDictStringString(packet.PackReadString())")
    }