using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    Ball ball;
    [SerializeField]
    Bat bat;
    [SerializeField]
    Gui gui;
    [SerializeField]
    Block block;
    [SerializeField]
    private float BallSpeed = 5;
    [SerializeField]
    private float BatSpeed = 10;
    [SerializeField]
    private Collider BordersLeft;
    [SerializeField]
    private Collider BordersRight;
    // Start is called before the first frame update
    void Start()
    {
        ball.Speed = BallSpeed;
        bat.Speed = BatSpeed;
        block.OnBlockCollision += Block_OnBlockCollision;
        bat.OnBatCollision += Bat_OnBatCollision;
        bat.SetBorderX(BordersRight.bounds.center.x - BordersRight.bounds.extents.x, BordersLeft.bounds.center.x + BordersLeft.bounds.extents.x);
       
    }

    private void Bat_OnBatCollision(float f)
    {
        Vector2 vCorr = Vector2.Lerp(Vector2.left, Vector2.right, f);
        ball.ChangeVelocity(vCorr);
        gui.AddScore(true);
    }

    private void Block_OnBlockCollision()
    {
        gui.AddScore(false);
    }
    
       
    private void OnDestroy()
    {
        block.OnBlockCollision -= Block_OnBlockCollision;
        bat.OnBatCollision -= Bat_OnBatCollision;
    }
}
