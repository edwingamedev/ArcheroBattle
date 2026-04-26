using UnityEngine;

namespace EdwinGameDev.Character.Units
{
    [CreateAssetMenu(fileName = "New UnitDefinition", menuName = "UnitDefinition")]
    public class UnitDefinition : ScriptableObject
    {
        [field: SerializeField] public int Id { get; set; }
        [SerializeField] public UnitStats stats;
        [SerializeField] public CharacterAdapter prefab;
    }
}