using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DynamicPacket
{
    //
    // Fields
    //
    public BinaryWriter mWriter;

    public BinaryReader mReader;

    public MemoryStream mMemStream;

    //
    // Constructors
    //
    public DynamicPacket(byte[] bytes)
        : this()
    {
        this.mMemStream.Write(bytes, 0, bytes.Length);
        this.mMemStream.Seek(0L, SeekOrigin.Begin);
    }

    public DynamicPacket(byte[] bytes, int offset, int count)
        : this()
    {
        this.mMemStream.Write(bytes, offset, count);
        this.mMemStream.Seek(0L, SeekOrigin.Begin);
    }

    public DynamicPacket()
    {
        this.mMemStream = new MemoryStream();
        this.mReader = new BinaryReader(this.mMemStream);
        this.mWriter = new BinaryWriter(this.mMemStream);
    }

    public DynamicPacket(FileStream fs)
    {
        mReader = new BinaryReader(fs);
        mWriter = new BinaryWriter(fs);
    }

    public DynamicPacket(BinaryReader _reader)
    {
        mReader = _reader;
    }

    //
    // Methods
    //
    public virtual byte[] PackGetBuffer()
    {
        return this.mMemStream.GetBuffer();
    }

    public virtual int PackGetLength()
    {
        return (int)this.mMemStream.Length;
    }

    public void PackRead(List<byte> list)
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadByte());
        }
    }

    public void PackRead<T>(out List<T> list) where T : IDynamicData, new()
    {
        list = this.PackReadList<T>();
    }

    public void PackRead(out ushort[] ushorts)
    {
        ushorts = this.PackReadUShorts();
    }

    public void PackRead(out ushort[] ushorts, int count)
    {
        ushorts = this.PackReadUShorts(count);
    }

    public void PackRead(out int[] ints)
    {
        ints = this.PackReadInts();
    }

    public void PackRead(out int[] ints, int count)
    {
        ints = this.PackReadInts(count);
    }

    public void PackRead<T>(List<T> list) where T : IDynamicData, new()
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            T item = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            item.Deserialize(this);
            list.Add(item);
        }
    }

    public void PackRead<T>(out T[] array, int count) where T : IDynamicData, new()
    {
        array = this.PackReadArray<T>(count);
    }

    public void PackRead(out short[] shorts)
    {
        shorts = this.PackReadShorts();
    }

    public void PackRead(out short[] shorts, int count)
    {
        shorts = this.PackReadShorts(count);
    }

    public void PackRead(List<ulong> list)
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadUInt64());
        }
    }

    public void PackRead(HashSet<ulong> set)
    {
        set.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            set.Add(this.mReader.ReadUInt64());
        }
    }

    public void PackRead(out List<uint> list)
    {
        list = this.PackReadListUInt32();
    }

    public void PackRead(List<int> list)
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadInt32());
        }
    }

    public void PackRead(out List<byte> list)
    {
        list = this.PackReadListByte();
    }

    public void PackRead(List<uint> list)
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadUInt32());
        }
    }

    public void PackRead(out List<int> list)
    {
        list = this.PackReadListInt32();
    }

    public void PackRead<T>(out T[] array) where T : IDynamicData, new()
    {
        array = this.PackReadArray<T>();
    }

    public void PackRead(out ulong[] ulongs, int count)
    {
        ulongs = this.PackReadULongs(count);
    }

    public void PackRead(out long i)
    {
        i = this.mReader.ReadInt64();
    }

    public void PackRead(out ulong i)
    {
        i = this.mReader.ReadUInt64();
    }

    public void PackRead(out ulong[] ulongs)
    {
        ulongs = this.PackReadULongs();
    }

    public void PackRead(out short i)
    {
        i = this.mReader.ReadInt16();
    }

    public void PackRead(out ushort i)
    {
        i = this.mReader.ReadUInt16();
    }

    public void PackRead(out uint i)
    {
        i = this.mReader.ReadUInt32();
    }

    public void PackRead(out int i)
    {
        i = this.mReader.ReadInt32();
    }

    public void PackRead(out uint[] uints, int count)
    {
        uints = this.PackReadUInts(count);
    }

    public void PackRead(out decimal d)
    {
        d = this.mReader.ReadDecimal();
    }

    public void PackRead<T>(T data) where T : IDynamicData
    {
        data.Deserialize(this);
    }

    public void PackRead(out uint[] uints)
    {
        uints = this.PackReadUInts();
    }

    public void PackRead(out long[] longs, int count)
    {
        longs = this.PackReadLongs(count);
    }

    public void PackRead(out float f)
    {
        f = this.mReader.ReadSingle();
    }

    public void PackRead(out double d)
    {
        d = this.mReader.ReadDouble();
    }

    public void PackRead(out long[] longs)
    {
        longs = this.PackReadLongs();
    }

    public void PackRead(out List<ulong> list)
    {
        list = this.PackReadListUInt64();
    }

    public void PackRead(out bool b)
    {
        b = this.mReader.ReadBoolean();
    }

    public void PackRead<T>(Dictionary<byte, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(Dictionary<sbyte, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(Dictionary<int, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(Dictionary<uint, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(Dictionary<string, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.mReader.ReadString();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(Dictionary<ulong, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(SortedDictionary<byte, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(SortedDictionary<sbyte, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(SortedDictionary<int, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(SortedDictionary<uint, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(SortedDictionary<string, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.mReader.ReadString();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<T>(SortedDictionary<ulong, T> diction) where T : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            T value = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead(out string str)
    {
        str = this.PackReadString();
    }

    public void PackRead<TK, TV>(Dictionary<TK, TV> diction)
            where TK : IDynamicData, new()
            where TV : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            TK key = (default(TK) == null) ? Activator.CreateInstance<TK>() : default(TK);
            key.Deserialize(this);
            TV value = (default(TV) == null) ? Activator.CreateInstance<TV>() : default(TV);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead<TK, TV>(SortedDictionary<TK, TV> diction)
        where TK : IDynamicData, new()
        where TV : IDynamicData, new()
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            TK key = (default(TK) == null) ? Activator.CreateInstance<TK>() : default(TK);
            key.Deserialize(this);
            TV value = (default(TV) == null) ? Activator.CreateInstance<TV>() : default(TV);
            value.Deserialize(this);
            diction.Add(key, value);
        }
    }

    public void PackRead(out byte b)
    {
        b = this.mReader.ReadByte();
    }

    public void PackRead<T>(out Dictionary<byte, T> diction) where T : IDynamicData, new()
    {
        diction = this.PackReadDictionByte<T>();
    }

    public void PackRead<T>(out Dictionary<int, T> diction) where T : IDynamicData, new()
    {
        diction = this.PackReadDictionInt32<T>();
    }

    public void PackRead<T>(out Dictionary<uint, T> diction) where T : IDynamicData, new()
    {
        diction = this.PackReadDictionUInt32<T>();
    }

    public void PackRead<T>(out SortedDictionary<byte, T> diction) where T : IDynamicData, new()
    {
        diction = this.PackReadSortedDictionByte<T>();
    }

    public void PackRead<T>(out SortedDictionary<int, T> diction) where T : IDynamicData, new()
    {
        diction = this.PackReadSortedDictionInt32<T>();
    }

    public void PackRead<T>(out SortedDictionary<uint, T> diction) where T : IDynamicData, new()
    {
        diction = this.PackReadSortedDictionUInt32<T>();
    }

    public void PackRead(out char c)
    {
        c = this.mReader.ReadChar();
    }

    public void PackRead(out Dictionary<string, string> diction)
    {
        diction = this.PackReadDictionStringString();
    }

    public void PackRead(Dictionary<string, string> diction)
    {
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.PackReadString();
            string value = this.PackReadString();
            diction.Add(key, value);
        }
    }

    public void PackRead(out Dictionary<int, int> diction)
    {
        diction = this.PackReadDictionInt32Int32();
    }

    public void PackRead(out Dictionary<uint, uint> diction)
    {
        diction = this.PackReadDictionUInt32UInt32();
    }

    public void PackRead(out Dictionary<uint, UInt16> diction)
    {
        diction = this.PackReadDictionUInt32UInt16();
    }

    public void PackRead(out SortedDictionary<string, string> diction)
    {
        diction = this.PackReadSortedDictionStringString();
    }

    public void PackRead(SortedDictionary<string, string> diction)
    {
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.PackReadString();
            string value = this.PackReadString();
            diction.Add(key, value);
        }
    }

    public void PackRead(out SortedDictionary<int, int> diction)
    {
        diction = this.PackReadSortedDictionInt32Int32();
    }

    public void PackRead(out SortedDictionary<uint, uint> diction)
    {
        diction = this.PackReadSortedDictionUInt32UInt32();
    }

    public void PackRead(out SortedDictionary<uint, UInt16> diction)
    {
        diction = this.PackReadSortedDictionUInt32UInt16();
    }

    public void PackRead(out char[] chars)
    {
        ushort count = this.mReader.ReadUInt16();
        chars = this.mReader.ReadChars((int)count);
    }

    public void PackRead(Dictionary<int, int> diction)
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            int value = this.mReader.ReadInt32();
            diction.Add(key, value);
        }
    }

    public void PackRead(Dictionary<uint, uint> diction)
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            uint value = this.mReader.ReadUInt32();
            diction.Add(key, value);
        }
    }

    public void PackRead(SortedDictionary<int, int> diction)
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            int value = this.mReader.ReadInt32();
            diction.Add(key, value);
        }
    }

    public void PackRead(SortedDictionary<uint, uint> diction)
    {
        diction.Clear();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            uint value = this.mReader.ReadUInt32();
            diction.Add(key, value);
        }
    }

    public void PackRead(out sbyte b)
    {
        b = this.mReader.ReadSByte();
    }

    public void PackRead(out List<string> list)
    {
        list = this.PackReadListString();
    }

    public void PackRead(List<float> list)
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadSingle());
        }
    }

    public void PackRead(out byte[] bytes, int count)
    {
        bytes = this.PackReadBytes(count);
    }

    public void PackRead(List<string> list)
    {
        list.Clear();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.PackReadString());
        }
    }

    public void PackRead(out sbyte[] bytes, int count)
    {
        bytes = this.PackReadSBytes(count);
    }

    public void PackRead(out List<float> list)
    {
        list = this.PackReadListFloat();
    }

    public void PackRead(out sbyte[] bytes)
    {
        bytes = this.PackReadSBytes();
    }

    public void PackRead<TK, TV>(out Dictionary<TK, TV> diction)
        where TK : IDynamicData, new()
            where TV : IDynamicData, new()
    {
        diction = this.PackReadDiction<TK, TV>();
    }

    public void PackRead<TK, TV>(out SortedDictionary<TK, TV> diction)
        where TK : IDynamicData, new()
        where TV : IDynamicData, new()
    {
        diction = this.PackReadSortedDiction<TK, TV>();
    }

    public void PackRead(out byte[] bytes)
    {
        bytes = this.PackReadBytes();
    }

    public T[] PackReadArray<T>() where T : IDynamicData, new()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadArray<T>((int)count);
    }

    public T[] PackReadArray<T>(int count) where T : IDynamicData, new()
    {
        T[] array = new T[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = ((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
            array[i].Deserialize(this);
        }
        return array;
    }

    public bool PackReadBoolean()
    {
        return this.mReader.ReadBoolean();
    }

    public byte PackReadByte()
    {
        return this.mReader.ReadByte();
    }

    public byte[] PackReadshortBytes()
    {
        UInt32 count = (UInt32)this.mReader.ReadUInt16();
        return this.PackReadBytes((int)count);
    }

    public byte[] PackReadBytes()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadBytes((int)count);
    }

    public byte[] PackReadBytes(int count)
    {
        byte[] array = new byte[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadByte();
        }
        return array; 
    }

    public char PackReadChar()
    {
        return this.mReader.ReadChar();
    }

    public char[] PackReadChars(int count)
    {
        return this.mReader.ReadChars(count);
    }

    public char[] PackReadChars()
    {
        ushort count = this.mReader.ReadUInt16();
        return this.mReader.ReadChars((int)count);
    }

    public T PackReadData<T>() where T : IDynamicData, new()
    {
        T result = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
        result.Deserialize(this);
        return result;
    }

    public decimal PackReadDecimal()
    {
        return this.mReader.ReadDecimal();
    }

    public Dictionary<TK, TV> PackReadDiction<TK, TV>()
        where TK : IDynamicData, new()
            where TV : IDynamicData, new()
    {
        Dictionary<TK, TV> dictionary = new Dictionary<TK, TV>();
        this.PackRead<TK, TV>(dictionary);
        return dictionary;
    }

    public Dictionary<byte, T> PackReadDictionByte<T>() where T : IDynamicData, new()
    {
        Dictionary<byte, T> dictionary = new Dictionary<byte, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }
    public Dictionary<sbyte, T> PackReadDictionSByte<T>() where T : IDynamicData, new()
    {
        Dictionary<sbyte, T> dictionary = new Dictionary<sbyte, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }

    public Dictionary<uint, T> PackReadDictionUInt32<T>() where T : IDynamicData, new()
    {
        Dictionary<uint, T> dictionary = new Dictionary<uint, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }
    public Dictionary<int, T> PackReadDictionInt32<T>() where T : IDynamicData, new()
    {
        Dictionary<int, T> dictionary = new Dictionary<int, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }
    public Dictionary<ulong, T> PackReadDictionUInt64<T>() where T : IDynamicData, new()
    {
        Dictionary<ulong, T> dictionary = new Dictionary<ulong, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }

    public Dictionary<uint, sbyte> PackReadDictionUInt32SByte()
    {
        Dictionary<uint, sbyte> dictionary = new Dictionary<uint, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            sbyte value = this.mReader.ReadSByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, byte> PackReadDictionUInt32Byte()
    {
        Dictionary<uint, byte> dictionary = new Dictionary<uint, byte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            byte value = this.mReader.ReadByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ulong, byte> PackReadDictionUInt64Byte()
    {
        Dictionary<ulong, byte> dictionary = new Dictionary<ulong, byte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            byte value = this.mReader.ReadByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, ulong> PackReadDictionUInt32UInt64()
    {
        Dictionary<uint, ulong> dictionary = new Dictionary<uint, ulong>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            ulong value = this.mReader.ReadUInt64();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ulong, int> PackReadDictionUInt64Int32()
    {
        Dictionary<ulong, int> dictionary = new Dictionary<ulong, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            int value = this.mReader.ReadInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, UInt16> PackReadDictionUInt32UInt16()
    {
        Dictionary<uint, UInt16> dictionary = new Dictionary<uint, UInt16>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            UInt16 value = this.mReader.ReadUInt16();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, uint> PackReadDictionUInt32UInt32()
    {
        Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            uint value = this.mReader.ReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<int, uint> PackReadDictionInt32UInt32()
    {
        Dictionary<int, uint> dictionary = new Dictionary<int, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            uint value = this.mReader.ReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ushort, uint> PackReadDictionUInt16UInt32()
    {
        Dictionary<ushort, uint> dictionary = new Dictionary<ushort, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ushort key = this.mReader.ReadUInt16();
            uint value = this.mReader.ReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ushort, float> PackReadDictionUInt16Float()
    {
        Dictionary<ushort, float> dictionary = new Dictionary<ushort, float>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ushort key = this.mReader.ReadUInt16();
            float value = this.mReader.ReadSingle();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, int> PackReadDictionUInt32Int32()
    {
        Dictionary<uint, int> dictionary = new Dictionary<uint, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            int value = this.mReader.ReadInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, bool> PackReadDictionUInt32bool()
    {
        Dictionary<uint, bool> dictionary = new Dictionary<uint, bool>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            bool value = this.mReader.ReadBoolean();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, long> PackReadDictionUInt32Int64()
    {
        Dictionary<uint, long> dictionary = new Dictionary<uint, long>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            long value = this.mReader.ReadInt64();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ulong, uint> PackReadDictionUInt64UInt32()
    {
        Dictionary<ulong, uint> dictionary = new Dictionary<ulong, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            uint value = this.mReader.ReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ulong, sbyte> PackReadDictionUInt64SByte()
    {
        Dictionary<ulong, sbyte> dictionary = new Dictionary<ulong, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            sbyte value = this.mReader.ReadSByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<sbyte, ulong> PackReadDictionSByteUInt64()
    {
        Dictionary<sbyte, ulong> dictionary = new Dictionary<sbyte, ulong>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            ulong value = this.mReader.ReadUInt64();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, ulong> PackReadDictionByteUInt64()
    {
        Dictionary<byte, ulong> dictionary = new Dictionary<byte, ulong>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            ulong value = this.mReader.ReadUInt64();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, ushort> PackReadDictionByteUInt16()
    {
        Dictionary<byte, ushort> dictionary = new Dictionary<byte, ushort>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            ushort value = this.mReader.ReadUInt16();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, long> PackReadDictionByteInt64()
    {
        Dictionary<byte, long> dictionary = new Dictionary<byte, long>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            long value = this.mReader.ReadInt64();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, byte> PackReadDictionByteByte()
    {
        Dictionary<byte, byte> dictionary = new Dictionary<byte, byte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            byte value = this.mReader.ReadByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, bool> PackReadDictionByteBool()
    {
        Dictionary<byte, bool> dictionary = new Dictionary<byte, bool>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            bool value = this.mReader.ReadBoolean();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, string> PackReadDictionByteString()
    {
        Dictionary<byte, string> dictionary = new Dictionary<byte, string>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            string value = this.mReader.ReadString();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<string,int> PackReadDictionStringInt32()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.mReader.ReadString();
            int value = this.mReader.ReadInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<uint, string> PackReadDictionUInt32String()
    {
        Dictionary<uint, string> dictionary = new Dictionary<uint, string>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            string value = this.mReader.ReadString();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ushort, sbyte> PackReadDictionUInt16SByte()
    {
        Dictionary<ushort, sbyte> dictionary = new Dictionary<ushort, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ushort key = this.mReader.ReadUInt16();
            sbyte value = this.mReader.ReadSByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ushort, byte> PackReadDictionUInt16Byte()
    {
        Dictionary<ushort, byte> dictionary = new Dictionary<ushort, byte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ushort key = this.mReader.ReadUInt16();
            byte value = this.mReader.ReadByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<ushort, int> PackReadDictionUInt16Int32()
    {
        Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ushort key = this.mReader.ReadUInt16();
            int value = this.mReader.ReadInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<sbyte, uint> PackReadDictionSByteUInt32()
    {
        Dictionary<sbyte, uint> dictionary = new Dictionary<sbyte, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            uint value = this.mReader.ReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<byte, uint> PackReadDictionByteUInt32()
    {
        Dictionary<byte, uint> dictionary = new Dictionary<byte, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            byte key = this.mReader.ReadByte();
            uint value = this.mReader.ReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<sbyte, sbyte> PackReadDictionSByteSByte()
    {
        Dictionary<sbyte, sbyte> dictionary = new Dictionary<sbyte, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            sbyte value = this.mReader.ReadSByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<sbyte, int> PackReadDictionSByteInt32()
    {
        Dictionary<sbyte, int> dictionary = new Dictionary<sbyte, int>();
        Int32 num = this.PackReadInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            int value = this.mReader.ReadInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<sbyte, string> PackReadDictionSByteString()
    {
        Dictionary<sbyte, string> dictionary = new Dictionary<sbyte, string>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            string value = this.PackReadString();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<int, int> PackReadDictionInt32Int32()
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            int value = this.mReader.ReadInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<string, string> PackReadDictionStringString()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.PackReadString();
            string value = this.PackReadString();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<string,uint> PackReadDictionStringUint32()
    {
        Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.PackReadString();
            uint value = this.PackReadUInt32();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public Dictionary<string, byte> PackReadDictionStringByte()
    {
        Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.PackReadString();
            byte value = this.mReader.ReadByte();
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
        return dictionary;
    }

    public SortedDictionary<TK, TV> PackReadSortedDiction<TK, TV>()
        where TK : IDynamicData, new()
        where TV : IDynamicData, new()
    {
        SortedDictionary<TK, TV> dictionary = new SortedDictionary<TK, TV>();
        this.PackRead<TK, TV>(dictionary);
        return dictionary;
    }

    public SortedDictionary<byte, T> PackReadSortedDictionByte<T>() where T : IDynamicData, new()
    {
        SortedDictionary<byte, T> dictionary = new SortedDictionary<byte, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }

    public SortedDictionary<sbyte, T> PackReadSortedDictionSByte<T>() where T : IDynamicData, new()
    {
        SortedDictionary<sbyte, T> dictionary = new SortedDictionary<sbyte, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }

    public SortedDictionary<uint, T> PackReadSortedDictionUInt32<T>() where T : IDynamicData, new()
    {
        SortedDictionary<uint, T> dictionary = new SortedDictionary<uint, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }

    public SortedDictionary<int, T> PackReadSortedDictionInt32<T>() where T : IDynamicData, new()
    {
        SortedDictionary<int, T> dictionary = new SortedDictionary<int, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }

    public SortedDictionary<ulong, T> PackReadSortedDictionUInt64<T>() where T : IDynamicData, new()
    {
        SortedDictionary<ulong, T> dictionary = new SortedDictionary<ulong, T>();
        this.PackRead<T>(dictionary);
        return dictionary;
    }
    
    public SortedDictionary<uint, sbyte> PackReadSortedDictionUInt32SByte()
    {
        SortedDictionary<uint, sbyte> dictionary = new SortedDictionary<uint, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            sbyte value = this.mReader.ReadSByte();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<uint, UInt16> PackReadSortedDictionUInt32UInt16()
    {
        SortedDictionary<uint, UInt16> dictionary = new SortedDictionary<uint, UInt16>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            UInt16 value = this.mReader.ReadUInt16();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<uint, uint> PackReadSortedDictionUInt32UInt32()
    {
        SortedDictionary<uint, uint> dictionary = new SortedDictionary<uint, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            uint key = this.mReader.ReadUInt32();
            uint value = this.mReader.ReadUInt32();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<ulong, int> PackReadSortedDictionUInt64Int32()
    {
        SortedDictionary<ulong, int> dictionary = new SortedDictionary<ulong, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            int value = this.mReader.ReadInt32();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<ulong, sbyte> PackReadSortedDictionUInt64SByte()
    {
        SortedDictionary<ulong, sbyte> dictionary = new SortedDictionary<ulong, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ulong key = this.mReader.ReadUInt64();
            sbyte value = this.mReader.ReadSByte();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<sbyte, ulong> PackReadSortedDictionSByteUInt64()
    {
        SortedDictionary<sbyte, ulong> dictionary = new SortedDictionary<sbyte, ulong>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            ulong value = this.mReader.ReadUInt64();
            dictionary.Add(key, value);
        }
        return dictionary;
    }
    
    public SortedDictionary<ushort, sbyte> PackReadSortedDictionUInt16SByte()
    {
        SortedDictionary<ushort, sbyte> dictionary = new SortedDictionary<ushort, sbyte>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            ushort key = this.mReader.ReadUInt16();
            sbyte value = this.mReader.ReadSByte();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<sbyte, uint> PackReadSortedDictionSByteUInt32()
    {
        SortedDictionary<sbyte, uint> dictionary = new SortedDictionary<sbyte, uint>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            sbyte key = this.mReader.ReadSByte();
            uint value = this.mReader.ReadUInt32();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<int, int> PackReadSortedDictionInt32Int32()
    {
        SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            int key = this.mReader.ReadInt32();
            int value = this.mReader.ReadInt32();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public SortedDictionary<string, string> PackReadSortedDictionStringString()
    {
        SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
        UInt32 num = this.PackReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            string key = this.PackReadString();
            string value = this.PackReadString();
            dictionary.Add(key, value);
        }
        return dictionary;
    }

    public double PackReadDouble()
    {
        return this.mReader.ReadDouble();
    }

    public float PackReadFloat()
    {
        return this.mReader.ReadSingle();
    }

    public short PackReadInt16()
    {
        return this.mReader.ReadInt16();
    }

    public int PackReadInt32()
    {
        return this.mReader.ReadInt32();
    }

    public long PackReadInt64()
    {
        return this.mReader.ReadInt64();
    }

    public int[] PackReadInts(int count)
    {
        int[] array = new int[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadInt32();
        }
        return array;
    }

    public float[] PackReadFloats()
    {
        UInt32 count = this.mReader.ReadUInt32();
        float[] array = new float[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadSingle();
        }
        return array;
    }

    public short[] PackReadInt16s()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadShorts((int)count);
    }

    public int[] PackReadInt32s()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadInts((int)count);
    }

    public int[] PackReadInts()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadInts((int)count);
    }

    public List<T> PackReadList<T>() where T : IDynamicData, new()
    {
        List<T> list = new List<T>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            T item = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            item.Deserialize(this);
            list.Add(item);
        }
        return list;
    }

    public List<byte> PackReadListByte()
    {
        List<byte> list = new List<byte>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadByte());
        }
        return list;
    }

    public HashSet<byte> PackReadSetByte()
    {
        HashSet<byte> list = new HashSet<byte>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadByte());
        }
        return list;
    }

    public List<sbyte> PackReadListSByte()
    {
        List<sbyte> list = new List<sbyte>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadSByte());
        }
        return list;
    }

    public HashSet<sbyte> PackReadSetSByte()
    {
        HashSet<sbyte> list = new HashSet<sbyte>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadSByte());
        }
        return list;
    }

    public List<float> PackReadListFloat()
    {
        List<float> list = new List<float>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadSingle());
        }
        return list;
    }

    public HashSet<float> PackReadSetFloat()
    {
        HashSet<float> list = new HashSet<float>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadSingle());
        }
        return list;
    }

    public List<int> PackReadListInt32()
    {
        List<int> list = new List<int>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadInt32());
        }
        return list;
    }

    public HashSet<int> PackReadSetInt32()
    {
        HashSet<int> list = new HashSet<int>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadInt32());
        }
        return list;
    }

    public void PackReadListInt32(List<int> lists)
    {
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            lists.Add(this.mReader.ReadInt32());
        }
    }

	public Dictionary<string, string[]> PackReadDictionStringStrings()
	{
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		UInt32 num = this.PackReadUInt32();
		for (int i = 0; i < (int)num; i++)
		{
			string key = this.PackReadString();
			string[] value = this.PackReadStrings();
			dictionary.Add(key, value);
		}
		return dictionary;
	}

	public string[] PackReadStrings()
    {
        UInt32 num = this.mReader.ReadUInt32();
        string[] array = new string[num];
        for (int i = 0; i < (int)num; i++)
        {
            array[i] = PackReadString();
        }
        return array;
    }

    public List<string> PackReadListString()
    {
        List<string> list = new List<string>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.PackReadString());
        }
        return list;
    }

    public HashSet<string> PackReadSetString()
    {
        HashSet<string> list = new HashSet<string>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.PackReadString());
        }
        return list;
    }

    public List<ushort> PackReadListUInt16()
    {
        List<ushort> list = new List<ushort>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadUInt16());
        }
        return list;
    }

    public HashSet<ushort> PackReadSetUInt16()
    {
        HashSet<ushort> list = new HashSet<ushort>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadUInt16());
        }
        return list;
    }

    public List<uint> PackReadListUInt32()
    {
        List<uint> list = new List<uint>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadUInt32());
        }
        return list;
    }

    public HashSet<uint> PackReadSetUInt32()
    {
        HashSet<uint> list = new HashSet<uint>();
        UInt32 num = this.mReader.ReadUInt32();
        for (int i = 0; i < (int)num; i++)
        {
            list.Add(this.mReader.ReadUInt32());
        }
        return list;
    }
    
    public List<ulong> PackReadListUInt64()
    {
        List<ulong> list = new List<ulong>();
        this.PackRead(list);
        return list;
    }

    public HashSet<ulong> PackReadSetUInt64()
    {
        HashSet<ulong> list = new HashSet<ulong>();
        this.PackRead(list);
        return list;
    }

    public long[] PackReadLongs(int count)
    {
        long[] array = new long[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadInt64();
        }
        return array;
    }

    public long[] PackReadLongs()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadLongs((int)count);
    }

    public sbyte PackReadSByte()
    {
        return this.mReader.ReadSByte();
    }

    public sbyte[] PackReadSBytes(int count)
    {
        sbyte[] array = new sbyte[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadSByte();
        }
        return array;
    }

    public sbyte[] PackReadSBytes()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadSBytes((int)count);
    }

    public short[] PackReadShorts(int count)
    {
        short[] array = new short[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadInt16();
        }
        return array;
    }

    public short[] PackReadShorts()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadShorts((int)count);
    }

    public string PackReadString()
    {
        int count = this.PackReadInt32();
        if (count == 0)
            return "";
        byte[] bytes = this.PackReadBytes(count);
        return Encoding.UTF8.GetString(bytes);
    }

    public void PackRead(out string[] strings, int count)
    {
        strings = this.PackReadStrings(count);
    }

    public string[] PackReadStrings(int count)
    {
        string[] array = new string[count];
        for (int i = 0; i < count; i++)
        {
            int len = this.PackReadInt32();
            if (len == 0)
            {
                array[i] = "";
            }
            else
            {
                byte[] bytes = this.PackReadBytes(len);
                array[i] = Encoding.UTF8.GetString(bytes);
            }
        }
        return array;
    }

    public ushort PackReadUInt16()
    {
        return this.mReader.ReadUInt16();
    }

    public uint PackReadUInt32()
    {
        return this.mReader.ReadUInt32();
    }

    public ulong PackReadUInt64()
    {
        return this.mReader.ReadUInt64();
    }

    public uint[] PackReadUInts(int count)
    {
        uint[] array = new uint[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadUInt32();
        }
        return array;
    }

    public uint[] PackReadUInt32s()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadUInts((int)count);
    }
    public uint[] PackReadUInts()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadUInts((int)count);
    }

    public ulong[] PackReadULongs()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadULongs((int)count);
    }

    public ulong[] PackReadULongs(int count)
    {
        ulong[] array = new ulong[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadUInt64();
        }
        return array;
    }

    public ushort[] PackReadUShorts()
    {
        UInt32 count = this.mReader.ReadUInt32();
        return this.PackReadUShorts((int)count);
    }

    public ushort[] PackReadUShorts(int count)
    {
        ushort[] array = new ushort[count];
        for (int i = 0; i < count; i++)
        {
            array[i] = this.mReader.ReadUInt16();
        }
        return array;
    }

    public void Seek(long offset, SeekOrigin loc)
    {
        this.mMemStream.Seek(offset, loc);
    }

    public virtual byte[] ToArray()
    {
        return this.mMemStream.ToArray();
    }

    public void PackWrite(sbyte[] bytes)
    {
        this.mWriter.Write((uint)bytes.Length);
        this.PackWrite(bytes, bytes.Length);
    }

    public void PackWrite(char c)
    {
        this.mWriter.Write(c);
    }

    public void PackWrite(Dictionary<string, string> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<string, string> current in diction)
        {
            this.PackWrite(current.Key);
            this.PackWrite(current.Value);
        }
    }

    public void PackWrite(sbyte b)
    {
        this.mWriter.Write(b);
    }

    public void PackWrite(List<ulong> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (ulong current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(HashSet<ulong> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (var current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(sbyte[] bytes, int count)
    {
        int num = Math.Min(bytes.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(bytes[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0);
            i++;
        }
    }
    public void PackWrite(Dictionary<uint, uint> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, uint> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<uint, int> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, int> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<int, uint> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<int, uint> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<byte, uint> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<byte, uint> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<byte, string> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<byte, string> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<sbyte, uint> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<sbyte, uint> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<sbyte, string> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<sbyte, string> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<uint, sbyte> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, sbyte> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<uint, UInt16> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, UInt16> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<uint, ulong> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, ulong> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<sbyte, ulong> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<sbyte, ulong> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<ulong, int> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ulong, int> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<ushort, sbyte> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ushort, sbyte> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<ushort, uint> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ushort, uint> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<ushort, int> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ushort, int> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<ulong, sbyte> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ulong, sbyte> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<ulong, uint> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ulong, uint> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<int, int> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<int, int> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.mWriter.Write(current.Value);
        }
    }

    public void PackWrite(Dictionary<uint, string> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, string> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.PackWrite(current.Value);
        }
    }

    public void PackWrite(Dictionary<int, string> diction)
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<int, string> current in diction)
        {
            this.mWriter.Write(current.Key);
            this.PackWrite(current.Value);
        }
    }

    public void PackWrite(string str)
    {
        if (str == null)
        {
            this.PackWrite((ushort)0);
        }
        else
        {
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            this.PackWrite((ushort)(bytes.Length));
            this.PackWrite(bytes, bytes.Length);
        }
    }

    public void PackASCIIWrite(string str)
    {
        if (str == null)
        {
            this.PackWrite((ushort)0);
        }
        else
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            this.PackWrite((ushort)(bytes.Length));
            this.PackWrite(bytes, bytes.Length);
        }
    }

    public void PackWrite(string str, int count)
    {
        byte[] bytes = new byte[count];
        if (str != null)
            bytes = Encoding.Unicode.GetBytes(str);

        PackWrite(bytes, count);
    }

    public void PackASCIIWrite(string str, int count)
    {
        byte[] bytes = new byte[count];
        if (str != null)
            bytes = Encoding.ASCII.GetBytes(str);

        PackWrite(bytes, count);
    }

    public void PackUTF8Write(string str)
    {
        if (str == null)
        {
            this.PackWrite((ushort)0);
        }
        else
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            this.PackWrite((ushort)(bytes.Length));
            this.PackWrite(bytes, bytes.Length);
        }
    }

    public void PackWrite(byte[] bytes, int count)
    {
        int num = Math.Min(bytes.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(bytes[i]);
        }
        while (i < count)
        {
            this.mWriter.Write((byte)(0));
            i++;
        }
    }

    public void PackWrite(bool b)
    {
        this.mWriter.Write(b);
    }

    public void PackWrite(byte b)
    {
        this.mWriter.Write(b);
    }

    public void PackWrite<TK, TV>(Dictionary<TK, TV> diction)
        where TK : IDynamicData, new()
            where TV : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<TK, TV> current in diction)
        {
            TK key = current.Key;
            key.Serialize(this);
            TV value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite(List<string> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (string current in list)
        {
            this.PackWrite(current);
        }
    }

    public void PackWrite(List<float> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (float value in list)
        {
            this.mWriter.Write(value);
        }
    }

    public void PackWrite(char[] chars, int count)
    {
        this.mWriter.Write(chars, 0, count);
    }

    public void PackWrite(char[] chars)
    {
        this.mWriter.Write((ushort)chars.Length);
        this.mWriter.Write(chars);
    }

    public void PackWrite(float[] f)
    {
        this.mWriter.Write((ushort)f.Length);
        for (int i = 0; i < f.Length; i++)
        {
            this.mWriter.Write(f[i]);
        }
    }

    public void PackWrite(byte[] b)
    {
        this.mWriter.Write((uint)b.Length);
        this.PackWrite(b, b.Length);
    }

    public void PackWrite<T>(Dictionary<byte, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<byte, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(Dictionary<sbyte, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<sbyte, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWriteDiction<T>(Dictionary<uint, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWriteUInt<T>(Dictionary<uint, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(Dictionary<uint, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(Dictionary<int, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<int, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(Dictionary<ulong, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ulong, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(Dictionary<string, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<string, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(SortedDictionary<byte, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<byte, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(SortedDictionary<sbyte, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<sbyte, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWriteDiction<T>(SortedDictionary<uint, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWriteUInt<T>(SortedDictionary<uint, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(SortedDictionary<uint, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<uint, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(SortedDictionary<int, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<int, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(SortedDictionary<ulong, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<ulong, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite<T>(SortedDictionary<string, T> diction) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)diction.Count);
        foreach (KeyValuePair<string, T> current in diction)
        {
            this.mWriter.Write(current.Key);
            T value = current.Value;
            value.Serialize(this);
        }
    }

    public void PackWrite(float f)
    {
        this.mWriter.Write(f);
    }

    public void PackWrite(long[] longs, int count)
    {
        int num = Math.Min(longs.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(longs[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0L);
            i++;
        }
    }

    public void PackWrite(ulong i)
    {
        this.mWriter.Write(i);
    }

    public void PackWrite(string[] strs)
    {
        uint num = (uint)strs.Length;
        this.mWriter.Write(num);

        for (int i = 0; i < num; i++)
            this.PackWrite(strs[i]);
    }

    public void PackWrite(long[] longs)
    {
        uint num = (uint)longs.Length;
        this.mWriter.Write(num);
        this.PackWrite(longs, (int)num);
    }


    public void PackWrite(decimal d)
    {
        this.mWriter.Write(d);
    }

    public void PackWrite(uint[] uints, int count)
    {
        int num = Math.Min(uints.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(uints[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0u);
            i++;
        }
    }

    public void PackWrite(double d)
    {
        this.mWriter.Write(d);
    }

    public void PackWrite(int i)
    {
        this.mWriter.Write(i);
    }

    public void PackWrite(ushort i)
    {
        this.mWriter.Write(i);
    }

    public void PackWrite(short i)
    {
        this.mWriter.Write(i);
    }

    public void PackWrite(ulong[] ulongs, int count)
    {
        int num = Math.Min(ulongs.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(ulongs[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0uL);
            i++;
        }
    }

    public void PackWrite(long i)
    {
        this.mWriter.Write(i);
    }

    public void PackWrite(ulong[] ulongs)
    {
        uint num = (uint)ulongs.Length;
        this.mWriter.Write(num);
        this.PackWrite(ulongs, (int)num);
    }

    public void PackWrite(uint i)
    {
        this.mWriter.Write(i);
    }

    public void PackWrite(List<byte> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (byte current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(ushort[] ushorts)
    {
        uint num = (uint)ushorts.Length;
        this.mWriter.Write(num);
        this.PackWrite(ushorts, (int)num);
    }

    public void PackWrite<T>(List<T> list) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)list.Count);
        foreach (T current in list)
        {
            current.Serialize(this);
        }
    }

    public void PackWrite(short[] shorts, int count)
    {
        int num = Math.Min(shorts.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(shorts[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0);
            i++;
        }
    }

    public void PackWrite(List<ushort> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (ushort current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(List<uint> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (uint current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(HashSet<uint> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (uint current in list)
        {
            this.mWriter.Write(current);
        }
    }
    public void PackWrite(HashSet<byte> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (byte current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(short[] shorts)
    {
        uint num = (uint)shorts.Length;
        this.mWriter.Write(num);
        this.PackWrite(shorts, (int)num);
    }

    public void PackWrite(List<int> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (int current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(List<sbyte> list)
    {
        this.mWriter.Write((uint)list.Count);
        foreach (sbyte current in list)
        {
            this.mWriter.Write(current);
        }
    }

    public void PackWrite(int[] ints, int count)
    {
        int num = Math.Min(ints.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(ints[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0);
            i++;
        }
    }

    public void PackWrite<T>(T data) where T : IDynamicData
    {
        data.Serialize(this);
    }

    public void PackWrite(uint[] uints)
    {
        uint num = (uint)uints.Length;
        this.mWriter.Write(num);
        this.PackWrite(uints, (int)num);
    }

    public void PackWrite(int[] ints)
    {
        uint num = (uint)ints.Length;
        this.mWriter.Write(num);
        this.PackWrite(ints, (int)num);
    }

    public void PackWrite(ushort[] ushorts, int count)
    {
        int num = Math.Min(ushorts.Length, count);
        int i;
        for (i = 0; i < num; i++)
        {
            this.mWriter.Write(ushorts[i]);
        }
        while (i < count)
        {
            this.mWriter.Write(0);
            i++;
        }
    }

    public void PackWrite<T>(T[] array, int count) where T : IDynamicData, new()
    {
        for (int i = 0; i < count; i++)
        {
            array[i].Serialize(this);
        }
    }

    public void PackWrite<T>(T[] array) where T : IDynamicData, new()
    {
        this.mWriter.Write((uint)array.Length);
        this.PackWrite<T>(array, array.Length);
    }
}

