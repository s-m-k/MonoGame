// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using MonoGame.Utilities;
using System.Runtime.InteropServices;


namespace Microsoft.Xna.Framework.Graphics
{
    public delegate void OnGraphicsResourceLog(string logMessage);
    public partial class GraphicsDevice
    {
        private bool isLoggingResources = false;
        private OnGraphicsResourceLog logCallback;

        internal bool IsLoggingResources {
            get {
                return isLoggingResources;
            }
        }

        public void SetResourceLogCallback(OnGraphicsResourceLog callback) {
            logCallback = callback;
            isLoggingResources = callback != null;
        }

        public void LogResource(string logMessage) {
            if (logCallback != null) {
                logCallback.Invoke(logMessage);
            }
        }
    }
}
