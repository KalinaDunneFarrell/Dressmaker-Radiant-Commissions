using BepInEx;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace RadiantUI.Utilities
{
    /// <summary>
    /// Class to create the Envelope on the desk
    /// </summary>
    internal class EnvelopeButton
    {
        private readonly BepInEx.Logging.ManualLogSource _logger;
        private Func<QuestDefinition> _onClick;

        public EnvelopeButton(BepInEx.Logging.ManualLogSource logger, Func<QuestDefinition> onClick)
        {
            _logger = logger;
            _onClick = onClick;
        }

        public void CreateAndDisplay(GameObject frontDesk)
        {
            _logger.LogInfo($"Creating {UIConstants.EnvelopeButtonName}");

            // Create a new UI object.
            GameObject buttonObject = new GameObject(
                UIConstants.EnvelopeButtonName,
                typeof(RectTransform),
                typeof(CanvasRenderer),
                typeof(Image),
                typeof(Button)
            );

            // Attach it to the FrontDesk Canvas.
            buttonObject.transform.SetParent(frontDesk.transform, false);

            // Configure its position and size.
            RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();

            rectTransform.sizeDelta = new Vector2(150, 150);
            rectTransform.anchoredPosition = new Vector2(-500, -475);

            // Load the PNG and convert it into a Sprite.
            try
            {
                // Load
                string imagePath = Path.Combine(Paths.PluginPath, UIConstants.ImagesFolder, UIConstants.EnvelopeImage);
                _logger.LogInfo($"Image path: {imagePath}");
                _logger.LogInfo($"Image exists: {File.Exists(imagePath)}");

                // Convert
                Sprite sprite = SpriteLoader.LoadSprite(imagePath);
                _logger.LogInfo($"Sprite loaded: {sprite != null}");

                // Display
                Image image = buttonObject.GetComponent<Image>();
                image.sprite = sprite;
            }
            catch (Exception e)
            {
                _logger.LogError($"Envelope error: {e}");
                return;
            }

            _logger.LogInfo("Envelope button displayed");

            // Configure the Button.
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(OnClick);

            _logger.LogInfo("Envelope configured");
        }

        private void OnClick()
        {
            QuestDefinition quest = _onClick();
            _logger.LogInfo($"Created Commission: {quest.PrettyName}");
            _logger.LogInfo($"Budget: {quest.budget}");
            _logger.LogInfo($"Completion Requirements: {String.Join(", ", quest.completionRequirements)}");
            _logger.LogInfo($"Character: {quest.CharacterName}");
        }
    }
}
