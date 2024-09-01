using Sapiscow.Framework.Boot;
using Sapiscow.UnityTemplate.Module.Audios;

namespace Sapiscow.UnityTemplate.Scene.Gameplay
{
    public class GameplayLauncher : BaseSceneLauncher
    {
        private IAudioSystem _audioSystem;

        private void Start()
        {
            _audioSystem.PlayBgm(AudioBgm.Gameplay);
        }
    }
}