using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace RadiantUI.Utilities
{
    /// <summary>
    /// Reflection of Texture2D.LoadImage
    /// </summary>
    internal static class SpriteLoader
    {
        /// <summary>
        /// Create a <see cref="Sprite"/> from a png file
        /// </summary>
        /// <remarks>
        /// Basically Texture2D.LoadImage but without using that library directly bc it 
        /// doesn't work with 4.7.2 but the mods needs 4.7.2 :(
        /// </remarks>
        internal static Sprite LoadSprite(string imagePath)
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
                throw new Exception("Failed to load envelope PNG.");

            // Create and return a Sprite from the texture.
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }
    }
}
