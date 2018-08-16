using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerInputSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
    {
        public bool Left;
        public bool Right;
        public bool Up;
        public bool Down;

        public bool UpLeft;
        public bool UpRight;
        public bool DownLeft;
        public bool DownRight;

        public void Execute(ref PlayerInput input)
        {
            input.Horizontal = Left || UpLeft || DownLeft ? -0.07f : Right || UpRight || DownRight ? 0.07f : 0f;
            input.Vertical = Down || DownLeft || DownRight ? -0.07f : Up || UpRight || UpLeft ? 1f : 0f;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob
        {
            Left = Input.GetKey(KeyCode.A),
            Right = Input.GetKey(KeyCode.D),
            Up = Input.GetKey(KeyCode.W),
            //Down = Input.GetKeyDown(KeyCode.S),

            //UpLeft = Input.GetKeyDown(KeyCode.Q),
            //UpRight = Input.GetKeyDown(KeyCode.E),
            //DownLeft = Input.GetKeyDown(KeyCode.Z),
            //DownRight = Input.GetKeyDown(KeyCode.X),
        };

        return job.Schedule(this, 1, inputDeps);
    }
}