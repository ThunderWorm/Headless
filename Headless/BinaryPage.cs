﻿namespace Headless
{
    using System;
    using System.Net.Http;

    /// <summary>
    ///     The <see cref="BinaryPage" />
    ///     class provides the Binary response from a <see cref="Browser" /> request.
    /// </summary>
    public abstract class BinaryPage : Page
    {
        /// <summary>
        ///     Stores the content.
        /// </summary>
        private byte[] _content;

        /// <summary>
        ///     Gets the content.
        /// </summary>
        /// <returns>A <see cref="byte" /> array.</returns>
        public byte[] GetContent()
        {
            return _content;
        }

        /// <inheritdoc />
        protected internal override void SetContent(HttpContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content.ReadAsByteArrayAsync().Result;
        }
    }
}