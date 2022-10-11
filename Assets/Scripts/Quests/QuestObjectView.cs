using System;
using Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Quests
{
    public class QuestObjectView : MonoBehaviour

    {
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Color _completedColor;

    [SerializeField] private int _id;

    public int Id => _id;

    private Color _defaultColor;

    public Action<CharacterView> OnLevelObjectContact;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var levelObject = collider2D.gameObject.GetComponent<CharacterView>();
        OnLevelObjectContact?.Invoke(levelObject);
    }

    private void Awake()
    {
        _defaultColor = _spriteRenderer.color;
    }

    public void ProcessComplete()
    {
        _spriteRenderer.color = _completedColor;
    }

    public void ProcessActive()
    {
        _spriteRenderer.color = _defaultColor;
    }
    }
}