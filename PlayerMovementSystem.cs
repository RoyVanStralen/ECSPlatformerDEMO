using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class PlayerMovementSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<Position, PlayerInput, Gravity>
    {
        public void Execute(ref Position position, ref PlayerInput playerInput, ref Gravity gravity)
        {
            // Move left and right
            position.Value.x += playerInput.Horizontal;

            //check wether in the air(above floor level) and not jumping, if true fall down
            //TODO: create actual collision with floor
            if (position.Value.y >= -1 && gravity.JumpTime >= 0)
            {
                position.Value.y += -0.12f;
            }           

            //check wether on the floor and jump button is pressed. if true, set jumptime to 12 which allows jumping
            if(position.Value.y < -1 && playerInput.Vertical == 1)
            {
                gravity.JumpTime = 12;
                Debug.Log("Jump mothafucka Jump!!!");
            }

            //check wether jumping is allowed, if true move up
            if(gravity.JumpTime > 0)
            {
                position.Value.y += .4f;
                gravity.JumpTime -= 1;
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob { };

        return job.Schedule(this, 1, inputDeps);
    }
}