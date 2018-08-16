using Unity.Entities;

public struct PlayerInput : IComponentData
{
    public float Horizontal;
    public float Vertical;
    public int JumpTime;
}

public struct Block : IComponentData { }
public struct Fly : IComponentData { }