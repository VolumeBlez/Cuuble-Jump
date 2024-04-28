using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LevelData _data;

    [Header("References")]
    [SerializeField] private Actor _actor;
    [SerializeField] private InputHandler _handler;
    [SerializeField] private PlatformGeneratorBootstrapper _generatorBootstrapper;

    [Header("UI Button Controllers")]
    [SerializeField] private ButtonController _startButton;
    [SerializeField] private ButtonController _exitButton;
    [SerializeField] private ButtonController _reloadButton;

    private EventBinding<ActorDieEvent> _actorDieEventHandler;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        Application.targetFrameRate = 60;

        _actorDieEventHandler = new EventBinding<ActorDieEvent>(OnActorDieEventHandler);
        EventBus<ActorDieEvent>.Register(_actorDieEventHandler);  
        
        InitSystems();
        InitUI();
    }

    private void OnDisable()
    {
        _handler.Disable();
        EventBus<ActorDieEvent>.Unregister(_actorDieEventHandler);
    }

    private void OnActorDieEventHandler()
    {
        _reloadButton.Show();
        _handler.Disable();
    }

    public void InitSystems()
    {
        _sceneLoader = new();
        _generatorBootstrapper.Init();
        _handler.Enable();
    }

    private void InitUI()
    {
        _reloadButton.SetClickAction(() => _sceneLoader.LoadMainScene());
        _reloadButton.SetClickAction(() => _startButton.Hide(0));

        _startButton.SetClickAction(StartLevel);
        _startButton.SetClickAction(() => _startButton.Hide(0));

        _exitButton.SetClickAction(() => Application.Quit());
        _exitButton.SetClickAction(() => _startButton.Hide(0));

        _reloadButton.Hide(0);
    }

    private void StartLevel()
        => _actor.Init(_data.Gravity, _data.LevelWidth, _handler);
}
