# Initialization

There are three ways to initialize the ImageMagick library these are described below.

### Simple initialization

The example below shows how you can initialize the library and make sure the ImageMagick library is properly initialized.

```C#
using System;
using ImageMagick;

namespace MagickExample
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            MagickNET.Initialize();
        }
    }
}
```

### Initialize with xml files

The example below show how you can initialize ImageMagick with a directory that contains all the xml configuration files. This directory will need to contain all the xml files. Those files can be found in the [bin folder](https://github.com/ImageMagick/VisualMagick/tree/main/bin) of [VisualMagick](https://github.com/ImageMagick/VisualMagick) combined with the files from the [xml folder](https://github.com/dlemstra/Magick.Native/tree/main/src/Magick.Native/Resources/xml) of [Magick.Native](https://github.com/dlemstra/Magick.Native/tree/main/src/Magick.Native/Resources/xml).

```C#
using System;
using ImageMagick;

namespace MagickExample
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            MagickNET.Initialize(@"C:\MyProgram\MyImageMagickXmlFiles");
        }
    }
}
```

### Initialize with the ConfigurationFiles class.

Another option is to use the ConfigurationFiles class. This class contains a property for each of the xml files and returns an object that contains the file name and the data
of the xml configuration file. Below is an example of how you could change the policy to only allow a specific set of formats.

```C#
using System;
using ImageMagick;
using ImageMagick.Configuration;

namespace MagickExample
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var configFiles = ConfigurationFiles.Default;
            configFiles.Policy.Data = @"
<policymap>
  <policy domain=""delegate"" rights=""none"" pattern=""*"" />
  <policy domain=""coder"" rights=""none"" pattern=""*"" />
  <policy domain=""coder"" rights=""read|write"" pattern=""{GIF,JPEG,PNG,WEBP}"" />
</policymap>";

            string temporaryDirectory = MagickNET.Initialize(configFiles);
        }
    }
}
```

The method will return the temporary directory where the xml files were written to. This location can be controlled with extra an overload that allows you to specify the location.

```C#
    var configFiles = ConfigurationFiles.Default;
    MagickNET.Initialize(configFiles, @"C:\MyProgram\MyImageMagickXmlFiles");
```
