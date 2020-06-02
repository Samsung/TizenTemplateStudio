using System;

namespace Param_RootNamespace.Models
{
    // TODO: Remove this class once your features are using your data.
    // This is used by the SampleDataService.
    public class SampleColor
    {
        public string Name { get; set; }

        public string HexCode { get; set; }

        public string Icon { get; set; }

        public override string ToString()
        {
            return $"{Name} {HexCode}";
        }
    }
}
