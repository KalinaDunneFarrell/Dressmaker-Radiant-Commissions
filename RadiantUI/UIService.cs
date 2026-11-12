using RadiantUI.Utilities;
using System;
using UnityEngine;

namespace RadiantUI
{
    /// <summary>
    /// Directs all functionality withing the RadiantUI project
    /// </summary>
    public class UIService
    {
        private readonly BepInEx.Logging.ManualLogSource _logger;
        private bool _envelopeIsDisplayed = false;

        public UIService(BepInEx.Logging.ManualLogSource logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Create and display the Envelope button used to generate new commissions
        /// </summary>
        public void CreateAndDisplayEnvelope(GameObject frontDesk, Func<QuestDefinition> onClick)
        {
            if (!_envelopeIsDisplayed)
            {
                EnvelopeButton envelopeHelper = new EnvelopeButton(_logger, onClick);
                envelopeHelper.CreateAndDisplay(frontDesk);
                _envelopeIsDisplayed = true;
            }
        }
    }
}
