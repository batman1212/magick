// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETSTANDARD

using System.Xml;

namespace ImageMagick
{
    internal static partial class XmlHelper
    {
        public static XmlReaderSettings CreateReaderSettings()
            => new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore,
                XmlResolver = null,
            };

        public static XmlDocument CreateDocument()
            => new XmlDocument
            {
                XmlResolver = null,
            };
    }
}

#endif
