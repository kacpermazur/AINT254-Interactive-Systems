using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManger : MonoBehaviour, IInitializable
    {
        private static readonly string GameMangerObjectName = typeof(GameManger).Name;
        private static GameManger _instance;

        private static bool _hasPlayerStarted;
        private static bool _hasPlayerDied;
        
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
            _currentGameState = GameState.GAME;
        }

        private void onGameState()
        {
            float timer = 0f;
            int deaths = 0;

            if (_hasPlayerStarted)
            {
                timer += Time.time;

                if (_hasPlayerDied)
                {
                    deaths += 1;
                }
            }
            else
            {
                timer = 0f;
            }
            
            

        }

    }
}