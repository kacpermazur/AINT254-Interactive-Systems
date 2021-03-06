﻿using Player;
using UI;
using UnityEngine;
using Core.Audio;
using Core.Game;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManger : MonoBehaviour, IInitializable
    {
        private static readonly string GameMangerObjectName = typeof(GameManger).Name;
        private static GameManger _instance;

        public static GameManger instance => _instance; 

        [SerializeField] private PlayerManager _playerManger;
        [SerializeField] private SoundManger _soundManger;
        [SerializeField] private UIManger _uiManger;

        [SerializeField] private OnStart _onStart;
        [SerializeField] private OnDeath _onDeath;
        [SerializeField] private OnFinish _onFinish;

        public PlayerManager PlayerManger => _playerManger;
        public SoundManger SoundManger => _soundManger;
        public UIManger UiManger => _uiManger;

        private Scene _currentScene;
        private bool _hasCompletedLevel;
        private float _bestTime = 0;
        private float _playerTime = 0;
        private int _playerDeaths = 0;

        public enum GameState
        {
            START,
            INGAME,
            PAUSED,
            COMPLETELEVEL,
            NONE
        }
        private GameState _gameState;

        public void SetGameState(GameState state) { _gameState = state; }
        public GameState GetGameState() { return _gameState; }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            
            Initialize();
        }

        private void Update()
        {
            CheckState();
            OnGameStart();
        }

        public void Initialize()
        {
            InitializeMangers();
            
            _currentScene = SceneManager.GetActiveScene();
            _bestTime = PlayerPrefs.GetFloat(_currentScene.name, Mathf.Infinity);
            _uiManger.PausedPanel.TextCurrentStage(_currentScene.buildIndex + 1);
            _gameState = GameState.START;
        }

        private void InitializeMangers()
        {
           _playerManger.Initialize();
           _uiManger.Initialize();
           _soundManger.Initialize();
        }

        private void CheckState()
        {
            switch (_gameState)
            {
                    case GameState.START:
                        Time.timeScale = 0;
                        ResetPlayer();
                        _uiManger.OpenPanel(_uiManger.MainMenuPanel);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(false);
                        _playerManger.PlayerController.SetCanPause(true);
                        _soundManger.StopSound("mainMusic", SoundManger.SoundType.MUSIC);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.INGAME:
                        Time.timeScale = 1;
                        _uiManger.OpenPanel(_uiManger.InGamePanel);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(true);
                        _soundManger.PlaySound("mainMusic", SoundManger.SoundType.MUSIC);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.PAUSED:
                        Time.timeScale = 0;
                        _uiManger.OpenPanel(_uiManger.PausedPanel);
                        _playerManger.PlayerController.CanShoot(false);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(false);
                        _soundManger.StopSound("mainMusic", SoundManger.SoundType.MUSIC);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.COMPLETELEVEL:
                        _onFinish.HasPlayerFinished = false;
                        _hasCompletedLevel = true;
                        OnComplete();
                        Time.timeScale = 0;
                        _uiManger.OpenPanel(_uiManger.VictoryPanel);
                        _playerManger.PlayerController.CanShoot(false);
                        _playerManger.PlayerController.SetCanPause(false);
                        _playerManger.PlayerController.DestoryBullet();
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(false);
                        _soundManger.StopSound("mainMusic", SoundManger.SoundType.MUSIC);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.NONE:
                        break;
                    default:
                        LogMessage("game state not set!");
                        break;
            }
        }

        private void OnGameStart()
        {
            if (_onStart.HasPlayerStarted || _hasCompletedLevel == false)
            {
                if (_onFinish.HasPlayerFinished)
                {
                    _gameState = GameState.COMPLETELEVEL;
                    _hasCompletedLevel = true;
                }
                else
                {
                    _playerTime += Time.deltaTime;
                }
            }

            if (_onDeath.HasPlayerDied)
            {
                _soundManger.PlaySound("death", SoundManger.SoundType.SFX);
                _onDeath.HasPlayerDied = false;
                _playerManger.PlayerController.SpawnPlayer();
                _playerManger.PlayerController.DestoryBullet();
                _playerDeaths += 1;
            }
            
            _uiManger.InGamePanel.changeTimeText(_playerTime);
            _uiManger.InGamePanel.changeDeathText(_playerDeaths);
        }

        private void OnComplete()
        {
            if (_playerTime < _bestTime)
            {
                _bestTime = _playerTime;
                PlayerPrefs.SetFloat(_currentScene.name, _bestTime);
            }
            
            _uiManger.VictoryPanel.TextBestTime(_bestTime);
            _uiManger.VictoryPanel.TextPlayerTime(_playerTime);
        }

        private void ResetPlayer()
        {
            _hasCompletedLevel = false;
            _playerTime = 0;
            _playerDeaths = 0;
            _playerManger.PlayerController.SpawnPlayer();
        }

        private static void LogMessage(string message)
        {
            Debug.Log("<color=red>" + GameMangerObjectName + "</color> : " + message);
        }
    }
}