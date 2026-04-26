using UnityEngine;

namespace EdwinGameDev.Character.Units
{
    [CreateAssetMenu(fileName = "New UnitStats", menuName = "UnitStats")]
    public class UnitStats : ScriptableObject
    {
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public float MoveSpeed  { get; set; }
        [field: SerializeField] public float AttackSpeed  { get; set; }
        [field: SerializeField] public int Damage { get; set; }
    }
}