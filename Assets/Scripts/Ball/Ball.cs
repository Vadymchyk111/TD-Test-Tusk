using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action<Ball> OnDestroyed;
    
    [SerializeField] private TextMesh _textMesh;
    
    private int _points;

    public virtual bool CheckSpecialBall()
    {
        return false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController _))
        {
            _points++;
            _textMesh.text = _points.ToString();
        }
        
        if (collision.gameObject.TryGetComponent(out GroundController groundController))
        {
            ScoreManager.Instance.AddScore(_points);
            groundController.CheckBall(this);
            OnDestroyed?.Invoke(this);
        }
    }

    public void ResetText()
    {
        _points = 0;
        _textMesh.text = _points.ToString();
    }
}
