using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _countBalls;
    [SerializeField] private string _ballName;
    
    private readonly List<Ball> _freeBalls = new();

    private void Start()
    {
        for (int i = 0; i < _countBalls; i++)
        {
            Ball ball = Instantiate(_ballPrefab, transform);
            ball.gameObject.SetActive(false);
            ball.name = _ballName;
            _freeBalls.Add(ball);
        }
    }

    public Ball GetBall()
    {
        Ball ball;
        
        if (_freeBalls.Count > 0)
        {
            ball = _freeBalls[0];
            _freeBalls.Remove(ball);
        }
        else
        {
            ball = Instantiate(_ballPrefab, transform);
        }

        ball.OnDestroyed += ReturnBall;
        ball.gameObject.SetActive(true);
        return ball;
    }

    private void ReturnBall(Ball ball)
    {
        ball.gameObject.SetActive(false);
        ball.ResetText();
        _freeBalls.Add(ball);
        ball.OnDestroyed -= ReturnBall;
    }
}