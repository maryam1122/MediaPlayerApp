using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.DTO;

namespace MediaPlayer.Service.src.Shared
{
    public class Mapper
    {
        public static TDestination Convert<TSource, TDestination>(TSource source)
        where TDestination: new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            var sourceProperties = typeof(TSource).GetProperties();
            var destProperties = typeof(TDestination).GetProperties();
            var destination = new TDestination();
            foreach (var sourceProp in sourceProperties)
            {
                foreach (var destProp in destProperties)
                {
                    if (sourceProp.Name == destProp.Name && destProp.CanWrite && sourceProp.PropertyType == destProp.PropertyType)
                    {
                        // Copy the value from the source property to the destination property
                        destProp.SetValue(destination, sourceProp.GetValue(source));
                        break;
                    }
                }
            }
            return destination;
        }
    }
}