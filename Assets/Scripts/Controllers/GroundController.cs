using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private BuffManager _buffManager;
    
    public void CheckBall(Ball ball)
    {
        if (ball.CheckSpecialBall())
        {
            _buffManager.ApplyEffect(ball);
        }
    }
}
