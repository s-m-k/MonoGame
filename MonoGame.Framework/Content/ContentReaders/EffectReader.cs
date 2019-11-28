// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
    internal class EffectReader : ContentTypeReader<Effect>
    {
        public EffectReader()
        {
        }

        protected internal override Effect Read(ContentReader input, Effect existingInstance)
        {
            int dataSize = input.ReadInt32();
            byte[] data = input.ContentManager.GetScratchBuffer(dataSize);
            input.Read(data, 0, dataSize);

            if (input.GetGraphicsDevice().IsLoggingResources) {
                string logMessage = string.Format("Loading Effect content: {0}", input.AssetName);
                input.GetGraphicsDevice().LogResource(logMessage);
            }

            var effect = new Effect(input.GetGraphicsDevice(), data, 0, dataSize);
            effect.Name = input.AssetName;

            return effect;
        }
    }
}
