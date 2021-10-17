﻿using System;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Nullscope class
    /// </summary>
    public class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        private NullScope() { }

        public void Dispose() { }
    }
}
