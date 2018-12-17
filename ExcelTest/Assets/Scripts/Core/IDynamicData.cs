using System;

public interface IDynamicData
{
    //
    // Methods
    //
    void Deserialize(DynamicPacket packet);

    void Serialize(DynamicPacket packet);
}

public interface C2sMsgInterface
{
     void Packet();
}