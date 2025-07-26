using UnityEngine;

public class EffectsStorage : MonoBehaviour
{
    [Header("Text Effects")]
    public GameObject _scoreEffectText;
    public GameObject _powerEffectText;
    public GameObject _immortalEffectText;
    public GameObject _healEffectText;

    [Header("Pickup Effects")]
    public GameObject _immortalEffect;
    public GameObject _pickupEffect;

    [Header("Damage Effects")]
    public GameObject _damageEffect;
    public GameObject _forceFieldDamage;
    public GameObject _playerExplosionEffect; 
    public GameObject _targetExplosionEffect;

    public static EffectsStorage Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
