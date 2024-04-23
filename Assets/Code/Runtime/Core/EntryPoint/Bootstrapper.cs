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

    private void Start()
    {
        _reloadButton.Hide(0);
        InitSystems();

        EventBinding<ActorDieEvent> actorDieEventBinding = new EventBinding<ActorDieEvent>(OnActorEvent);
        EventBus<ActorDieEvent>.Register(actorDieEventBinding);  

        _reloadButton.SetClickAction(() => SceneManager.LoadScene(0));

        _startButton.SetClickAction(StartLevel);
        _startButton.SetClickAction(() => _startButton.Hide());

        _exitButton.SetClickAction(() => Application.Quit());
        _exitButton.SetClickAction(() => _exitButton.Hide());
    }

    private void OnActorEvent(ActorDieEvent dieEvent)
    {
        _reloadButton.Show();
    }

    public void InitSystems()
    {
        _generatorBootstrapper.Init();
        _handler.Enable();
    }

    public void StartLevel()
    {
        _actor.Init(_data.Gravity, _data.LevelWidth, _handler);
    }

    private void OnDisable()
    {
        _handler.Disable();
    }
}
