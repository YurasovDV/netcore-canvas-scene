using System;
using System.Linq;
using System.Linq.Expressions;
using CanvasScene.Entities;

namespace CanvasScene.DAL.Specifications
{
    public static class Specifications
    {
        public static IQueryable<T> GetByName<T>(this IQueryable<T> entities, FilterParams parameters) where T: Figure
        {
            Expression<Func<T, bool>> predicate = x => true;

            if (IsNotEmpty(parameters) && !string.IsNullOrWhiteSpace(parameters.Name))
            {
                predicate = x => x.Name.Contains(parameters.Name, StringComparison.OrdinalIgnoreCase);
            }

            return entities.Where(predicate);
        }

        public static IQueryable<T> GetByWidth<T>(this IQueryable<T> entities, FilterParams parameters) where T: Figure
        {
            Expression<Func<T, bool>> predicate = null;

            if (IsNotEmpty(parameters))
            {
                var min = parameters.WidthMin.GetValueOrDefault(-1);
                var max = parameters.WidthMax.GetValueOrDefault(-1);

                if (parameters.WidthMin.HasValue && parameters.WidthMax.HasValue)
                {
                    predicate = x => x.Width >= min && x.Width <= max;
                }
                else if (parameters.WidthMin.HasValue)
                {
                    predicate = x => x.Width >= min;
                }
                else if (parameters.WidthMax.HasValue)
                {
                    predicate = x => x.Width <= max;
                }
            }

            if (predicate != null)
            {
                entities = entities.Where(predicate);
            }

            return entities;
        }

        private static bool IsNotEmpty(FilterParams parameters)
        {
            return parameters != null && !FilterParams.Empty.Equals(parameters);
        }
    }
}
