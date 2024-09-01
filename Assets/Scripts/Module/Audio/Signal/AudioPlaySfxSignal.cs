using Sapiscow.Framework.Signal;

namespace Sapiscow.UnityTemplate.Module.Audios.Signal
{
    public readonly struct AudioPlaySfxSignal : ISignal
    {
        public AudioSfx Sfx { get; }

        public AudioPlaySfxSignal(AudioSfx sfx)
        {
            Sfx = sfx;
        }
    }
}