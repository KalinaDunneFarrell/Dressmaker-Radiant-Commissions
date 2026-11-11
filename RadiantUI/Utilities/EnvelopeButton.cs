using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RadiantCommission
{
    /// <summary>
    /// Class to create the Envelope on the desk
    /// </summary>
    internal class EnvelopeButton
    {
        private readonly BepInEx.Logging.ManualLogSource _logger;
        private UnityAction _onClick;

        public EnvelopeButton(BepInEx.Logging.ManualLogSource logger, UnityAction onClick)
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
                Sprite sprite = LoadSprite(imagePath);
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
            button.onClick.AddListener(_onClick);

            _logger.LogInfo("Envelope configured");
        }

        /// <summary>
        /// Basically Texture2D.LoadImage but without using that library directly bc it 
        /// doesn't work with 4.7.2 but the mods needs 4.7.2 :(
        /// </summary>
        private Sprite LoadSprite(string imagePath)
        {
            // Read the PNG file.
            byte[] imageData = File.ReadAllBytes(imagePath);

            // Create an empty texture.
            Texture2D texture = new Texture2D(2, 2);

            // Find Unity's ImageConversion assembly.
            Assembly assembly = Assembly.Load("UnityEngine.ImageConversionModule");

            // Find the ImageConversion class.
            Type imageConversion = assembly.GetType("UnityEngine.ImageConversion");

            // Find its static LoadImage method.
            MethodInfo loadImage = imageConversion.GetMethod(
                "LoadImage",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(Texture2D), typeof(byte[]), typeof(bool) },
                null
            );

            // Invoke LoadImage on our texture.
            bool success = (bool)loadImage.Invoke(
                null,
                new object[] { texture, imageData, false }
            );

            if (!success)
            {
                string error = "Failed to load envelope PNG.";
                _logger.LogError(error);
                throw new Exception(error);
            }

            // Create and return a Sprite from the texture.
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }
    }
}
