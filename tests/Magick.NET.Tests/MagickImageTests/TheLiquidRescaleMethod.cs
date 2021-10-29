﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public class TheLiquidRescaleMethod
        {
            public class WithWidthAndHeight
            {
                [Fact]
                public void ShouldResizeTheImage()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        image.LiquidRescale(128, 64);
                        Assert.Equal(64, image.Width);
                        Assert.Equal(64, image.Height);
                    }
                }
            }

            public class WithWidthAndHeightAndRigidity
            {
                [Fact]
                public void ShouldApplyTheRigidity()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        image.LiquidRescale(64, 64);

                        using (var other = new MagickImage(Files.MagickNETIconPNG))
                        {
                            other.LiquidRescale(64, 64, 5.0, 0.0);

                            Assert.InRange(image.Compare(other, ErrorMetric.RootMeanSquared), 0.5, 0.6);
                        }

                        using (var other = new MagickImage(Files.MagickNETIconPNG))
                        {
                            other.LiquidRescale(64, 64, 5.0, 10.0);

                            Assert.InRange(image.Compare(other, ErrorMetric.RootMeanSquared), 0.3, 0.4);
                        }
                    }
                }
            }

            public class WithGeometry
            {
                [Fact]
                public void ShouldThrowExceptionWhenGeometryIsNull()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        Assert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            image.LiquidRescale(null);
                        });
                    }
                }

                [Fact]
                public void ShouldResizeTheImage()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        var geometry = new MagickGeometry(128, 64)
                        {
                            IgnoreAspectRatio = true,
                        };

                        image.LiquidRescale(geometry);
                        Assert.Equal(128, image.Width);
                        Assert.Equal(64, image.Height);
                    }
                }
            }

            public class WithPercentage
            {
                [Fact]
                public void ShouldThrowExceptionWhenPercentageIsNegative()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        Assert.Throws<ArgumentException>("percentage", () =>
                        {
                            image.LiquidRescale(new Percentage(-1));
                        });
                    }
                }

                [Fact]
                public void ShouldThrowExceptionWhenPercentageWidthIsNegative()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        Assert.Throws<ArgumentException>("percentageWidth", () =>
                        {
                            image.LiquidRescale(new Percentage(-1), new Percentage(1));
                        });
                    }
                }

                [Fact]
                public void ShouldThrowExceptionWhenPercentageHeightIsNegative()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        Assert.Throws<ArgumentException>("percentageHeight", () =>
                        {
                            image.LiquidRescale(new Percentage(1), new Percentage(-1));
                        });
                    }
                }

                [Fact]
                public void ShouldResizeTheImage()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        image.LiquidRescale(new Percentage(25));
                        Assert.Equal(32, image.Width);
                        Assert.Equal(32, image.Height);
                    }
                }

                [Fact]
                public void ShouldIgnoreTheAspectRatio()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        image.LiquidRescale(new Percentage(25), new Percentage(10));
                        Assert.Equal(32, image.Width);
                        Assert.Equal(13, image.Height);
                    }
                }
            }

            public class WithPercentageAndRigidity
            {
                [Fact]
                public void ShouldThrowExceptionWhenPercentageWidthIsNegative()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        Assert.Throws<ArgumentException>("percentageWidth", () =>
                        {
                            image.LiquidRescale(new Percentage(-1), new Percentage(1), 0.0, 0.0);
                        });
                    }
                }

                [Fact]
                public void ShouldThrowExceptionWhenPercentageHeightIsNegative()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        Assert.Throws<ArgumentException>("percentageHeight", () =>
                        {
                            image.LiquidRescale(new Percentage(1), new Percentage(-1), 0.0, 0.0);
                        });
                    }
                }

                [Fact]
                public void ShouldApplyTheRigidity()
                {
                    using (var image = new MagickImage(Files.MagickNETIconPNG))
                    {
                        image.LiquidRescale(new Percentage(50), new Percentage(50));

                        using (var other = new MagickImage(Files.MagickNETIconPNG))
                        {
                            other.LiquidRescale(new Percentage(50), new Percentage(50), 5.0, 0.0);

                            Assert.InRange(image.Compare(other, ErrorMetric.RootMeanSquared), 0.5, 0.6);
                        }

                        using (var other = new MagickImage(Files.MagickNETIconPNG))
                        {
                            other.LiquidRescale(new Percentage(50), new Percentage(50), 5.0, 10.0);

                            Assert.InRange(image.Compare(other, ErrorMetric.RootMeanSquared), 0.3, 0.4);
                        }
                    }
                }
            }
        }
    }
}