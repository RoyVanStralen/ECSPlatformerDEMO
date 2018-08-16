using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public Mesh PlayerMesh;
    public Material PlayerMaterial;

    public Mesh BlockMesh;
    public Material BlockMaterial;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Start()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        var playerArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(PlayerInput),
            typeof(Gravity)
        );

        for (int x = -3; x < 3; x += 2)
        {
            var player = entityManager.CreateEntity(playerArchetype);

            entityManager.SetSharedComponentData(player, new MeshInstanceRenderer
            {
                mesh = PlayerMesh,
                material = PlayerMaterial
            });

            entityManager.SetComponentData(player, new Position { Value = new float3(x, 2, 0) });
        }
        var blockArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(Block)
        );

        for (int x = -5; x < 5; x++)
        {
            //for (int y = -3; y < 2; y++)
            //{
                var block = entityManager.CreateEntity(blockArchetype);

                entityManager.SetSharedComponentData(block, new MeshInstanceRenderer
                {
                    mesh = BlockMesh,
                    material = BlockMaterial
                });

                entityManager.SetComponentData(block, new Position { Value = new float3(x, -2, 0) });
            //}
        }
    }
}