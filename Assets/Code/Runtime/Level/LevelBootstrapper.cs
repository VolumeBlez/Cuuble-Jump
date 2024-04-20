using UnityEngine;

public class LevelBootstrapper : MonoBehaviour
{
    [SerializeField] private LevelData _data;
    [SerializeField] private Actor _actor;
    [SerializeField] private InputHandler _handler;
    [SerializeField] private PlatformGeneratorBootstrapper _generatorBootstrapper;

    private void Start()
    {
        _generatorBootstrapper.Init();
        _actor.Init(_data.Gravity, _data.LevelWidth, _handler);

        _handler.Enable();
    }

    private void OnDisable()
    {
        _handler.Disable();
    }
}
