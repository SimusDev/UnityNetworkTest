using UnityEngine;
using PurrNet;
using PurrNet.Packing;

[CreateAssetMenu(fileName = "WorldObject", menuName = "Resources/WorldObject")]
public class WorldObject : ScriptableObject
{
    public string Name = "";
    public GameObject Prefab;
}
