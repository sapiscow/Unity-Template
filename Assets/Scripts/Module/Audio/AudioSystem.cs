using Sapiscow.Framework.Signal;
using Sapiscow.UnityTemplate.Module.Audios.Signal;
using System.Collections.Generic;
using UnityEngine;

namespace Sapiscow.UnityTemplate.Module.Audios
{
    public class AudioSystem : Sapiscow.Module.Audios.AudioSystem, IAudioSystem
    {
        public List<ResourceRequest> LoadAllAudio(bool async = false)
        {
            // TODO: Shouldn't be here.
            SignalManager.Subscribe<AudioPlaySfxSignal>(OnPlaySfxRequested);

            List<ResourceRequest> requests = new();

            AudioBgm[] bgms = (AudioBgm[])System.Enum.GetValues(typeof(AudioBgm));
            foreach (AudioBgm bgm in bgms)
            {
                if (async) requests.Add(LoadBgmAsync(bgm));
                else LoadBgm(bgm);
            }

            AudioSfx[] sfxs = (AudioSfx[])System.Enum.GetValues(typeof(AudioSfx));
            foreach (AudioSfx sfx in sfxs)
            {
                if (async) requests.Add(LoadSfxAsync(sfx));
                else LoadSfx(sfx);
            }

            return requests;
        }

        #region Bgm
        public void LoadBgm(AudioBgm bgm)
            => LoadBgm(bgm.ToString());

        public ResourceRequest LoadBgmAsync(AudioBgm bgm)
            => LoadBgmAsync(bgm.ToString());

        public void PlayBgm(AudioBgm bgm, bool stopOthers = true, bool forceRestart = false)
            => PlayBgm(bgm.ToString(), stopOthers, forceRestart);
        #endregion

        #region Sfx
        public void LoadSfx(AudioSfx sfx)
            => LoadSfx(sfx.ToString());

        public ResourceRequest LoadSfxAsync(AudioSfx sfx)
            => LoadSfxAsync(sfx.ToString());

        public int PlaySfx(AudioSfx sfx, bool isLooping = false)
        {
            if (sfx == AudioSfx.None) return -1;
            return PlaySfx(sfx.ToString(), isLooping);
        }
        #endregion

        #region Signal Subscriptions
        private void OnPlaySfxRequested(AudioPlaySfxSignal signal)
            => PlaySfx(signal.Sfx);
        #endregion
    }
}