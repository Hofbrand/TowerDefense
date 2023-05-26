using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public Button ContinueButton;

    private IGameStateMachine _gameStateMachine;

    // public SceneFader sceneFader;

    private void Awake()
    {
        _gameStateMachine = AllServices.Container.Single<IGameStateMachine>();
        ContinueButton.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        _gameStateMachine.Enter<LoadLevelState, string>(nextLevel);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        //sceneFader.FadeTo(nextLevel);
    }
    
    public void Menu()
    {
        //sceneFader.FadeTo(menuSceneName);
    }
}
