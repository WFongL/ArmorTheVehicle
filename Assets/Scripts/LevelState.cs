using UnityEngine;
using UnityEngine.UI;

public class LevelState : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private SliderPassing levelPassing;
    [SerializeField] private EnemyCreator enemyCreator;
    [SerializeField] private GroundMovement groundMovement;
    [SerializeField] private Button youWin;
    [SerializeField] private Button youLose;

    private void OnEnable()
    {
        car.Died += LevelLose;
        levelPassing.Win += LevelWin;
    }

    private void OnDisable()
    {
        car.Died -= LevelLose;
        levelPassing.Win -= LevelWin;
    }

    public void ToGarage()
    {
        car.transform.position = Vector3.zero;
        cameraFollow.ToGarage();
        levelPassing.Reset();
        enemyCreator.Reset();
        groundMovement.Reset();
    }

    public void StartLevel()
    {
        car.Reset();
        car.StartMove();
        levelPassing.StartPassing();
        cameraFollow.ToCarMove();
        enemyCreator.StartSpawn();
    }

    public void LevelLose()
    {
        car.StopMove();
        levelPassing.StopPassing();
        enemyCreator.StopMoveAllEnemy();
        youLose.gameObject.SetActive(true);
    }

    public void LevelWin()
    {
        car.StopMove();
        enemyCreator.StopMoveAllEnemy();
        youWin.gameObject.SetActive(true);
    }
}
