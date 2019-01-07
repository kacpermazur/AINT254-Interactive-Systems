using Player;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManger : MonoBehaviour, IInitializable
    {
        private static readonly string GameMangerObjectName = typeof(GameManger).Name;
        private static GameManger _instance;

        public static GameManger instance { get { return _instance; } }

        [SerializeField] private PlayerManager _playerManger;
        // [SerializeField] private SoundManger _soundManger;
        [SerializeField] private UIManger _uiManger;

        public PlayerManager PlayerManger => _playerManger;
        // public static SoundManger SoundManger => _instance._soundManger;
        public UIManger UiManger => _uiManger;

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
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            
            CheckState();
        }

        public void Initialize()
        {
            InitializeMangers();
            _gameState = GameState.START;
        }

        private void InitializeMangers()
        {
           _playerManger.Initialize();
           _uiManger.Initialize();
           // _soundManger.Initialize();
        }

        private void CheckState()
        {
            switch (_gameState)
            {
                    case GameState.START:
                        Time.timeScale = 0;
                        _uiManger.OpenPanel(_uiManger.MainMenu);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(false);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.INGAME:
                        Time.timeScale = 1;
                        _uiManger.OpenPanel(_uiManger.InGamePanel);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(true);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.PAUSED:
                        Time.timeScale = 0;
                        _uiManger.OpenPanel(_uiManger.PausedPanel);
                        _playerManger.PlayerController.CanShoot(false);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(false);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.COMPLETELEVEL:
                        Time.timeScale = 0;
                        _uiManger.OpenPanel(_uiManger.VictoryPanel);
                        _playerManger.FirstPersonController.mouseLook.SetCursorLock(false);
                        _gameState = GameState.NONE;
                        break;
                    case GameState.NONE:
                        break;
                    default:
                        LogMessage("game state not set!");
                        break;
            }
        }

        private static void LogMessage(string message)
        {
            Debug.Log("<color=red>" + GameMangerObjectName + "</color> : " + message);
        }
    }
}



/*
private GUIUpdate _guiInstance;

        private static bool _hasPlayerStarted;
        private static bool _hasPlayerFinished;
        private static bool _hasPlayerDied;
        
        private float _timer = 0f;
        private int _deaths = 0;
        
        public enum GameState
        {
            MENU,
            GAME,
            PAUSE
        }

        private static GameState _currentGameState;
        
        public static void UpdateGameState(GameState type){ _currentGameState = type; }
        public static GameState GetCurrentGameState() { return _currentGameState; }

        public static bool SetPlayerStarted { set {  _hasPlayerStarted = value; } }
        public static bool SetPlayerFinished { set {  _hasPlayerFinished = value; } }
        public static bool SetPlayerDied { set {  _hasPlayerDied = value; } }

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            
            Initialize();
            
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            switch (_currentGameState)
            {
                    case GameState.MENU:
                        //
                        break;
                    case GameState.GAME:
                        onGameState();
                        break;
                    case GameState.PAUSE:
                        //
                        break;
            }
        }

        public void Initialize()
        {
            
            // Testing
            _guiInstance = GetComponent<GUIUpdate>();
            _currentGameState = GameState.GAME;
        }

        private void onGameState()
        {
            if (_hasPlayerStarted)
            {
                _timer += Time.time;
            }
            else if (_hasPlayerFinished)
            {
                // saves deaths and time
                _timer = _timer;
            }
            else
            {
                _timer = 0f;
            }
            
            if (_hasPlayerDied)
            {
                _deaths += 1;
                PlayerManager.PlayerController.SpawnPlayer();
                _hasPlayerDied = false;
            }
            
            _guiInstance.UpdateUI(_timer, _deaths);

        }


*/