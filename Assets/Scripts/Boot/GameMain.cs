using Sapiscow.Framework.Boot;
using Sapiscow.UnityTemplate.Module.Audios;
using UnityEngine;

namespace Sapiscow.UnityTemplate.Boot
{
    public class GameMain : IGameMain
    {
        private IAudioSystem _audioSystem;

        public void Init()
        {
            Application.targetFrameRate = 60;
            Input.multiTouchEnabled = false;

            CreateEventSystem();

            _audioSystem.LoadAllAudio();
        }

        private void CreateEventSystem()
        {
            Object eventSystem = GameObject.Instantiate(Resources.Load("EventSystem"));
            Object.DontDestroyOnLoad(eventSystem);
        }
    }
}