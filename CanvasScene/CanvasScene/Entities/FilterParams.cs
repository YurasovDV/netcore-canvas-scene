using System;

namespace CanvasScene
{
    public class FilterParams
    {
        public readonly static FilterParams Empty = new FilterParams();

        public string Name { get; set; }

        /// <summary>
        /// включительно
        /// </summary>
        public int? WidthMin { get; set; }

        /// <summary>
        /// включительно
        /// </summary>
        public int? WidthMax { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!(obj is FilterParams another))
            {
                return false;
            }

            return WidthMin == another.WidthMin
                && WidthMax == another.WidthMax
                && string.Equals(Name, another.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return WidthMin.GetValueOrDefault(0) ^ WidthMax.GetValueOrDefault(0);
        }

    }
}
