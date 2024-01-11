using Unity.Entities;
using UnityEngine;

public class BenchmarkAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public int instances;
}

public struct BenchmarkInfo : IComponentData
{
    public Entity Prefab;
    public int RowsPerPress;
    public int CurrentRows;
}

public class BenchmarkBaker : Baker<BenchmarkAuthoring>
{
    public override void Bake(BenchmarkAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new BenchmarkInfo
        {
            Prefab       = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
            RowsPerPress = authoring.instances,
            CurrentRows  = 0,
        });
    }
    
}