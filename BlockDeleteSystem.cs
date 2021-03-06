﻿//using Unity.Transforms;
//using Unity.Entities;
//using Unity.Mathematics;

//public class DeleteBlocksSystem : ComponentSystem
//{
//    EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();

//    public struct PlayerGroup
//    {
//        public ComponentDataArray<Position> playerPos;
//        public ComponentDataArray<PlayerInput> input;
//        public readonly int Length;
//    }

//    public struct BlocksGroup
//    {
//        public ComponentDataArray<Block> block;
//        public ComponentDataArray<Position> blockPos;
//        public EntityArray entityArray;
//        public readonly int Length;
//    }

//    [Inject] PlayerGroup playerGroup;
//    [Inject] BlocksGroup blocksGroup;

//    protected override void OnUpdate()
//    {
//        for (int i = 0; i < blocksGroup.Length; i++)
//        {
//            float dist = math.distance(playerGroup.playerPos[0].Value, blocksGroup.blockPos[i].Value);

//            if (dist < 1)
//            {
//                //PostUpdateCommands.DestroyEntity(blocksGroup.entityArray[i]);
//                if (entityManager.HasComponent<Fly>(blocksGroup.entityArray[i]) == false)
//                    {
//                    PostUpdateCommands.AddComponent(blocksGroup.entityArray[i], new Fly());
//                    }
//            }
//        }
//    }
//}