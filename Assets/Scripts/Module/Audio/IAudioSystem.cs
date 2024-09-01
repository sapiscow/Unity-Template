using System.Collections.Generic;
using UnityEngine;

namespace Sapiscow.UnityTemplate.Module.Audios
{
    public interface IAudioSystem : Sapiscow.Module.Audios.IAudioSystem
    {
        /// <param name="async">True if you need like smooth loading progress.</param>
        List<ResourceRequest> LoadAllAudio(bool async = false);

        #region Bgm
        void LoadBgm(AudioBgm bgm);
        ResourceRequest LoadBgmAsync(AudioBgm bgm);

        /// <param name="forceRestart">Leave it false, if you don't need to
        /// restart the BGM when this function is called.</param>
        void PlayBgm(AudioBgm bgm, bool stopOthers = true, bool forceRestart = false);
        #endregion

        #region Sfx
        void LoadSfx(AudioSfx sfx);
        ResourceRequest LoadSfxAsync(AudioSfx sfx);

        /// <returns>Returns SFX ID that could be stored for controlling looping SFX.</returns>
        int PlaySfx(AudioSfx sfx, bool isLooping = false);
        #endregion
    }
}