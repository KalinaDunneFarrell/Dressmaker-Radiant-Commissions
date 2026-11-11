using RadiantCommission;
using UnityEngine;
using UnityEngine.Events;

namespace RadiantUI
{
    public class UIHelper
    {
        private readonly BepInEx.Logging.ManualLogSource _logger;

        public UIHelper(BepInEx.Logging.ManualLogSource logger)
        {
            _logger = logger;
        }

        public void CreateAndDisplayEnvelope(GameObject frontDesk, UnityAction onClick)
        {
            EnvelopeButton envelopeHelper = new EnvelopeButton(_logger, onClick);
            envelopeHelper.CreateAndDisplay(frontDesk);
        }
    }
}
