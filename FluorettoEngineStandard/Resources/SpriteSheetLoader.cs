using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluorettoEngineSerializable;

namespace FluorettoEngine.Resources
{
    public class SpriteSheetLoader
    {
        SpriteSheetData data;

        Dictionary<string, SpriteSheetTexture> textures;

        public SpriteSheetLoader(Game game, string assetName)
        {
            data = game.Content.Load<SpriteSheetData>(assetName);
            textures = new Dictionary<string, SpriteSheetTexture>();

            foreach (var item in data.Textures)
            {
                textures.Add(item.Name, item);
            }
        }

        public SpriteSheetTexture GetDimensions(string sprite)
        {
            return textures[sprite];
        }
    }
}
