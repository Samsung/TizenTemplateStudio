using System.Collections.Generic;
using Param_RootNamespace.Models;

namespace Param_RootNamespace.Services
{
    public static class SampleDataService
    {
        /// <summary>
        /// Provides the material, color, names and values.
        /// See more details at https://materialuicolors.co/
        /// </summary>
        public static IEnumerable<SampleColor> AllColors()
        {
            return new List<SampleColor>()
            {
                new SampleColor()
                {
                    Name = "Red",
                    HexCode = "#F44336",
                    Icon = "SampleData/Red.png"
                },
                new SampleColor()
                {
                    Name = "Pink",
                    HexCode = "#E91E63",
                    Icon = "SampleData/Pink.png"
                },
                new SampleColor()
                {
                    Name = "Purple",
                    HexCode = "#9C27B0",
                    Icon = "SampleData/Purple.png"
                },
                new SampleColor()
                {
                    Name = "Deep Purple",
                    HexCode = "#673AB7",
                    Icon = "SampleData/DeepPurple.png"
                },
                new SampleColor()
                {
                    Name = "Indigo",
                    HexCode = "#3F51B5",
                    Icon = "SampleData/Indigo.png"
                },
                new SampleColor()
                {
                    Name = "Blue",
                    HexCode = "#2196F3",
                    Icon = "SampleData/Blue.png"
                },
                new SampleColor()
                {
                    Name = "Light Blue",
                    HexCode = "#03A9F4",
                    Icon = "SampleData/LightBlue.png"
                },
                new SampleColor()
                {
                    Name = "Cyan",
                    HexCode = "#00BCD4",
                    Icon = "SampleData/Cyan.png"
                },
                new SampleColor()
                {
                    Name = "Teal",
                    HexCode = "#009688",
                    Icon = "SampleData/Teal.png"
                },
                new SampleColor()
                {
                    Name = "Green",
                    HexCode = "#4CAF50",
                    Icon = "SampleData/Green.png"
                },
                new SampleColor()
                {
                    Name = "Light Green",
                    HexCode = "#8BC34A",
                    Icon = "SampleData/LightGreen.png"
                },
                new SampleColor()
                {
                    Name = "Lime",
                    HexCode = "#CDDC39",
                    Icon = "SampleData/Lime.png"
                },
                new SampleColor()
                {
                    Name = "Yellow",
                    HexCode = "#FFEB3B",
                    Icon = "SampleData/Yellow.png"
                },
                new SampleColor()
                {
                    Name = "Amber",
                    HexCode = "#FFC107",
                    Icon = "SampleData/Amber.png"
                },
                new SampleColor()
                {
                    Name = "Orange",
                    HexCode = "#FF9800",
                    Icon = "SampleData/Orange.png"
                },
                new SampleColor()
                {
                    Name = "Deep Orange",
                    HexCode = "#FF5722",
                    Icon = "SampleData/DeepOrange.png"
                },
                new SampleColor()
                {
                    Name = "Brown",
                    HexCode = "#795548",
                    Icon = "SampleData/Brown.png"
                },
                new SampleColor()
                {
                    Name = "Grey",
                    HexCode = "#9E9E9E",
                    Icon = "SampleData/Grey.png"
                },
                new SampleColor()
                {
                    Name = "Blue Grey",
                    HexCode = "#607D8B",
                    Icon = "SampleData/BlueGrey.png"
                }
            };
        }
    }
}
