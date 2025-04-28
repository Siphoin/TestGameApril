using System.Collections;
using UnityEngine;

namespace TestGame.Configs.RedBoxConfigs
{
    [CreateAssetMenu(fileName = "RedBoxSettings", menuName = "Settings/RedBoxSettings")]
    public class RedBoxSettings : ScriptableObject
    {

        [SerializeField] private int _damage = 30;

        public int Damage => _damage;
    }
}