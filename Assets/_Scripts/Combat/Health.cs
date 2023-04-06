using _Scripts.FSM_Enemy;
using _Scripts.FSM_Player;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private StateManager _stateManager;
        [SerializeField] private NPCStateManager _npcStateManager;
        [SerializeField] private float maxHealth;
        private float _currentHealth;

        [SerializeField] private Image healthBar;


        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            healthBar.fillAmount = GetFraction();

            if (_currentHealth <= 0)
            {
                if (_stateManager != null)
                {
                    _stateManager.ChangeState(new DeathState(_stateManager));
                }
                else
                {
                    _npcStateManager.ChangeState(new NPCDeathState(_npcStateManager));
                }
            }
        }

        private float GetFraction()
        {
            return _currentHealth / maxHealth;
        }
    }
}